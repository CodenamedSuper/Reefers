using CastleGame;
using Microsoft.Xna.Framework;
using Reefers;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class ReeferStore : GameObject
{
    public UiElementGrid uiGrid;
    public override void Load()
    {
        NineSliceSprite sprite = new NineSliceSprite("assets/img/ui/nineslice");
        sprite.Size = new Vector2(76, 255);
        sprite.SetPadding(2);
        AddComponent(sprite);

        Position = new Vector2(50, (GraphicsConfig.SCREEN_HEIGHT / 5) - 30);

        uiGrid = new UiElementGrid(new Vector2(2, 9), 32);

        uiGrid.Position = Position - new Vector2(13, 100);

        foreach(KeyValuePair<string, Func<Reefer>> entry in ReeferRegistry.List)
        {
            Reefer reefer = entry.Value();

            if (reefer.Name == ReeferRegistry.Brain().Name) continue;

            reefer.Load();

            UiElementGroup group = new UiElementGroup(new ReeferButton(reefer));

            uiGrid.AddUiElementGroup(group);

        }

        AddComponent(uiGrid);

        base.Load();
    }
}

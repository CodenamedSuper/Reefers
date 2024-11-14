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

            ReeferButton reeferButton = new ReeferButton(reefer);
            reeferButton.Layer = 70;
            UiElementGroup group = new UiElementGroup(reeferButton);

            //Text nameText = new Text("assets/font/peaberry", reefer.Name);
            // nameText.Scale = 0.7f;
            // GameObject nameUiElement = new GameObject(); nameUiElement.AddComponent(nameText);
            // nameUiElement.Layer = 80;

            // Text priceText = new Text("assets/font/peaberry", reefer.SETTINGS.Price.ToString());
            // priceText.Scale = 0.7f;
            // GameObject priceUiElement = new GameObject(); priceUiElement.AddComponent(priceText);
            // priceUiElement.Layer = 100;

            // group.AddChild(nameUiElement, new Vector2(10,10));
            // group.AddChild(priceUiElement, new Vector2(10, 20));

            uiGrid.AddUiElementGroup(group);

        }

        AddComponent(uiGrid);

        base.Load();
    }
}

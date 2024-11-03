using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Reef : GameObject
{
    public TileSet SandTileSet { get; set; } = new TileSet();
    public TileSet ReefersTileSet { get; set; } = new TileSet();

    public TileGrid SandTileGrid { get; set; } = new TileGrid(new Vector2(28, 28));
    public TileGrid ReefersTileGrid { get; set; } = new TileGrid(new Vector2(28, 28));

    public Vector2 ReefSize { get; set; } = Vector2.Zero;

    public Reef(Vector2 reefSize)
    {
        ReefSize = reefSize;
    }

    public override void Load()
    {
        Vector2 offset = new Vector2(-7, -4);

        AddComponent(SandTileGrid);
        AddComponent(ReefersTileGrid);

        SandTileSet.AddFromSprite("sand_1", "assets/img/misc/sand_1");
        SandTileSet.AddFromSprite("sand_2", "assets/img/misc/sand_2");

        SandTileGrid.AddTileSet(SandTileSet);

        int length = (int)ReefSize.X * (int)ReefSize.Y;
        Vector2 coords = Vector2.Zero;

        for(int i = 0; i < length; i++)
        {
            if (i % 2 == 0) SandTileGrid.PlaceTile(coords + offset, "sand_1");
            else SandTileGrid.PlaceTile(coords + offset, "sand_2");

            coords.X++;
            if(coords.X == ReefSize.X)
            {
                coords.X = 0;
                coords.Y++;
            }

        }

        base.Load();
    }

}

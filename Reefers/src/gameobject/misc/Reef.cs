using CastleGame;
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

    public List<TileSet> ReefersTileSets { get; set; } = new List<TileSet>();


    public TileGrid SandTileGrid { get; set; } = new TileGrid(new Vector2(28, 28));
    public TileGrid ReefersTileGrid { get; set; } = new TileGrid(new Vector2(28, 28));

    public Vector2 ReefSize { get; set; } = Vector2.Zero;

    public Reef(Vector2 reefSize)
    {
        ReefSize = reefSize;
    }

    public override void Load()
    {

        SandTileSet.AddFromSprite("sand_1", "assets/img/misc/sand_1");
        SandTileSet.AddFromSprite("sand_2", "assets/img/misc/sand_2");

        GenerateReeferTileSets();

        foreach (TileSet tileSet in ReefersTileSets)
        {
            ReefersTileGrid.AddTileSet(tileSet);

        }

        AddComponent(SandTileGrid);
        AddComponent(ReefersTileGrid);


        SandTileGrid.AddTileSet(SandTileSet);

        PlaceSand();

        ReefersTileGrid.PlaceTile(Vector2.Floor(new Vector2(ReefSize.X / 2, ReefSize.Y / 2)), ReeferRegistry.Brain().Name);


        base.Load();
    }

    public void GenerateReeferTileSets()
    {
        ReefersTileGrid.Layer = 1;

        int count = 0;
        foreach (KeyValuePair<string, Func<Reefer>> refeer in ReeferRegistry.List)
        {

            ReefersTileSets.Add(new TileSet());
            Reefer reefer = refeer.Value();
            ReefersTileSets[count].Add(refeer.Key, refeer.Value);
            count++;
        }
    }

    public void PlaceSand()
    {
        int length = (int)ReefSize.X * (int)ReefSize.Y;
        Vector2 coords = Vector2.Zero;

        for (int i = 0; i < length; i++)
        {
            if (i % 2 == 0) SandTileGrid.PlaceTile(coords, "sand_1");
            else SandTileGrid.PlaceTile(coords, "sand_2");

            coords.X++;
            if (coords.X == ReefSize.X)
            {
                coords.X = 0;
                coords.Y++;
            }

        }
    }

}

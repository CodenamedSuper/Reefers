using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class SpawnerTile : Tile
{
    public SpawnerTile() : base("spawner")
    {
    }

    public override void Load()
    {
        Spawner spawner = new Spawner(TrasherRegistry.Drop); AddComponent(spawner); 
        spawner.MaxInterval = 60;

        base.Load();
    }

}

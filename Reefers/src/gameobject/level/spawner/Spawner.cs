using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Spawner : Tile
{
    bool spawned = false;
    public Spawner() : base("spawner")
    {
    }

    public override void Load()
    {
        base.Load();
    }

    public override void Update()
    {
        if (spawned == false)
        {
            Spawn(TrasherRegistry.Drop());
            spawned = true;
        }

        base.Update();
    }

    public void Spawn(Trasher trasher)
    {
        trasher.Position = Position;
        SceneManager.CurrentScene.AddGameObject(trasher);
    }
}

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
        Random random = new Random();
        Timer timer = new Timer(random.Next(4, 20)); AddComponent(timer);
        timer.Autostart = true;
        timer.Start();
        timer.OnTimeout += Spawn;

        base.Load();
    }

    public override void Update()
    {
        if (spawned == false)
        {
            spawned = true;
        }

        base.Update();
    }

    public void Spawn()
    { 
        Trasher trasher = TrasherRegistry.Drop();
        trasher.Position = Position;
        SceneManager.CurrentScene.AddGameObject(trasher);
    }
}

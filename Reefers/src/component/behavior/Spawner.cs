﻿using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Spawner : Behavior
{

    public Func<GameObject> PoolGameObject { get; set; } = () => new GameObject();

    public int MaxInterval { get; set; } = 1;

    public Spawner(Func<GameObject> gameObject)
    {
        PoolGameObject = gameObject;
        StateName = "spawn";
    }

    public override void Initialize()
    {
        Random random = new Random();

        Timer timer = new Timer(random.Next(1, MaxInterval + 1));
        timer.Autostart = true;
        timer.OnTimeout += Spawn;
        timer.Start();
        SubComponents.AddComponent(timer);


        base.Initialize();
    }

    public void Spawn()
    {
        ChangeState();

        GameObject gameObject = PoolGameObject();
        gameObject.Position = GameObject.Position;

        SceneManager.CurrentScene.AddGameObject(gameObject);

        Random random = new Random();
    }


}
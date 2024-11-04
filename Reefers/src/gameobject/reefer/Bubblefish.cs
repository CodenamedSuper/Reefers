using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Bubblefish : Reefer
{
    public Bubblefish(string name, Settings settings) : base(name, settings)
    {
    }

    public override void Load()
    {
        Timer timer = new Timer(1); AddComponent(timer);
        timer.Start();
        timer.Autostart = true;
        timer.OnTimeout += Shoot;

        base.Load();
    }

    public void Shoot()
    {
        Projectile bubble = ProjectileRegistry.Bubble();
        bubble.Position = Position;

        SceneManager.CurrentScene.AddGameObject(bubble);

        bubble.CreateAndAddComponent<Direction>();
        bubble.GetComponent<Direction>().Set(GetComponent<Direction>().Facing);

    }


}

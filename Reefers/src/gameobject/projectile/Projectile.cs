using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public abstract class Projectile : GameObject
{
    public Projectile(string name)
    {
        Name = name;
    }

    public override void Load()
    {
        Layer = 4;
        Sprite sprite = new Sprite(ProjectileRegistry.GetPath(Name, AssetTypes.Image)); AddComponent(sprite);

        base.Load();
    }

    public override void Update()
    {
        Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();
        if(Position.X > reef.ReefSize.X * 28)
        {
            Remove();
        }

        base.Update();
    }


}

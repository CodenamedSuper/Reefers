using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Projectile : GameObject
{
    public Settings SETTINGS { get; set; }
    public Projectile(string name, Settings settings)
    {
        Name = name;
        SETTINGS = settings;
    }

    public override void Load()
    {
        Layer = 4;
        Sprite sprite = new Sprite(ProjectileRegistry.GetPath(Name, AssetTypes.Image)); AddComponent(sprite);
        Hitbox hitbox = new Hitbox(Position + new Vector2(2,2), new Vector2(16, 16), GameObjectTypes.Trasher); AddComponent(hitbox); hitbox.DestroyOnCollision = true;
        Movement movement = CreateAndAddComponent<Movement>(); movement.Speed = SETTINGS.Speed;
        

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

    public class Settings
    {
        public float Speed { get; set; } = 0;

        public int Damage { get; set; } = 0;
        public Settings SetSpeed(float speed)
        {
            Speed = speed;
            return this;
        }

        public Settings SetDamage(int damage)
        {
            Damage = damage;
            return this;
        }
    }


}

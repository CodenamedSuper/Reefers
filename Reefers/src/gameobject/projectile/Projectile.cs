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
        Hitbox hitbox = new Hitbox(Position, new Vector2(28, 28)); AddComponent(hitbox);

        base.Load();
    }

    public override void Update()
    {
        Move(GetComponent<Direction>());

        base.Update();

    }

    public void Move(Direction direction)
    {
        if (direction != null)
        {
            if (direction.Facing == Direction.East().Facing)
            {
                Position = new Vector2(Position.X + SETTINGS.Speed, Position.Y);
            }
            if (direction.Facing == Direction.West().Facing)
            {
                DebugGui.Log(Position.ToString());
                Position = new Vector2(Position.X - SETTINGS.Speed / 10, Position.Y);

            }
            if (direction.Facing == Direction.North().Facing)
            {
                Position = new Vector2(Position.X, Position.Y + SETTINGS.Speed);

            }
            if (direction.Facing == Direction.South().Facing)
            {
                Position = new Vector2(Position.X, Position.Y + SETTINGS.Speed);

            }
        }
    }

    public class Settings
    {
        public float Speed { get; set; } = 0;

        public Settings SetSpeed(float speed)
        {
            Speed = speed;
            return this;
        }
    }


}

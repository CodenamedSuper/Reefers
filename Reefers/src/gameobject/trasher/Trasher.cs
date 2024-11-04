using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Trasher : GameObject
{

    public Settings SETTINGS;

    public Trasher(string name, Settings settings)
    {
        Name = name;
        SETTINGS = settings;
    }

    public override void Load()
    {
        Layer = 1;

        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        Direction direction = CreateAndAddComponent<Direction>();
        Health health = new Health(SETTINGS.MaxHealth); AddComponent(health);
        Hurtbox hurtbox = new Hurtbox(Position, new Vector2(28, 28)); AddComponent(hurtbox);


        animationTree.AddAnimation(TrasherRegistry.GetPath(Name, AssetTypes.Animation), _ => true);

        health.OnHealthEmptied += OnDeath;

        base.Load();
    }

    public virtual void OnDeath()
    {
        SceneManager.CurrentScene.Remove(this);
    }

    public override void Update()
    {

        Direction direction = GetComponent<Direction>();
        direction.Set(Direction.West().Facing);

        if (GetComponent<AnimationTree>().CurrentAnimation != null)
        {

            Sprite sprite = GetComponent<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite;

            if (direction.Facing == Direction.East().Facing) sprite.Effect = SpriteEffects.None;
            if (direction.Facing == Direction.West().Facing) sprite.Effect = SpriteEffects.FlipHorizontally;
        }

        Move(GetComponent<Direction>());

        base.Update();
    }

    public void Move(Direction direction)
    {
        if(direction.Facing == Direction.East().Facing)
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

    public class Settings
    {
        public int MaxHealth { get; set; } = 0;

        public float Speed { get; set; } = 0;

        public Settings SetMaxHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            return this;
        }

        public Settings SetSpeed(float speed)
        {
            Speed = speed;
            return this;
        }
    }


}

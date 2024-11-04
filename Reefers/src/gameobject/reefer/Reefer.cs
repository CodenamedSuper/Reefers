
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Reefer : Tile
{

    public Settings SETTINGS;

    public Reefer(string name, Settings settings) : base(name)
    {
        SETTINGS = new Settings();
    }

    public override void Load()
    {

        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        Direction direction = CreateAndAddComponent<Direction>();
        Health health = new Health(SETTINGS.MaxHealth);
        Hurtbox hurtbox = new Hurtbox(Position, new Vector2(28, 28)); AddComponent(hurtbox);


        animationTree.AddAnimation(ReeferRegistry.GetPath(Name, AssetTypes.Animation), _ => true);

        health.OnHealthEmptied += OnDeath;

        base.Load();
    }

    public override void Update()
    {

        Direction direction = GetComponent<Direction>();

        if (GetComponent<AnimationTree>().CurrentAnimation != null)
        {

            Sprite sprite = GetComponent<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite;

            if (direction.Facing == Direction.East().Facing) sprite.Effect = SpriteEffects.None;
            if (direction.Facing == Direction.West().Facing) sprite.Effect = SpriteEffects.FlipHorizontally;
        }

        base.Update();
    }

    public virtual void OnDeath()
    {
        Reef reef = SceneManager.CurrentScene.GetGameObject<Reef>();
        reef.ReefersTileGrid.RemoveTile(reef.ReefersTileGrid.ConvertWorldCoordinatesToGridCoordinates(Position));
    }

    public class Settings
    {
        public int MaxHealth { get; set; } = 0;

        public Settings SetMaxHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            return this;
        }
    }
}

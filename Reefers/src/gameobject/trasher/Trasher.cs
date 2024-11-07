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
    private bool animationsRegistered = false;

    public Settings SETTINGS;

    public Trasher(string name, Settings settings)
    {
        Name = name;
        SETTINGS = settings;
    }

    public override void Load()
    {
        Layer = 2;

        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        StateMachine stateMachine = CreateAndAddComponent<StateMachine>();
        Direction direction = CreateAndAddComponent<Direction>(); direction.Set(Direction.Left());
        Health health = new Health(SETTINGS.MaxHealth); AddComponent(health);
        Hitbox hitbox = new Hitbox(Position, new Vector2(28, 28)); AddComponent(hitbox);
        Hurtbox hurtbox = new Hurtbox(Position, new Vector2(28, 28)); AddComponent(hurtbox);
        Movement movement = CreateAndAddComponent<Movement>(); movement.Speed = SETTINGS.Speed;
        Attacker attacker = CreateAndAddComponent<Attacker>(); attacker.Damage = 1; 

        GameObjectState idleState = new GameObjectState("idle"); stateMachine.AddState(idleState);

        stateMachine.SetState(idleState.Name);

        base.Load();
    }

    public override void Update()
    {
        if (!animationsRegistered) RegisterAnimations();

        base.Update();
    }

    public void RegisterAnimations()
    {
        AnimationTree animationTree = GetComponent<AnimationTree>();
        StateMachine stateMachine = GetComponent<StateMachine>();

        foreach (GameObjectState state in stateMachine.States.Values)
        {
            animationTree.AddAnimation(TrasherRegistry.GetPath(Name + "_" + state.Name, AssetTypes.Animation), _ => stateMachine.CurrentState.Name == state.Name);
        }

        animationsRegistered = true;
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

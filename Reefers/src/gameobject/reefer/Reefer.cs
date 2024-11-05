
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Reefer : Tile
{

    public Settings SETTINGS;

    private bool animationsRegistered = false;

    public Reefer(string name, Settings settings) : base(name)
    {
        SETTINGS = new Settings();
    }

    public override void Load()
    {
        AnimationTree animationTree = CreateAndAddComponent<AnimationTree>();
        StateMachine stateMachine = CreateAndAddComponent<StateMachine>();
        Health health = new Health(SETTINGS.MaxHealth); AddComponent(health);
        Hurtbox hurtbox = new Hurtbox(Position, new Vector2(28, 28));
        Direction direction = CreateAndAddComponent<Direction>(); direction.Set(Direction.East().Facing);

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
            animationTree.AddAnimation(ReeferRegistry.GetPath(Name + "_" + state.Name, AssetTypes.Animation), _ => stateMachine.CurrentState.Name == state.Name);
        }

        animationsRegistered = true;
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

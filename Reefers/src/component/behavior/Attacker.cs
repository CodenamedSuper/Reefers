using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Attacker : Behavior
{
    public Direction Direction { get; set; }
    public Vector2 AttackSize { get; set; } = new Vector2(28, 28);
    public int Damage { get; set; } = 1;

    public float Interval = 1;

    public Attacker()
    {
        StateName = "attack";
    }

    public override void Initialize()
    {
        Direction = GetSibling<Direction>();
        Hitbox hitbox = GetSibling<Hitbox>();

        Timer timer = new Timer(1);
        timer.Autostart = true;
        timer.OnTimeout += Attack;
        timer.Start();

        base.Initialize();
    }

    public override void Update()
    {

        if (GetSibling<Movement>() == null && GetSibling<Hitbox>() == null) return;

        Hitbox hitbox = GetSibling<Hitbox>();
        Movement movement = GetSibling<Movement>();
        movement.Velocity = Vector2.Zero;

        if (!movement.Moving && hitbox.CollidingGameObject == null) movement.Moving = true;

        else if(hitbox.CollidingGameObject != null) movement.Moving = false;

        base.Update();
    }

    public void Attack()
    {
        Hitbox hitbox = GetSibling<Hitbox>();

        if (hitbox.CollidingGameObject == null) return;

        GameObject target = hitbox.CollidingGameObject;

        if (target.HasComponent<Hurtbox>() && target.HasComponent<Health>())
        {
            target.GetComponent<Health>().Decrement(Damage);

            ChangeState();
        }

    }
}

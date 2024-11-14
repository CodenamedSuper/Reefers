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
    public Vector2 AttackOffset { get; set; } = Vector2.Zero;
    public int Damage { get; set; } = 1;
    public string TargetType { get; set; } = GameObjectTypes.All;
    public float Interval { get; set; } = 1;

    public Attacker()
    {
        StateName = "attack";
    }

    public override void Initialize()
    {
        Direction = GetSibling<Direction>();
        Hitbox hitbox = GetSibling<Hitbox>();

        hitbox = new Hitbox(GameObject.Position, AttackSize, TargetType);
        hitbox.Offset = AttackOffset * Direction.GetVector2(Direction);
        hitbox.Damage = Damage;

        Timer timer = new Timer(Interval); AddSubComponent(timer);
        timer.Autostart = true;
        timer.OnTimeout += Attack;

        base.Initialize();
    }
    public void Attack()
    {
        ChangeState();

        Hitbox hitbox = GetSibling<Hitbox>();
        hitbox.Enabled = true;
    }
}

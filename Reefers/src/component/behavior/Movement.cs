using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Movement : Behavior
{
    public float Speed { get; set; } = 1f;
    public Vector2 Velocity { get; set; } = Vector2.Zero;

    public Movement()
    {
        StateName = "move";
    }

    public override void Update()
    {
        base.Update();

        Move(GetSibling<Direction>());

    }

    public void Move(Direction direction)
    {
        Velocity = Direction.GetVector2(direction) * Speed;

        GameObject.Position += Velocity;

        ChangeState();
    }
}

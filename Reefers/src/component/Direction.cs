using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Direction : Component
{

    public string Facing { get; private set; }

    public Direction() : base(false)
    {
        Facing = "none";
    }
    public void Set(string direction)
    {
        Facing = direction;
    }

    public void Cycle()
    {
        if(Facing == North().Facing)
        {
            Facing = East().Facing;
        }
        else if (Facing == East().Facing)
        {
            Facing = South().Facing;
        }
        else if (Facing == South().Facing)
        {
            Facing = West().Facing;
        }
        else if (Facing == West().Facing)
        {
            Facing = North().Facing;
        }
    }

    public static Direction None()
    {
        Direction direction = new Direction();
        direction.Set("none");

        return direction;
    }
    public static Direction North()
    {
        Direction direction = new Direction();
        direction.Set("north");

        return direction;
    }
    public static Direction West()
    {
        Direction direction = new Direction();
        direction.Set("west");

        return direction;
    }
    public static Direction South()
    {
        Direction direction = new Direction();
        direction.Set("soth");

        return direction;
    }
    public static Direction East()
    {
        Direction direction = new Direction();
        direction.Set("east");

        return direction;
    }

}

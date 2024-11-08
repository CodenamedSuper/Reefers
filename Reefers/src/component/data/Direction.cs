﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        Facing = "left";
    }
    public Direction(string facing) : base(false)
    {
        Facing = facing;
    }
    public void Set(Direction direction)
    {
        Facing = direction.Facing;
    }

    public override void Update()
    {

        if (GameObject.HasComponent<AnimationTree>() && GetSibling<AnimationTree>().CurrentAnimation != null)
        {
            FlipSprite(GetSibling<AnimationTree>().CurrentAnimation.SpriteSheet.CurrentSprite);
            return;
        }
        if (GameObject.HasComponent<Sprite>())
        {
            FlipSprite(GetSibling<Sprite>());
            return;
        }

        base.Update();
    }

    public void FlipSprite(Sprite sprite)
    {
        if(this.Equals(Left())) sprite.Effect = SpriteEffects.FlipHorizontally;
      
        else if(this.Equals(Right())) sprite.Effect = SpriteEffects.None;
    }

    public bool Equals(Direction direction)
    {
        return direction.Facing == Facing;
    }

    public void Cycle()
    {
        if(Facing == Up().Facing)
        {
            Set(Right());
        }
        else if (Facing == Right().Facing)
        {
            Set(Down());
        }
        else if (Facing == Down().Facing)
        {
            Set(Left());
        }
        else if (Facing == Left().Facing)
        {
            Set(Up());
        }
    }

    public static Direction Up()
    {
        Direction direction = new Direction("up");

        return direction;
    }
    public static Direction Left()
    {
        Direction direction = new Direction("left");

        return direction;
    }
    public static Direction Down()
    {
        Direction direction = new Direction("down");

        return direction;
    }
    public static Direction Right()
    {
        Direction direction = new Direction("right");

        return direction;
    }

    public static Vector2 GetVector2(Direction direction)
    {
        if (direction.Facing == Right().Facing)
        {
            return new Vector2(1, 0);
        }
        if (direction.Facing == Left().Facing)
        {
            return new Vector2(-1, 0);

        }
        if (direction.Facing == Up().Facing)
        {
            return new Vector2(0, -1);

        }
        if (direction.Facing == Down().Facing)
        {
            return new Vector2(0, 1);

        }

        return Vector2.Zero;
    }

}
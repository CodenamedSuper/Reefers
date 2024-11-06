using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Hitbox : Collision
{
    public int Damage { get; set; } = 1;
    public Hitbox(Vector2 position, Vector2 dimensions) : base(position, dimensions)
    {
        OnCollide += OnCollision;
    }

    public virtual void OnCollision(GameObject target)
    {
    } 

}

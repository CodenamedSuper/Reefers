using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Hurtbox : Collision
{
    public Hurtbox(Vector2 position, Vector2 dimensions) : base(position, dimensions)
    {
    }
}

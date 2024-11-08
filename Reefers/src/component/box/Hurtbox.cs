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
    public Health Health { get; set; }

    public string Type { get; set; } = "";
    public Hurtbox(Vector2 position, Vector2 dimensions, string type) : base(position, dimensions)
    {
        Type = type;
    }

    public override void Initialize()
    {
        Health = GetSibling<Health>();


        base.Initialize();
    }
}

using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class ProjectileHitBox : Hitbox
{
    public ProjectileHitBox(Vector2 position, Vector2 dimensions) : base(position, dimensions)
    {
    }

    public override void OnCollision(GameObject target)
    {

        if(target is Trasher trasher && trasher.HasComponent<Health>())
        {
            Health health = trasher.GetComponent<Health>();
            health.Decrement(Damage);
        }

        GameObject.Remove();

        base.OnCollision(target);
    }
}

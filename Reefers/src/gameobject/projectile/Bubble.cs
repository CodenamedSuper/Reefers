using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Bubble : Projectile
{
    public Bubble(string name) : base(name)
    {
    }

    public override void Load()
    {
        base.Load();

        Hitbox hitbox = new Hitbox(Position + new Vector2(2, 2), new Vector2(16, 16), GameObjectTypes.Trasher); AddComponent(hitbox); hitbox.DestroyOnCollision = true;
        Movement movement = CreateAndAddComponent<Movement>(); movement.Speed = 1;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class SandDollar : Projectile
{
    public SandDollar(string name) : base(name)
    {
    }

    public override void Load()
    {
        base.Load();

        Fading fading = CreateAndAddComponent<Fading>(); fading.Amount = 10;
        Direction direction = CreateAndAddComponent<Direction>(); direction.Set(Direction.Up());
        Movement movement = CreateAndAddComponent<Movement>(); movement.Speed = 0.5f;
    }
}

using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Bubblefish : Reefer
{
    public Bubblefish(string name, Settings settings) : base(name, settings)
    {
    }

    public override void Load()
    {
        Shooter shooter = new Shooter(ProjectileRegistry.Bubble()); AddComponent(shooter);
        shooter.Interval = 2f;
        base.Load();
        

    }

    public override void Update()
    {

        base.Update();
    }


}

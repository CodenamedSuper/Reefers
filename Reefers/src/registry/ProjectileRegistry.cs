using Reefers;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class ProjectileRegistry : Registry
{
    public static new Dictionary<string, Func<Projectile>> List = new Dictionary<string, Func<Projectile>>();

    public static new string Path = "projectiles/";


    public static Func<Projectile> Bubble = Register(() => new Projectile("bubble", new Projectile.Settings().SetSpeed(1).SetDamage(1)));

    public static Func<Projectile> Register(Func<Projectile> bubble)
    {
        List.Add(bubble().Name, bubble);
        return bubble;
    }

    public static new string GetPath(string name, string asset)
    {
        return asset + Path + name;
    }
}

using Reefers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class TrasherRegistry : Registry
{
    public static new Dictionary<string, Func<Trasher>> List = new Dictionary<string, Func<Trasher>>();

    public static new string Path = "trashers/";

    public static Func<Trasher> Drop = Register(() => new Trasher("drop", new Trasher.Settings().SetMaxHealth(6).SetSpeed(2f)));

    public static Func<Trasher> Register(Func<Trasher> trasher)
    {
        List.Add(trasher().Name, trasher);
        return trasher;
    }

    public static new string GetPath(string name, string asset)
    {
        return asset + Path + name;
    }
}

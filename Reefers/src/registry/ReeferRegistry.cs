﻿using Reefers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class ReeferRegistry : Registry
{
    public static new Dictionary<string, Func<Reefer>> List = new Dictionary<string, Func<Reefer>>();

    public static new string Path = "reefers/";

    public static Func<Reefer> Brain = Register(() => new Brain("brain", new Reefer.Settings().SetMaxHealth(10)));

    public static Func<Reefer> Bubblefish = Register(() => new Bubblefish("bubblefish", new Reefer.Settings().SetMaxHealth(5).SetPrice(3)));

    public static Func<Reefer> Flinder = Register(() => new Flinder("flinder", new Reefer.Settings().SetMaxHealth(3).SetPrice(0)));

    public static Func<Reefer> Register(Func<Reefer> reefer)
    {
        List.Add(reefer().Name, reefer);
        return reefer;
    }

    public static new string GetPath(string name, string asset)
    {
        return asset + Path + name;
    }
}

using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class RestartOnDeath : Component
{

    public Health Health { get; set; }

    public RestartOnDeath() : base(false)
    {
    }

    public override void Initialize()
    {
        Health = GetSibling<Health>();
        Health.OnHealthEmptied += RestartLevel;

        base.Initialize();
    }

    public void RestartLevel()
    {
        Debug.WriteLine("restarted!");
    }
}

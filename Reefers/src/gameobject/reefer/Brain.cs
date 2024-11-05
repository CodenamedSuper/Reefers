using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Brain : Reefer
{
    public Brain(string name, Settings settings) : base(name, settings)
    {
    }

    public override void Load()
    {
        base.Load();

        CreateAndAddComponent<RestartOnDeath>();

    }
}

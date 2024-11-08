using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Flinder : Reefer
{
    public Flinder(string name, Settings settings) : base(name, settings)
    {
    }

    public override void Load()
    {
        base.Load();

        SandDollarGenerator sandDollarGenerator = CreateAndAddComponent<SandDollarGenerator>(); 
        sandDollarGenerator.Interval = 10;

    }
}

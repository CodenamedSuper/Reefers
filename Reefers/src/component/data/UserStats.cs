using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class UserStats : Component
{
    public int SandDollars { get; set; } = 0;

    public UserStats() : base(false)
    {
    }
}

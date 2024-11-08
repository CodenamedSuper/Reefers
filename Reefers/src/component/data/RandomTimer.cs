using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class RandomTimer : Timer
{
    public int MinWaitTime { get; set; } = 1;
    public int MaxWaitTime { get; set; } = 1;

    public RandomTimer(int minWaitTime, int maxWaitTime) : base(new Random().Next(minWaitTime, maxWaitTime + 1))
    {
        MaxWaitTime = maxWaitTime;
        MinWaitTime = minWaitTime;
    }

    public void Start(int minWaitTime, int maxWaitTime)
    {
        MaxWaitTime = maxWaitTime;
        MinWaitTime = minWaitTime;
        Start(new Random().Next(MinWaitTime, MaxWaitTime + 1));
    }

    public override void End()
    {
        InvokeTimeout();
        Time = 0;
        Enabled = false;


        if (Autostart)
        {
            Enabled = true;
            Start(MinWaitTime, MaxWaitTime);
        }

    }

}

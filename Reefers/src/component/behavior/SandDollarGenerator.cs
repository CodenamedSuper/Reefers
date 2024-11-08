using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class SandDollarGenerator : Behavior
{

    public int Amount { get; set; } = 1;

    public float Interval = 10f;

    public SandDollarGenerator()
    {
        StateName = "generate";
    }

    public override void Initialize()
    {

        Timer timer = new Timer(Interval); AddSubComponent(timer);
        timer.Autostart = true;
        timer.OnTimeout += Generate;

        base.Initialize();
    }

    public void Generate()
    {
        UserStats userStats = SceneManager.CurrentScene.GetGameObject<User>().GetComponent<UserStats>();

        userStats.SandDollars += Amount;

        ChangeState();
    }

}

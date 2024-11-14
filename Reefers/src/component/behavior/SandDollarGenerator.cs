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
    public float Interval { get; set; } = 10f;
    public bool ShowDolllarPopUp { get; set; } = true;

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
        ChangeState();

        UserStats userStats = SceneManager.CurrentScene.GetGameObject<User>().GetComponent<UserStats>();

        userStats.SandDollars += Amount;

        if (!ShowDolllarPopUp) return;

        Projectile projectile = ProjectileRegistry.SandDollar();
        projectile.Position = GameObject.Position;
        SceneManager.CurrentScene.AddGameObject(projectile);

    }

}

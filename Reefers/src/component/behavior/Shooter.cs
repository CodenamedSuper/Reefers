using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Shooter : Behavior
{
   
    public Projectile Projectile { get; set; }
    public Detectbox Detectbox { get; set; }

    public Shooter(Projectile projectile)
    {
        Projectile = projectile;
        StateName = "shoot";
    }

    public override void Update()
    {


        base.Update();
    }

    public virtual void Shoot()
    {
        ChangeState();

        Projectile projectile = Projectile;
        projectile.Position = GameObject.Position;

        SceneManager.CurrentScene.AddGameObject(projectile);

        projectile.CreateAndAddComponent<Direction>();
        projectile.GetComponent<Direction>().Set(GetSibling<Direction>().Facing);
        Debug.WriteLine("hello");
    }



}

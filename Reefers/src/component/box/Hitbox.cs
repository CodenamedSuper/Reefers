using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public delegate void HitEvent(Hurtbox targetHurtbox);

public class Hitbox : Collision
{
    public event HitEvent OnHit;

    public int Damage { get; set; } = 1;

    public bool DestroyOnCollision = false;

    public string TargetType { get; set; } = "all";
    public Hitbox(Vector2 position, Vector2 dimensions, string targetType) : base(position, dimensions)
    {
        TargetType = targetType;
        OnHit += Hit;
    }
    protected override void CheckCollision()
    {
        if (!Enabled) return;

        foreach (GameObject target in SceneManager.CurrentScene.GetGameObjects())
        {
            if (!target.HasComponent<Hurtbox>()) continue;

            if (GameObject == target) continue;

            Hurtbox targetHurtbox = target.GetComponent<Hurtbox>();

            if (Box.Intersects(targetHurtbox.Box) && (TargetType.Equals(targetHurtbox.Type) || TargetType.Equals("all")))
            {
                CollidingGameObject = target;
                OnHit?.Invoke(targetHurtbox);
                break;
            }
        }
    }

    public void Hit(Hurtbox targetHurtox)
    {
        targetHurtox.Health.Decrement(Damage);
        Enabled = false;

        if (DestroyOnCollision) GameObject.Remove();
    }

}

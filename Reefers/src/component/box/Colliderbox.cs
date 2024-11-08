using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Colliderbox : Collision
{
    public string TargetType { get; set; } = "all";

    public string Type { get; set; } = "all";
    public Colliderbox(Vector2 position, Vector2 dimensions, string type, string targetType) : base(position, dimensions)
    {
        Type = type;
        TargetType = targetType;
    }
    public override void Update()
    {
        base.Update();

        if (GameObject.HasComponent<Movement>())
        {
            Movement movement = GetSibling<Movement>();
            movement.Moving = true;

            if (CollidingGameObject == null || !CollidingGameObject.HasComponent<Colliderbox>()) return;

            if(Type == CollidingGameObject.GetComponent<Colliderbox>().TargetType || TargetType == "all")
            movement.Moving = false;
        }
    }
}

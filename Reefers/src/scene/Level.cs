using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Level : Scene
{
    public Level(string name) : base(name)
    {
        Camera.Zoom = 3f;
        Camera.Position += new Vector2(200, 110);
    }

    public override void Begin()
    {
    }

    public override void End()
    {
    }

    public override void LoadContent()
    {
        Reef reef = new Reef(new Vector2(17, 10));
        AddGameObject(reef);

    }
}

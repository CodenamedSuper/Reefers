using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Fading : Component
{
    public Sprite Sprite { get; set; }

    public int Amount = 1;

    public Fading() : base(false)
    {
    }

    public override void Initialize()
    {
        Sprite = GetSibling<Sprite>();

        base.Initialize();
    }

    public override void Update()
    {
        Sprite.Color = new Color(Sprite.Color.R, Sprite.Color.G, Sprite.Color.B, Sprite.Color.A - Amount);

        if(Sprite.Color.A <= 0) GameObject.Remove();

        base.Update();
    }
}

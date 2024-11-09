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

    public float Modifier = 0.02f;

    private float opacity = 1;

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
        opacity -= Modifier;
        Sprite.Color = Color.White * opacity;

        if(Sprite.Color.R <= 0) GameObject.Remove();


        base.Update();
    }
}

using CastleGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers;

public class Level : Scene
{
    public static Cursor Cursor { get; private set; }

    private RenderTarget2D cursorRenderTarget = new RenderTarget2D(SerpentGame.Instance.GraphicsDevice, GraphicsConfig.SCREEN_WIDTH, GraphicsConfig.SCREEN_HEIGHT);

    public Level(string name) : base(name)
    {
        Camera.Zoom = 3f;
        Camera.UIScale = 3f;

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
        Cursor = new Cursor();
        Cursor.Load();

        Reef reef = new Reef(new Vector2(17, 9)); AddGameObject(reef);

        User user = new User(); AddGameObject(user);

        StatsUi statsUi = new StatsUi(); AddUIElement(statsUi);

        ReeferStore reeferStore = new ReeferStore(); AddUIElement(reeferStore);
    }

    public override void Update()
    {
        Cursor.Update();

        Camera.Position = Vector2.Clamp(Camera.Position, new Vector2(-1700, -1700), new Vector2(1700, 1700));

        base.Update();
    }


    public override void Draw()
    {
        SerpentGame.Instance.GraphicsDevice.SetRenderTarget(cursorRenderTarget);
        SerpentGame.Instance.GraphicsDevice.Clear(Color.Transparent);

        SerpentEngine.Draw.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, Camera.Matrix);
        Cursor.Draw();
        SerpentEngine.Draw.SpriteBatch.End();

        SerpentGame.Instance.GraphicsDevice.SetRenderTarget(null);

        base.Draw();

        SerpentEngine.Draw.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
        SerpentEngine.Draw.SpriteBatch.Draw(cursorRenderTarget, Vector2.Zero, Color.White);
        SerpentEngine.Draw.SpriteBatch.End();
    }
}

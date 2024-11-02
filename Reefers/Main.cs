using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SerpentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reefers
{
    public class Main : SerpentGame
    {
        public Main() : base("Reefers")
        {
            GraphicsConfig.SCREEN_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            GraphicsConfig.SCREEN_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            GraphicsConfig.FULLSCREEN = true;
            GraphicsConfig.VSYNC = true;
            GraphicsConfig.FRAMERATE = 60;
            IsMouseVisible = false;
            GraphicsConfig.Apply();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            base.LoadContent();


            // Scene loading
            Scene game = new Level("level");

            SceneManager.AddScene(game);

            SceneManager.SetCurrentScene(game);

            // Debug GUIs
            ImGuiDrawable debugGui = new DebugGui();

            ImGuiManager.AddGuiDrawable(debugGui);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}

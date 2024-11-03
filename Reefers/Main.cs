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
            GraphicsConfig.VSYNC = true;
            GraphicsConfig.FULLSCREEN = true;
            GraphicsConfig.FRAMERATE = 60;
            GraphicsConfig.BACKGROUND_COLOR = new Color(215, 158, 86);
            IsMouseVisible = true;
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
            Scene level = new Level("level");

            SceneManager.AddScene(level);

            SceneManager.SetCurrentScene(level);

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

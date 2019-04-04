using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace PpuingPpuing
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenManager m_ScreenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            TargetElapsedTime = TimeSpan.FromTicks(166666);

            InactiveSleepTime = TimeSpan.FromSeconds(1);

            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            m_ScreenManager = new ScreenManager();
            IScreen.m_ScreenManager = m_ScreenManager;

            m_ScreenManager.AddScreen(Mode.TitleScreen, new TitleScreen(), Content);
            m_ScreenManager.AddScreen(Mode.StoryScreen, new StoryScreen(), Content);
            m_ScreenManager.AddScreen(Mode.MapScreen, new MapScreen(), Content);
            m_ScreenManager.AddScreen(Mode.ResultScreen, new ResultScreen(), Content);

            m_ScreenManager.SelectScreen(Mode.TitleScreen);

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            m_ScreenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            m_ScreenManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

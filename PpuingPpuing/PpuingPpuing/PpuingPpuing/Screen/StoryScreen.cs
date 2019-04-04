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
    class StoryScreen : IScreen
    {
        ReleaseButton m_SkipButton;
        ReleaseButton m_TapButton;
        List<Texture2D> Story = new List<Texture2D>();
        int m_StoryNumber;

        public override void Init(ContentManager content)
        {
            Story.Add(content.Load<Texture2D>("StoryScreen/01"));
            Story.Add(content.Load<Texture2D>("StoryScreen/02"));
            Story.Add(content.Load<Texture2D>("StoryScreen/03"));
            Story.Add(content.Load<Texture2D>("StoryScreen/04"));
            Story.Add(content.Load<Texture2D>("StoryScreen/05"));
            Story.Add(content.Load<Texture2D>("StoryScreen/06"));
            Story.Add(content.Load<Texture2D>("StoryScreen/07"));
            Story.Add(content.Load<Texture2D>("StoryScreen/08"));
            Story.Add(content.Load<Texture2D>("StoryScreen/09"));
            Story.Add(content.Load<Texture2D>("StoryScreen/10"));
            Story.Add(content.Load<Texture2D>("StoryScreen/11"));
            Story.Add(content.Load<Texture2D>("StoryScreen/12"));
            Story.Add(content.Load<Texture2D>("StoryScreen/13"));

            m_SkipButton = new ReleaseButton();
            m_SkipButton.Init(content, new Vector2(700, 20), 1f, "StoryScreen/SkipButton");
            m_SkipButton.UserTouchEvent = OnTouchSkipButton;

            m_TapButton = new ReleaseButton();
            m_TapButton.Init(content, new Vector2(0, 0), 1f, "StoryScreen/EmptyButton");
            m_TapButton.UserTouchEvent = OnTouchTapButton;
        }
        private void OnTouchSkipButton()
        {
            m_StoryNumber = 0;
            m_ScreenManager.SelectScreen(Mode.MapScreen);
        }
        private void OnTouchTapButton()
        {
            if (m_StoryNumber++ > 11)
            {
                m_StoryNumber = 0;
                m_ScreenManager.SelectScreen(Mode.MapScreen);
            }
        }
        public override void Update(GameTime gameTime)
        {
            m_TapButton.Update(gameTime);
            m_SkipButton.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Story[m_StoryNumber], new Vector2(0,0), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            m_TapButton.Draw(spriteBatch);
            m_SkipButton.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
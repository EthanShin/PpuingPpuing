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
    class TitleScreen : IScreen
    {
        #region 변수
        Texture2D m_BackgroundImage;
        Texture2D m_PpuingTextureImage;
        Texture2D m_PpuoooTextureImage;

        Texture2D m_PpuoooImage;
        Texture2D m_PolarBearImage;
        Texture2D m_PandaImage;
        Texture2D m_TunaImage;
        Texture2D m_AntelopeImage;
        Texture2D m_RhinocerosImage;
        Texture2D m_FrogImage;
        Texture2D m_ArmadilloImage;
        Texture2D m_ShadowImage;

        ReleaseButton m_StartButton;
        ReleaseButton m_ContinueButton;
        ReleaseButton m_ExitButton;
        ReleaseButton m_OptionButton;

        Texture2D m_SmallAppleImage;
        Texture2D m_BigAppleImage;
        #endregion

        #region
        SoundEffect m_ButtonSound;
        #endregion


        public override void Init(ContentManager content)
        {
            m_BackgroundImage = content.Load<Texture2D>("TitleScreen/Background");
            m_PpuingTextureImage = content.Load<Texture2D>("TitleScreen/PpuingPpuingText");
            m_PpuoooTextureImage = content.Load<Texture2D>("TitleScreen/PpuooooooText");
            m_SmallAppleImage = content.Load<Texture2D>("TitleScreen/SmallApple");
            m_BigAppleImage = content.Load<Texture2D>("TitleScreen/BigApple");
            m_ButtonSound = content.Load<SoundEffect>("Music/ButtonS");

            InitCharacter(content);
            InitButton(content);
            InitMusic(content);
        }
        private void InitMusic(ContentManager content)
        {
            List<Song> m_BGMS = new List<Song>();
            m_BGMS.Add(content.Load<Song>("Music/TitleMusic"));
            MediaPlayer.Stop();
            MediaPlayer.Play(m_BGMS[0]);
        }
        private void InitCharacter(ContentManager content)
        {
            m_PpuoooImage = content.Load<Texture2D>("TitleScreen/Character/Ppuooo");
            m_PolarBearImage = content.Load<Texture2D>("TitleScreen/Character/PolarBearBlack");
            m_PandaImage = content.Load<Texture2D>("TitleScreen/Character/PandaBlack");
            m_TunaImage = content.Load<Texture2D>("TitleScreen/Character/TunaBlack");
            m_AntelopeImage = content.Load<Texture2D>("TitleScreen/Character/AntelopeBlack");
            m_RhinocerosImage = content.Load<Texture2D>("TitleScreen/Character/RhinocerosBlack");
            m_FrogImage = content.Load<Texture2D>("TitleScreen/Character/FrogBlack");
            m_ArmadilloImage = content.Load<Texture2D>("TitleScreen/Character/ArmadilloBlack");

            m_ShadowImage = content.Load<Texture2D>("TitleScreen/Character/Shadow");
        }
        private void InitButton(ContentManager content)
        {
            m_StartButton = new ReleaseButton();
            m_StartButton.Init(content, new Vector2(15, 280), 0.5f, "TitleScreen/Start");
            m_StartButton.UserTouchEvent = OnTouchStartButton;

            m_ContinueButton = new ReleaseButton();
            m_ContinueButton.Init(content, new Vector2(25, 345), 0.5f, "TitleScreen/Continue");
            m_ContinueButton.UserTouchEvent = OnTouchContinueButton;

            m_ExitButton = new ReleaseButton();
            m_ExitButton.Init(content, new Vector2(30, 410), 0.5f, "TitleScreen/Exit");
            m_ExitButton.UserTouchEvent = OnTouchExitButton;

            m_OptionButton = new ReleaseButton();
            m_OptionButton.Init(content, new Vector2(715, 5), 0.5f, "TitleScreen/Option");
            m_OptionButton.UserTouchEvent = OnTouchOptionButton;
        }

        private void OnTouchStartButton()
        {
            m_ScreenManager.SelectScreen(Mode.StoryScreen);
            m_ButtonSound.Play();
        }
        private void OnTouchContinueButton()
        {
            m_ScreenManager.SelectScreen(Mode.MapScreen);
            m_ButtonSound.Play();
        }
        private void OnTouchExitButton()
        {

        }
        private void OnTouchOptionButton()
        {
        }

        public override void Update(GameTime gameTime)
        {
            m_StartButton.Update(gameTime);
            m_ContinueButton.Update(gameTime);
            m_ExitButton.Update(gameTime);
            m_OptionButton.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(m_BackgroundImage, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PpuingTextureImage, new Vector2(70, 13), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PpuoooTextureImage, new Vector2(10, 43), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            DrawCharacter(spriteBatch);
            DrawButton(spriteBatch);
            spriteBatch.End();
        }
        private void DrawCharacter(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_ShadowImage, new Vector2(240, 270), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PolarBearImage, new Vector2(370, 45), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PandaImage, new Vector2(510, 80), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PpuoooImage, new Vector2(430, 118), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_AntelopeImage, new Vector2(230, 110), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_FrogImage, new Vector2(424, 239), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_RhinocerosImage, new Vector2(550, 160), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_ArmadilloImage, new Vector2(510, 310), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_TunaImage, new Vector2(600, 370), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);

            
        }
        private void DrawButton(SpriteBatch spriteBatch)
        {
            m_StartButton.Draw(spriteBatch, -0.2f);
            m_ContinueButton.Draw(spriteBatch, -0.1f);
            m_ExitButton.Draw(spriteBatch, 0);
            m_OptionButton.Draw(spriteBatch);
        }
    }
}
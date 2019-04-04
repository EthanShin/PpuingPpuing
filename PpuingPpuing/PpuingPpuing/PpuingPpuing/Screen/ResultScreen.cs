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
    class ResultScreen : IScreen
    {
        #region 변수
        Texture2D m_BackgroundImage;
        Texture2D m_PpuoooImage;
        Texture2D m_ResultImage;
        Texture2D m_LeafImage;
        Texture2D m_EmptyBeadImage;
        Texture2D m_FullBeadImage;
        Texture2D m_Success;


        int m_NumberOfLeaf;
        int m_PercentOfBead = 30;
        int tempBead = 100;

        ReleaseButton m_HomeButton;
        ReleaseButton m_OptionButton;
        ReleaseButton m_Resetbutton;

        SpriteFont m_Font;

        Texture2D m_SettingBackground;
        ReleaseButton m_SettingCancelButton;
        bool m_OpenSetting;
        #endregion

        public override void Init(ContentManager content)
        {
            m_BackgroundImage = content.Load<Texture2D>("ResultScreen/Background");

            m_PpuoooImage = content.Load<Texture2D>("ResultScreen/Ppuooo");
            m_ResultImage = content.Load<Texture2D>("ResultScreen/Result");
            m_LeafImage = content.Load<Texture2D>("ResultScreen/Leaf");
            m_EmptyBeadImage = content.Load<Texture2D>("ResultScreen/EmptyBead");
            m_FullBeadImage = content.Load<Texture2D>("ResultScreen/FullBead");
            m_Font = content.Load<SpriteFont>("ResultScreen/myFont");

            m_SettingBackground = content.Load<Texture2D>("UI/SettingBackground");
            m_SettingCancelButton = new ReleaseButton();
            m_SettingCancelButton.Init(content, new Vector2(650, 100), 0.7f, "UI/SettingCancel");
            m_SettingCancelButton.UserTouchEvent = OnTouchSettingCancelButton;

            m_Success = content.Load<Texture2D>("ResultScreen/Success");
            InitUI(content);
        }
        private void InitUI(ContentManager content)
        {
            m_HomeButton = new ReleaseButton();
            m_HomeButton.Init(content, new Vector2(5, 5), 0.5f, "UI/Home");
            m_HomeButton.UserTouchEvent = OnTouchHomeButton;

            m_OptionButton = new ReleaseButton();
            m_OptionButton.Init(content, new Vector2(715, 5), 0.5f, "UI/Option");
            m_OptionButton.UserTouchEvent = OnTouchOptionButton;

            m_Resetbutton = new ReleaseButton();
            m_Resetbutton.Init(content, new Vector2(500, 400), 0.85f, "ResultScreen/AgainMark");
            m_Resetbutton.UserTouchEvent = OnTouchResetButton;

            
        }

        #region UI버튼터치이벤트
        private void OnTouchHomeButton()
        {
            tempBead = 100;
            m_ScreenManager.SelectScreen(Mode.TitleScreen);
        }
        private void OnTouchOptionButton()
        {
        }
        private void OnTouchSettingCancelButton()
        {
        }
        private void OnTouchResetButton()
        {
            m_ScreenManager.SelectScreen(Mode.StageScreen);
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (tempBead > 100 - m_PercentOfBead)
                tempBead--;
            UpdateUI(gameTime);
        }
        private void UpdateUI(GameTime gameTime)
        {
            m_HomeButton.Update(gameTime);
            m_OptionButton.Update(gameTime);
            m_Resetbutton.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(m_BackgroundImage, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_PpuoooImage, new Vector2(150, 100), null, Color.White, 0, Vector2.Zero, 0.65f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_ResultImage, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - m_ResultImage.Width / 4, 20), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_LeafImage, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 + m_LeafImage.Width / 2, 200), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_FullBeadImage, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 + m_FullBeadImage.Width / 2, 270), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);

            spriteBatch.Draw(m_EmptyBeadImage, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 + m_EmptyBeadImage.Width / 2, 270), new Rectangle(0, 0, m_EmptyBeadImage.Width, tempBead), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_Success, new Vector2(400,100), null, Color.White, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
            spriteBatch.DrawString(m_Font, Convert.ToString(m_NumberOfLeaf), new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 + (float)(m_LeafImage.Width * 1.2), 200), Color.White);
            spriteBatch.DrawString(m_Font, Convert.ToString(100 - tempBead), new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 + (float)(m_EmptyBeadImage.Width * 1.2), 270), Color.White);
            
            DrawUI(spriteBatch);
            if (m_OpenSetting)
            {
                spriteBatch.Draw(m_SettingBackground, new Vector2(50, 50), null, Color.White, 0, Vector2.Zero, 0.43f, SpriteEffects.None, 0);
                m_SettingCancelButton.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
        private void DrawUI(SpriteBatch spriteBatch)
        {
            m_HomeButton.Draw(spriteBatch);
            m_OptionButton.Draw(spriteBatch);
            m_Resetbutton.Draw(spriteBatch);
        }
    }
}
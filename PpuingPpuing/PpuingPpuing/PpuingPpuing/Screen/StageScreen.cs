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
    class StageScreen : IScreen
    {
        #region 변수
        Texture2D m_BackgroundImage;
        Texture2D m_FriendImage;
        Texture2D m_GuideLine;

        ReleaseButton m_HomeButton;
        ReleaseButton m_OptionButton;

        ReleaseButton m_FirstStage;
        ReleaseButton m_SecondStage;
        ReleaseButton m_ThirdStage;
        ReleaseButton m_FourthStage;
        ReleaseButton m_FinalStage;

        Texture2D m_SettingBackground;
        ReleaseButton m_SettingCancelButton;

        SoundEffect m_ButtonS;
        bool m_OpenSetting;
        #endregion

        public override void Init(ContentManager content, string fieldName)
        {
            m_BackgroundImage = content.Load<Texture2D>("StageScreen/" + fieldName + "/Background");
            m_GuideLine = content.Load<Texture2D>("StageScreen/" + fieldName + "/StageGuideLine");
            m_FriendImage = content.Load<Texture2D>("StageScreen/" + fieldName + "/Uncomplete" + fieldName);

            m_SettingBackground = content.Load<Texture2D>("UI/SettingBackground");
            m_SettingCancelButton = new ReleaseButton();
            m_SettingCancelButton.Init(content, new Vector2(650, 100), 0.7f, "UI/SettingCancel");
            m_SettingCancelButton.UserTouchEvent = OnTouchSettingCancelButton;
            m_ButtonS = content.Load<SoundEffect>("Music/ButtonS");
            InitUI(content);
            InitStageButton(content, fieldName);
        }
        private void InitUI(ContentManager content)
        {
            m_HomeButton = new ReleaseButton();
            m_HomeButton.Init(content, new Vector2(5, 5), 0.5f, "UI/Home");
            m_HomeButton.UserTouchEvent = OnTouchHomeButton;

            m_OptionButton = new ReleaseButton();
            m_OptionButton.Init(content, new Vector2(715, 5), 0.5f, "UI/Option");
            m_OptionButton.UserTouchEvent = OnTouchOptionButton;
        }
        private void InitStageButton(ContentManager content, string fieldName)
        {
            m_FirstStage = new ReleaseButton();
            m_FirstStage.Init(content, new Vector2(30, 260), 0.5f, "StageScreen/" + fieldName + "/CompleteFirstStage");
            m_FirstStage.UserTouchEvent = OnTouchFirstStageButton;

            m_SecondStage = new ReleaseButton();
            m_SecondStage.Init(content, new Vector2(75, 120), 0.5f, "StageScreen/" + fieldName + "/CompleteSecondStage");
            m_SecondStage.UserTouchEvent = OnTouchSecondStageButton;

            m_ThirdStage = new ReleaseButton();
            m_ThirdStage.Init(content, new Vector2(240, 35), 0.5f, "StageScreen/" + fieldName + "/CompleteThirdStage");
            m_ThirdStage.UserTouchEvent = OnTouchThirdStageButton;

            m_FourthStage = new ReleaseButton();
            m_FourthStage.Init(content, new Vector2(280, 250), 0.5f, "StageScreen/" + fieldName + "/CompleteFourthStage");
            m_FourthStage.UserTouchEvent = OnTouchFourthStageButton;

            m_FinalStage = new ReleaseButton();
            m_FinalStage.Init(content, new Vector2(480, 40), 0.5f, "StageScreen/" + fieldName + "/CompleteFinalStage");
            m_FinalStage.UserTouchEvent = OnTouchFinalStageButton;
        }

        #region UI버튼터치이벤트
        private void OnTouchHomeButton()
        {
            m_ScreenManager.SelectScreen(Mode.TitleScreen);
            m_ButtonS.Play();
        }
        private void OnTouchOptionButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        
        #endregion
        #region Stage버튼터치이벤트

        private void OnTouchFirstStageButton()
        {
            m_ScreenManager.SelectScreen(Mode.PlayScreen, new PlayScreen(), "First");
            m_ButtonS.Play();
        }
        private void OnTouchSecondStageButton()
        {
            m_ScreenManager.SelectScreen(Mode.PlayScreen, new PlayScreen(), "Second");
            m_ButtonS.Play();
        }
        private void OnTouchThirdStageButton()
        {
            m_ScreenManager.SelectScreen(Mode.PlayScreen, new PlayScreen(), "Third");
            m_ButtonS.Play();
        }
        private void OnTouchFourthStageButton()
        {
            m_ScreenManager.SelectScreen(Mode.PlayScreen, new PlayScreen(), "Fourth");
            m_ButtonS.Play();
        }
        private void OnTouchFinalStageButton()
        {
            m_ScreenManager.SelectScreen(Mode.PlayScreen, new PlayScreen(), "Final");
            m_ButtonS.Play();
        }
        private void OnTouchSettingCancelButton()
        {
            m_OpenSetting = false;
            m_ButtonS.Play();
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            UpdateUI(gameTime);
            UpdateStageButton(gameTime);
        }
        private void UpdateUI(GameTime gameTime)
        {
            m_HomeButton.Update(gameTime);
            m_OptionButton.Update(gameTime);
        }
        private void UpdateStageButton(GameTime gameTime)
        {
            if (!m_OpenSetting)
            {
                m_FirstStage.Update(gameTime);
                m_SecondStage.Update(gameTime);
                m_ThirdStage.Update(gameTime);
                m_FourthStage.Update(gameTime);
                m_FinalStage.Update(gameTime);
            }
            else
            {
                m_SettingCancelButton.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(m_BackgroundImage, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_GuideLine, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_FriendImage, new Vector2(610, 240), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            DrawUI(spriteBatch);
            DrawStageButton(spriteBatch);
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
        }
        private void DrawStageButton(SpriteBatch spriteBatch)
        {
            m_SecondStage.Draw(spriteBatch);
            m_FirstStage.Draw(spriteBatch);
            m_ThirdStage.Draw(spriteBatch);
            m_FourthStage.Draw(spriteBatch);
            m_FinalStage.Draw(spriteBatch);
        }
    }
}

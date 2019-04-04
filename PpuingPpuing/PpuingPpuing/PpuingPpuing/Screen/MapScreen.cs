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
    class MapScreen : IScreen
    {
        #region 변수
        Texture2D m_BackgroundImage;

        ReleaseButton m_HomeButton;
        ReleaseButton m_OptionButton;

        ReleaseButton m_PolarBear;
        ReleaseButton m_Armadillo;
        ReleaseButton m_Panda;
        ReleaseButton m_Frog;
        ReleaseButton m_Rhinoceros;
        ReleaseButton m_Antelope;
        ReleaseButton m_Tuna;

        Texture2D m_SettingBackground;
        ReleaseButton m_SettingCancelButton;
        bool m_OpenSetting;

        SoundEffect m_ButtonS;
        #endregion

        public override void Init(ContentManager content)
        {
            m_BackgroundImage = content.Load<Texture2D>("MapScreen/Background");
            
            m_SettingBackground = content.Load<Texture2D>("UI/SettingBackground");
            m_SettingCancelButton = new ReleaseButton();
            m_SettingCancelButton.Init(content, new Vector2(650, 100), 0.7f, "UI/SettingCancel");
            m_SettingCancelButton.UserTouchEvent = OnTouchSettingCancelButton;
            m_ButtonS = content.Load<SoundEffect>("Music/ButtonS");
            InitUI(content);
            InitMapButton(content);
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
        private void InitMapButton(ContentManager content)
        {
            m_PolarBear = new ReleaseButton();
            m_PolarBear.Init(content, new Vector2(290, 65), 0.5f, "UI/UnLocked");
            m_PolarBear.UserTouchEvent = OnTouchPolarBearButton;

            m_Armadillo = new ReleaseButton();
            m_Armadillo.Init(content, new Vector2(230, 315), 0.5f, "UI/Locked");
            m_Armadillo.UserTouchEvent = OnTouchArmadilloButton;

            m_Panda = new ReleaseButton();
            m_Panda.Init(content, new Vector2(575, 100), 0.5f, "UI/Locked");
            m_Panda.UserTouchEvent = OnTouchPandaButton;

            m_Frog = new ReleaseButton();
            m_Frog.Init(content, new Vector2(160, 180), 0.5f, "UI/Locked");
            m_Frog.UserTouchEvent = OnTouchFrogButton;

            m_Rhinoceros = new ReleaseButton();
            m_Rhinoceros.Init(content, new Vector2(440, 180), 0.5f, "UI/Locked");
            m_Rhinoceros.UserTouchEvent = OnTouchRhinocerosButton;

            m_Antelope = new ReleaseButton();
            m_Antelope.Init(content, new Vector2(400, 290), 0.5f, "UI/Locked");
            m_Antelope.UserTouchEvent = OnTouchAntelopeButton;

            m_Tuna = new ReleaseButton();
            m_Tuna.Init(content, new Vector2(650, 350), 0.5f, "UI/Locked");
            m_Tuna.UserTouchEvent = OnTouchTunaButton;
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
        #region Map버튼터치이벤트
        private void OnTouchPolarBearButton()
        {
            m_ScreenManager.SelectScreen(Mode.StageScreen, new StageScreen(),  "PolarBear");
            m_ButtonS.Play();
        }
        private void OnTouchArmadilloButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        private void OnTouchPandaButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        private void OnTouchFrogButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        private void OnTouchRhinocerosButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        private void OnTouchAntelopeButton()
        {
            m_OpenSetting = true;
            m_ButtonS.Play();
        }
        private void OnTouchTunaButton()
        {
            m_OpenSetting = true;
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
            UpdateMapButton(gameTime);
        }
        private void UpdateUI(GameTime gameTime)
        {
            m_HomeButton.Update(gameTime);
            m_OptionButton.Update(gameTime);
        }
        private void UpdateMapButton(GameTime gameTime)
        {
            if (!m_OpenSetting)
            {
                m_PolarBear.Update(gameTime);
                m_Armadillo.Update(gameTime);
                m_Panda.Update(gameTime);
                m_Frog.Update(gameTime);
                m_Rhinoceros.Update(gameTime);
                m_Antelope.Update(gameTime);
                m_Tuna.Update(gameTime);
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
            DrawUI(spriteBatch);
            DrawMapButton(spriteBatch);
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
        private void DrawMapButton(SpriteBatch spriteBatch)
        {
            m_PolarBear.Draw(spriteBatch);
            m_Armadillo.Draw(spriteBatch);
            m_Panda.Draw(spriteBatch);
            m_Frog.Draw(spriteBatch);
            m_Rhinoceros.Draw(spriteBatch);
            m_Antelope.Draw(spriteBatch);
            m_Tuna.Draw(spriteBatch);
        }
    }
}

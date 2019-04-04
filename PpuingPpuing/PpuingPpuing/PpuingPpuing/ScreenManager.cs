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
    public enum Mode
    {
        TitleScreen, StoryScreen, MapScreen, StageScreen, PlayScreen, FailResultScreen, ResultScreen,
    }

    class ScreenManager
    {
        Dictionary<Mode, IScreen> m_DicScreen = new Dictionary<Mode, IScreen>();

        IScreen m_ActiveScreen = null;

        ContentManager m_Content;

        StageManager m_StageManager = new StageManager();

        string m_MapName;

        public void AddScreen(Mode mode, IScreen screen, ContentManager content)
        {
            m_Content = content;
            screen.Init(content);
           m_DicScreen.Add(mode, screen);
           //// var Titlemusic = content.Load<Song>("Music/TitleMusic");
           // if (mode == Mode.TitleScreen)
           // {
           //    // var Titlemusic = content.Load<Song>("Music/TitleMusic");
           ////     MediaPlayer.Play(Titlemusic);
           ////   MediaPlayer.IsRepeating = true;
           // }
           // //else if (mode != Mode.TitleScreen)
           // //{
           // //    MediaPlayer.Stop(Titlemusic);
           // //}

           // else if (mode == Mode.PlayScreen)
           // {

           //     MediaPlayer.Stop();
           //    var PlayBGM = content.Load<Song>("Music/PlayBGM");
           //    MediaPlayer.Play(PlayBGM);
           // }
        }

        public IScreen GetScreen(Mode mode)
        {
            return m_DicScreen[mode];
        }

        public void Update(GameTime gameTime)
        {
            if (m_ActiveScreen != null)
                m_ActiveScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (m_ActiveScreen != null)
                m_ActiveScreen.Draw(spriteBatch);
        }

        public void SelectScreen(Mode mode)
        {
            m_ActiveScreen = m_DicScreen[mode];
        }
        public void SelectScreen(Mode mode, IScreen screen, string fieldName)
        {
            m_DicScreen.Remove(mode);
            if (mode == Mode.StageScreen)
            {
                m_MapName = fieldName;
                screen.Init(m_Content, fieldName);
            }
            else if (mode == Mode.PlayScreen)
            {
                var scenario = m_StageManager.SelectStage(m_MapName, fieldName);
                screen.Init(m_Content, m_MapName, fieldName, scenario);
            }
            m_DicScreen.Add(mode, screen);
            m_ActiveScreen = m_DicScreen[mode];
        }
    }
}
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
    class ReleaseButton
    {
        #region 변수
        protected Texture2D m_ReleaseButtonImage;
        protected Vector2 m_Position;
        protected float m_scale = 1f;
        Rectangle m_ReleaseButtonArea;

        public delegate void TouchEvent();
        public TouchEvent UserTouchEvent;

        bool isTouch;
        #endregion

        public void Init(ContentManager content, Vector2 position, string ImageName)
        {
            m_ReleaseButtonImage = content.Load<Texture2D>(ImageName);
            m_Position = position;

            m_ReleaseButtonArea = new Rectangle((int)position.X, (int)position.Y, (int)(m_ReleaseButtonImage.Width), (int)(m_ReleaseButtonImage.Height));
        }
        public void Init(ContentManager content, Vector2 position, float scale, string ImageName)
        {
            m_ReleaseButtonImage = content.Load<Texture2D>(ImageName);
            m_Position = position;
            m_scale = scale;

            m_ReleaseButtonArea = new Rectangle((int)position.X, (int)position.Y, (int)(m_ReleaseButtonImage.Width * scale), (int)(m_ReleaseButtonImage.Height * scale));
        }

        private bool isPressOnce;
        private int m_TouchID = -1;

        public void Update(GameTime gameTime)
        {
            var touchState = TouchDevice.GetState();

            for (var i = 0; i < touchState.Count; i++)
            {
                var touchID = touchState[i].ID;
                var posX = touchState[i].Position.X;
                var posY = touchState[i].Position.Y;

                if (touchState[i].State == TouchDevice.State.PressAndMove && m_TouchID == -1)
                {
                    m_TouchID = touchID;

                    if (isPressOnce == false)
                    {
                        isPressOnce = true;

                        if (m_ReleaseButtonArea.Contains((int)posX, (int)posY))
                        {
                            isTouch = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (m_TouchID == touchID && touchState[i].State == TouchDevice.State.Released)
                    {
                        if (isTouch && m_ReleaseButtonArea.Contains((int)posX, (int)posY))
                        {
                            if (UserTouchEvent != null)
                                UserTouchEvent();

                        }
                        m_TouchID = -1;

                       isTouch = false;
                       isPressOnce = false;
                       break;
                    }
                }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_ReleaseButtonImage, m_Position, null, isTouch ? Color.Green : Color.White, 0, Vector2.Zero, m_scale, SpriteEffects.None, 0);
        }
        public virtual void Draw(SpriteBatch spriteBatch, float rotation)
        {
            spriteBatch.Draw(m_ReleaseButtonImage, m_Position, null, isTouch ? Color.Green : Color.White, rotation, Vector2.Zero, m_scale, SpriteEffects.None, 0);
        }
    }
}

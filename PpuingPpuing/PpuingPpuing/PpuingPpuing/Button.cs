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
    class Button
    {
        #region 변수
        protected Texture2D m_ButtonImage;
        protected Vector2 m_Position;
        protected float m_scale = 1f;
        Rectangle m_ButtonArea;

        public delegate void TouchEvent();
        public TouchEvent UserTouchEvent;

        bool isTouch;
        #endregion

        public void Init(ContentManager content, Vector2 position, string ImageName)
        {
            m_ButtonImage = content.Load<Texture2D>(ImageName);
            m_Position = position;

            m_ButtonArea = new Rectangle((int)position.X - 10, (int)position.Y -10, (int)(m_ButtonImage.Width) + 20, (int)(m_ButtonImage.Height) + 20);
        }
        public void Init(ContentManager content, Vector2 position, float scale, string ImageName)
        {
            m_ButtonImage = content.Load<Texture2D>(ImageName);
            m_Position = position;
            m_scale = scale;

            m_ButtonArea = new Rectangle((int)position.X - 10 , (int)position.Y - 10, (int)(m_ButtonImage.Width * scale) + 20, (int)(m_ButtonImage.Height * scale) + 20);
        }
        public void Update(GameTime gameTime)
        {
            var touchState = TouchDevice.GetState();

            for (var i = 0; i < touchState.Count; i++)
            {
                if (touchState[i].State == TouchDevice.State.PressAndMove)
                {
                    var touchID = touchState[i].ID;
                    var posX = touchState[i].Position.X;
                    var posY = touchState[i].Position.Y;

                    if (m_ButtonArea.Contains((int)posX, (int)posY))
                    {
                        isTouch = true;
                        if (UserTouchEvent != null)
                        {
                            UserTouchEvent();
                            break;
                        }
                    }
                }
                else
                {
                    if (touchState[i].State == TouchDevice.State.Released)
                    {
                       isTouch = false;
                       break;
                    }
                }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_ButtonImage, m_Position, null, isTouch ? Color.Green : Color.White, 0, Vector2.Zero, m_scale, SpriteEffects.None, 0);
        }
        public virtual void Draw(SpriteBatch spriteBatch, float rotation)
        {
            spriteBatch.Draw(m_ButtonImage, m_Position, null, isTouch ? Color.Green : Color.White, rotation, Vector2.Zero, m_scale, SpriteEffects.None, 0);
        }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(m_ButtonImage, m_Position, null, isTouch ? Color.Green : color, 0, Vector2.Zero, m_scale, SpriteEffects.None, 0);
        }
    }
}

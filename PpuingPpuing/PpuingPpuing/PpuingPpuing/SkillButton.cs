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
    class SkillButton
    {
        #region 변수
        protected Texture2D m_SkillButtonImage;
        protected Texture2D m_PpuoooButtonImage;
        protected Texture2D m_FirstButtonImage;
        protected Texture2D m_SecondButtonImage;
        Rectangle m_SkillButtonArea;
        Rectangle m_PpuoooButtonArea;
        Rectangle m_FirstButtonArea;
        Rectangle m_SecondButtonArea;

        protected Vector2 m_Position;
        protected float m_scale = 1f;

        public delegate void TouchEvent();
        public TouchEvent UserTouchEvent;

        public bool isTouch;
        public int selectSkill;
        #endregion

        public void Init(ContentManager content, Vector2 position, float scale, string firstImageName, string secondImageName)
        {
            m_SkillButtonImage = content.Load<Texture2D>("PlayScreen/Control/SkillButton");
            m_PpuoooButtonImage = content.Load<Texture2D>("PlayScreen/SkillImage/PpuoooSkill");
            m_FirstButtonImage = content.Load<Texture2D>("PlayScreen/SkillImage/" + firstImageName);
            m_SecondButtonImage = content.Load<Texture2D>("PlayScreen/SkillImage/" + secondImageName);

            m_Position = position;
            m_scale = scale;

            m_SkillButtonArea = new Rectangle((int)position.X - 10, (int)position.Y - 10, (int)((m_SkillButtonImage.Width) * scale) + 20, (int)((m_SkillButtonImage.Height) * scale) + 20);
            m_PpuoooButtonArea = new Rectangle((int)position.X - 10, (int)position.Y - 10, (int)((m_SkillButtonImage.Width) * scale) + 20, (int)((m_SkillButtonImage.Height) * scale) + 20);
            m_FirstButtonArea = new Rectangle((int)position.X - 10, (int)position.Y - 110, (int)((m_SkillButtonImage.Width) * scale) + 20, (int)((m_SkillButtonImage.Height) * scale) + 20);
            m_SecondButtonArea = new Rectangle((int)position.X - 90, (int)position.Y - 10, (int)((m_SkillButtonImage.Width) * scale) + 20, (int)((m_SkillButtonImage.Height) * scale) + 20);
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

                        if (m_SkillButtonArea.Contains((int)posX, (int)posY))
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
                        if (isTouch && m_PpuoooButtonArea.Contains((int)posX, (int)posY))
                        {
                            selectSkill = 0;
                            if (UserTouchEvent != null)
                                UserTouchEvent();
                        }
                        else if (isTouch && m_FirstButtonArea.Contains((int)posX, (int)posY))
                        {
                            selectSkill = 1;
                            if (UserTouchEvent != null)
                                UserTouchEvent();
                        }
                        else if (isTouch && m_SecondButtonArea.Contains((int)posX, (int)posY))
                        {
                            selectSkill = 2;
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
            if (!isTouch)
            {
                spriteBatch.Draw(m_SkillButtonImage, m_Position, null, Color.White, 0, Vector2.Zero, m_scale, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(m_PpuoooButtonImage, new Vector2((int)m_Position.X - 10, (int)m_Position.Y - 10), null, new Color(127, 127, 127, 127), 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0);
                spriteBatch.Draw(m_FirstButtonImage, new Vector2((int)m_Position.X - 10, (int)m_Position.Y - 110), null, new Color(127, 127, 127, 127), 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0);
                spriteBatch.Draw(m_SecondButtonImage, new Vector2((int)m_Position.X - 90, (int)m_Position.Y - 10), null, new Color(127, 127, 127, 127), 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0);
            }
        }
    }
}

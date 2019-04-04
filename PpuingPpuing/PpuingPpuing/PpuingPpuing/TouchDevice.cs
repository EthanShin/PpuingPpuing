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
    static public class TouchDevice
    {
        public struct TouchEvent
        {
            public int ID;
            public Vector2 Position;
            public State State;
        }

        public enum State { Invalid = 0, PressAndMove, Released };

        static List<TouchEvent> m_OldTouchList = new List<TouchEvent>();

        public static List<TouchEvent> GetState()
        {
            var touchList = new List<TouchEvent>();

            ProcessTouch(touchList);

            CheckReleaseEvent(touchList);

            return touchList;
        }

        private static void ProcessTouch(List<TouchEvent> touchList)
        {
            var touchState = TouchPanel.GetState();

            for (var i = 0; i < touchState.Count; i++)
            {
                var myTouch = new TouchEvent();

                if (touchState[i].State == TouchLocationState.Pressed || touchState[i].State == TouchLocationState.Moved)
                {
                    myTouch.State = State.PressAndMove;

                    myTouch.ID = touchState[i].Id;
                    myTouch.Position = touchState[i].Position;

                    m_OldTouchList.Add(myTouch);
                    touchList.Add(myTouch);
                }
            }
        }

        private static void CheckReleaseEvent(List<TouchEvent> touchEventList)
        {
            for (var i = m_OldTouchList.Count - 1; i >= 0; i--)
            {
                var id = m_OldTouchList[i].ID;

                var isFindTouchID = false;

                for (var s = 0; s < touchEventList.Count; s++)
                {
                    if (touchEventList[s].ID == id)
                    {
                        isFindTouchID = true;
                    }
                }

                if (isFindTouchID == false)
                {
                    var touch = new TouchEvent();
                    touch.ID = id;
                    touch.State = State.Released;
                    touch.Position = m_OldTouchList[i].Position;

                    touchEventList.Add(touch);
                    m_OldTouchList.RemoveAt(i);
                }
            }
        }

        public static void StateClear()
        {
            m_OldTouchList.Clear();
        }
    }
}

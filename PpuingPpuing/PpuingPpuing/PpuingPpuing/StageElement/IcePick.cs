﻿using System;
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
    class IcePick
    {
        Vector2 m_IcePickPosition;

        public bool m_IsTouching
        {
            get;
            set;
        }
        public void Init(Vector2 position)
        {
           m_IcePickPosition = position;
        }
        public Vector2 getPosition()
        {
            return m_IcePickPosition;
        }
    }
}

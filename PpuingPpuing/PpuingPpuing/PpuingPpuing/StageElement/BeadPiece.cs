using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class BeadPiece
    {
        Vector2 m_BeadPiecePosition;

        public bool m_IsTouching
        {
            get;
            set;
        }
        public void Init(Vector2 position)
        {
            m_BeadPiecePosition = position;
        }
        public Vector2 getPosition()
        {
            return m_BeadPiecePosition;
        }
    }
}

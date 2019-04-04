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
    class EnemyBoss
    {
        Vector2 m_EnemyBossPosition;
        int m_LeftPoint;
        int m_RightPoint;
        int m_Health = 30;
        int m_Power = 10;
        public bool m_IsAttacked
        {
            get;
            set;
        }
        public bool m_IsAttacking
        {
            get;
            set;
        }
        public bool m_IsDead;
        public bool m_IsRight;

        public void Init(Vector2 position, int leftPoint, int rightPoint)
        {
            m_EnemyBossPosition = position;
            m_LeftPoint = leftPoint;
            m_RightPoint = rightPoint;
        }
        public Vector2 getPosition()
        {
            return m_EnemyBossPosition;
        }
        public int LeftPosition()
        {
            return m_LeftPoint;
        }
        public int RightPosition()
        {
            return m_RightPoint;
        }

        public void EnemyMoving()
        {
            if (!m_IsRight)
            {
                if (m_LeftPoint < m_EnemyBossPosition.X)
                    m_EnemyBossPosition.X -= 10;
                else
                    m_IsRight = true;
            }
            else
            {
                if (m_EnemyBossPosition.X < m_RightPoint)
                    m_EnemyBossPosition.X += 10;
                else
                    m_IsRight = false;
            }
        }
        public void DecreaseHealth(int PpuoooPower)
        {
            m_Health -= PpuoooPower;
            if (m_Health <= 0)
            {
                m_IsDead = true;
            }
            m_EnemyBossPosition.X += 50;
        }
        public int getEnemyPower()
        {
            return m_Power;
        }
    }
}

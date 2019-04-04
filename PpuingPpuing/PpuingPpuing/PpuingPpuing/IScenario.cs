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
    class IScenario
    {    
        static protected int firstFloor = 370;
        static protected int secondFloor = 325;
        static protected int thirdFloor = 280;
        static protected int fourthFloor = 235;
        static protected int fifthFloor = 190;
        static protected int sixthFloor = 145;
        static protected int seventhFloor = 100;
        static protected int eightthFloor = 55;
        static protected int ninethFloor = 10;
        static protected int tenthFloor = -35;
        
        static public double tileSize = 0.35; 
        protected int m_StageSize;
        protected int[] m_StageTile;

        List<Enemy> m_EnemyList = new List<Enemy>();
        List<IcePick> m_IcePickList = new List<IcePick>();
        List<SnowFall> m_SnowFallList = new List<SnowFall>();
        List<LeafPiece> m_LeafPList = new List<LeafPiece>();
        List<BeadPiece> m_BeadPList = new List<BeadPiece>();
        List<IceFall> m_IceFallList = new List<IceFall>();
        List<EnemyBoss> m_EnemyBossList = new List<EnemyBoss>();
        //EnemyBoss m_EnemyBoss = new EnemyBoss();
        public List<BGM> m_Song = new List<BGM>();

        public virtual void Init() { }
        public virtual int GetSize() { return m_StageSize; }
        public virtual int[] GetTile() { return m_StageTile; }
        public virtual List<Enemy> GetEnemy() { return m_EnemyList; }
        public virtual List<IcePick> GetIcePick() { return m_IcePickList; }
        public virtual List<SnowFall> GetSnowFall() { return m_SnowFallList; }
        public virtual List<BeadPiece> GetBeadPiece() { return m_BeadPList; }
        public virtual List<LeafPiece> GetLeafPiece() { return m_LeafPList; }
        public virtual List<IceFall> GetIceFall() { return m_IceFallList; }
        
        public virtual List<BGM> GetBGM() { return m_Song; }
        public virtual List<EnemyBoss> GetBoss() { return m_EnemyBossList; }
    }
}

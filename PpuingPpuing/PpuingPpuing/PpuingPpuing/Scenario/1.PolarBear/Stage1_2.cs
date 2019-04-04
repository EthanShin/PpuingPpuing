using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PpuingPpuing
{
    class Stage1_2 : IScenario
    {
        int[] m_tile = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 5, 1, 3, 3, 2, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 1, 3, 3, 3, 3, 3, 2, 0, 1, 3, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 
                       };

        public override void Init()
        {
            m_StageSize = (int)((m_tile.Length / 10 - (int)(800 / (283 * tileSize) + 1)) * 283 * tileSize);
            m_StageTile = m_tile;

            IcePick m_IcePick = new IcePick();
            m_IcePick.Init(new Vector2(900, secondFloor));
            m_IcePickList.Add(m_IcePick);

            IcePick m_IcePick1 = new IcePick();
            m_IcePick1.Init(new Vector2(700,secondFloor));
            m_IcePickList.Add(m_IcePick1);

            IcePick m_IcePick2 = new IcePick();
            m_IcePick2.Init(new Vector2(5300,secondFloor));
            m_IcePickList.Add(m_IcePick2);

            IcePick m_IcePick3 = new IcePick();
            m_IcePick3.Init(new Vector2(3050, secondFloor));
            m_IcePickList.Add(m_IcePick3);

            IcePick m_IcePick4 = new IcePick();
            m_IcePick4.Init(new Vector2(2600,thirdFloor));
            m_IcePickList.Add(m_IcePick4);

            LeafPiece m_LeafPiece = new LeafPiece();
            m_LeafPiece.Init(new Vector2(1000, secondFloor));
            m_LeafPList.Add(m_LeafPiece);

            LeafPiece m_LeafPiece1 = new LeafPiece();
            m_LeafPiece1.Init(new Vector2(2200, secondFloor));
            m_LeafPList.Add(m_LeafPiece1);

            LeafPiece m_LeafPiece2 = new LeafPiece();
            m_LeafPiece2.Init(new Vector2(1100, secondFloor));
            m_LeafPList.Add(m_LeafPiece2);

            LeafPiece m_LeafPiece3 = new LeafPiece();
            m_LeafPiece3.Init(new Vector2(5600, secondFloor));
            m_LeafPList.Add(m_LeafPiece3);

            LeafPiece m_LeafPiece4 = new LeafPiece();
            m_LeafPiece4.Init(new Vector2(3800, secondFloor));
            m_LeafPList.Add(m_LeafPiece4);

            BeadPiece m_BeadPiece = new BeadPiece();
            m_BeadPiece.Init(new Vector2(4470,fourthFloor));
            m_BeadPList.Add(m_BeadPiece);

            BeadPiece m_BeadPiece1 = new BeadPiece();
            m_BeadPiece1.Init(new Vector2(2100, secondFloor));
            m_BeadPList.Add(m_BeadPiece1);

            Enemy m_Enemy = new Enemy();
            m_Enemy.Init(new Vector2(500, thirdFloor), 400, 600);
            m_EnemyList.Add(m_Enemy);

            Enemy m_Enemy1 = new Enemy();
            m_Enemy1.Init(new Vector2(2150, thirdFloor), 2100, 2150);
            m_EnemyList.Add(m_Enemy1);

            Enemy m_Enemy2 = new Enemy();
            m_Enemy2.Init(new Vector2(3800, thirdFloor), 3700, 3800);
            m_EnemyList.Add(m_Enemy2);

            Enemy m_Enemy3 = new Enemy();
            m_Enemy3.Init(new Vector2(5600, thirdFloor), 5600, 5700);
            m_EnemyList.Add(m_Enemy3);

            Enemy m_Enemy4 = new Enemy();
            m_Enemy4.Init(new Vector2(5800, thirdFloor), 5800, 5900);
            m_EnemyList.Add(m_Enemy4);

            
            SnowFall m_SnowFall1 = new SnowFall();
            m_SnowFall1.Init(new Vector2(4430, thirdFloor));
            m_SnowFallList.Add(m_SnowFall1);
        }
        public override int GetSize()
        {
            return m_StageSize;
        }
        public override int[] GetTile()
        {
            return m_StageTile;
        }

        List<IcePick> m_IcePickList = new List<IcePick>();
        List<Enemy> m_EnemyList = new List<Enemy>();
        List<SnowFall> m_SnowFallList = new List<SnowFall>();
        List<LeafPiece> m_LeafPList = new List<LeafPiece>();
        List<BeadPiece> m_BeadPList = new List<BeadPiece>();

        public override List<IcePick> GetIcePick()
        {
            return m_IcePickList;
        }
        public override List<Enemy> GetEnemy()
        {
            return m_EnemyList;
        }
        public override List<SnowFall> GetSnowFall()
        {
            return m_SnowFallList;
        }
      
        public override List<LeafPiece> GetLeafPiece()
        {
            return m_LeafPList;
        }
        public override List<BeadPiece> GetBeadPiece()
        {
            return m_BeadPList;
        }
    }
}

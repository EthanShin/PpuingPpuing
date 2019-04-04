using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PpuingPpuing
{
    class Stage1_3 : IScenario
    {
        int[] m_tile = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         1, 3, 3, 3, 2, 0, 0, 0, 0, 0, 1, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 2, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 1, 3, 3, 3, 2, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3,
                         0, 0, 0, 0, 0, 0, 1, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 
                       };

        public override void Init()
        {
            m_StageSize = (int)((m_tile.Length / 10 - (int)(800 / (283 * tileSize) + 1)) * 283 * tileSize);
            m_StageTile = m_tile;

            IcePick m_IcePick = new IcePick();
            m_IcePick.Init(new Vector2(1200, secondFloor));
            m_IcePickList.Add(m_IcePick);

            IcePick m_IcePick1 = new IcePick();
            m_IcePick1.Init(new Vector2(2400, secondFloor));
            m_IcePickList.Add(m_IcePick1);

            IcePick m_IcePick2 = new IcePick();
            m_IcePick2.Init(new Vector2(3550, thirdFloor));
            m_IcePickList.Add(m_IcePick2);

            IcePick m_icepick3 = new IcePick();
            m_icepick3.Init(new Vector2(3575, thirdFloor));
            m_IcePickList.Add(m_icepick3);

            IcePick m_IcePick4 = new IcePick();
            m_IcePick4.Init(new Vector2(3600, thirdFloor));
            m_IcePickList.Add(m_IcePick4);

            IcePick m_IcePick5 = new IcePick();
            m_IcePick5.Init(new Vector2(4425, secondFloor));
            m_IcePickList.Add(m_IcePick5);

            IcePick m_IcePick6 = new IcePick();
            m_IcePick6.Init(new Vector2(5875, thirdFloor));
            m_IcePickList.Add(m_IcePick6);

            LeafPiece m_LeafPiece = new LeafPiece();
            m_LeafPiece.Init(new Vector2(200, secondFloor));
            m_LeafPList.Add(m_LeafPiece);

            LeafPiece m_LeafPiece1 = new LeafPiece();
            m_LeafPiece1.Init(new Vector2(800, secondFloor));
            m_LeafPList.Add(m_LeafPiece1);

            LeafPiece m_LeafPiece2 = new LeafPiece();
            m_LeafPiece2.Init(new Vector2(1100, secondFloor));
            m_LeafPList.Add(m_LeafPiece2);

            LeafPiece m_LeafPiece3 = new LeafPiece();
            m_LeafPiece3.Init(new Vector2(1300, secondFloor));
            m_LeafPList.Add(m_LeafPiece3);

            LeafPiece m_LeafPiece4 = new LeafPiece();
            m_LeafPiece4.Init(new Vector2(2200, secondFloor));
            m_LeafPList.Add(m_LeafPiece4);

            LeafPiece m_LeafPiece5 = new LeafPiece();
            m_LeafPiece5.Init(new Vector2(2300, secondFloor));
            m_LeafPList.Add(m_LeafPiece5);

            LeafPiece m_LeafPiece6 = new LeafPiece();
            m_LeafPiece6.Init(new Vector2(3800, secondFloor));
            m_LeafPList.Add(m_LeafPiece6);

            LeafPiece m_LeafPiece7 = new LeafPiece();
            m_LeafPiece7.Init(new Vector2(3900, secondFloor));
            m_LeafPList.Add(m_LeafPiece7);

          

          

            LeafPiece m_LeafPiece10 = new LeafPiece();
            m_LeafPiece10.Init(new Vector2(3575,fifthFloor));
            m_LeafPList.Add(m_LeafPiece10);

            LeafPiece m_LeafPiece14 = new LeafPiece();
            m_LeafPiece14.Init(new Vector2(4100, secondFloor));
            m_LeafPList.Add(m_LeafPiece14);

            LeafPiece m_LeafPiece12 = new LeafPiece();
            m_LeafPiece12.Init(new Vector2(7300, secondFloor));
            m_LeafPList.Add(m_LeafPiece12);

            LeafPiece m_LeafPiece13 = new LeafPiece();
            m_LeafPiece13.Init(new Vector2(6900, secondFloor));
            m_LeafPList.Add(m_LeafPiece13);

            LeafPiece m_LeafPiece8 = new LeafPiece();
            m_LeafPiece8.Init(new Vector2(5000, secondFloor));
            m_LeafPList.Add(m_LeafPiece8);

            

            LeafPiece m_LeafPiece11 = new LeafPiece();
            m_LeafPiece11.Init(new Vector2(5900, fourthFloor));
            m_LeafPList.Add(m_LeafPiece11);

            LeafPiece m_LeafPiece9 = new LeafPiece();
            m_LeafPiece9.Init(new Vector2(6600, fourthFloor));
            m_LeafPList.Add(m_LeafPiece9);

            //BeadPiece m_BeadPiece = new BeadPiece();
            //m_BeadPiece.Init(new Vector2(1500, secondFloor));
            //m_BeadPList.Add(m_BeadPiece);

            BeadPiece m_BeadPiece1 = new BeadPiece();
            m_BeadPiece1.Init(new Vector2(3575, fourthFloor));
            m_BeadPList.Add(m_BeadPiece1);

            BeadPiece m_BeadPiece2 = new BeadPiece();
            m_BeadPiece2.Init(new Vector2(3575, secondFloor));
            m_BeadPList.Add(m_BeadPiece2);

            BeadPiece m_BeadPiece3 = new BeadPiece();
            m_BeadPiece3.Init(new Vector2(7150, secondFloor));
            m_BeadPList.Add(m_BeadPiece3);

            SnowFall m_SnowFall2 = new SnowFall();
            m_SnowFall2.Init(new Vector2(2750, firstFloor));
            m_SnowFallList.Add(m_SnowFall2);

            SnowFall m_SnowFall1 = new SnowFall();
            m_SnowFall1.Init(new Vector2(4040, firstFloor));
            m_SnowFallList.Add(m_SnowFall1);

            Enemy m_Enemy = new Enemy();
            m_Enemy.Init(new Vector2(1900, fourthFloor), 1800, 1850);
            m_Enemylist.Add(m_Enemy);

            Enemy m_Enemy1 = new Enemy();
            m_Enemy1.Init(new Vector2(2100, fourthFloor), 1950, 2100);
            m_Enemylist.Add(m_Enemy1);

            Enemy m_Enemy2 = new Enemy();
            m_Enemy2.Init(new Vector2(6100, fourthFloor), 6100, 6200);
            m_Enemylist.Add(m_Enemy2);

            Enemy m_Enemy3 = new Enemy();
            m_Enemy3.Init(new Vector2(7100, thirdFloor), 7100, 7150);
            m_Enemylist.Add(m_Enemy3);

            Enemy m_Enemy4 = new Enemy();
            m_Enemy4.Init(new Vector2(7200, thirdFloor), 7200, 7300);
            m_Enemylist.Add(m_Enemy4);
        }
        public override int GetSize()
        {
            return m_StageSize;
        }
        public override int[] GetTile()
        {
            return m_StageTile;
        }

        List<Enemy> m_Enemylist = new List<Enemy>();
        List<LeafPiece> m_LeafPList = new List<LeafPiece>();
        List<BeadPiece> m_BeadPList = new List<BeadPiece>();
        List<IcePick> m_IcePickList = new List<IcePick>();
        List<SnowFall> m_SnowFallList = new List<SnowFall>();

        public override List<Enemy> GetEnemy()
        {
            return m_Enemylist;
        }
        public override List<IcePick> GetIcePick()
        {
            return m_IcePickList;
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

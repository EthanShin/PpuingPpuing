using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PpuingPpuing
{
    class Stage1_4 : IScenario
    {
        int[] m_tile = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         1, 3, 3, 3, 2, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0, 1, 3, 3, 3, 2, 0, 1, 3, 2, 0, 1, 3, 3, 2, 0, 1, 2, 0, 1, 2, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 0, 0, 0, 0, 0, 1, 3, 3, 3, 3, 2, 0, 1, 3, 3, 3, 3, 3, 3, 3, 3, 2, 0, 1, 2, 0, 0, 0, 0, 1, 2, 0, 1, 3, 3, 3, 3, 2, 0, 1, 2, 0, 1, 2, 0, 1, 3, 3, 3, 3, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 3, 3, 3, 2, 0, 0, 0, 0, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 
                       };

        public override void Init()
        {
            m_StageSize = (int)((m_tile.Length / 10 - (int)(800 / (283 * tileSize) + 1)) * 283 * tileSize);
            m_StageTile = m_tile;

            IcePick m_IcePick = new IcePick();
            m_IcePick.Init(new Vector2(300, secondFloor));
            m_IcePickList.Add(m_IcePick);

            IcePick m_IcePick1 = new IcePick();
            m_IcePick1.Init(new Vector2(2500, secondFloor));
            m_IcePickList.Add(m_IcePick1);

            IcePick m_IcePick2 = new IcePick();
            m_IcePick2.Init(new Vector2(4300, secondFloor));
            m_IcePickList.Add(m_IcePick2);

            IcePick m_IcePick3 = new IcePick();
            m_IcePick3.Init(new Vector2(5525, secondFloor));
            m_IcePickList.Add(m_IcePick3);

            IcePick m_IcePick4 = new IcePick();
            m_IcePick4.Init(new Vector2(5650, secondFloor));
            m_IcePickList.Add(m_IcePick4);

            IcePick m_IcePick5 = new IcePick();
            m_IcePick5.Init(new Vector2(5775, secondFloor));
            m_IcePickList.Add(m_IcePick5);

            IcePick m_IcePick6 = new IcePick();
            m_IcePick6.Init(new Vector2(9100, secondFloor));
            m_IcePickList.Add(m_IcePick6);

            IcePick m_IcePick7 = new IcePick();
            m_IcePick7.Init(new Vector2(9500, secondFloor));
            m_IcePickList.Add(m_IcePick7);

            IcePick m_IcePick8 = new IcePick();
            m_IcePick8.Init(new Vector2(9700, secondFloor));
            m_IcePickList.Add(m_IcePick8);

            IcePick m_IcePick9 = new IcePick();
            m_IcePick9.Init(new Vector2(10380, secondFloor));
            m_IcePickList.Add(m_IcePick9);

            IcePick m_IcePick10 = new IcePick();
            m_IcePick10.Init(new Vector2(11500, secondFloor));
            m_IcePickList.Add(m_IcePick10);

            IcePick m_IcePick11 = new IcePick();
            m_IcePick11.Init(new Vector2(6230, secondFloor));
            m_IcePickList.Add(m_IcePick11);

            IcePick m_IcePick12 = new IcePick();
            m_IcePick12.Init(new Vector2(6260, secondFloor));
            m_IcePickList.Add(m_IcePick12);

            IcePick m_IcePick13 = new IcePick();
            m_IcePick13.Init(new Vector2(6290, secondFloor));
            m_IcePickList.Add(m_IcePick13);

            IcePick m_IcePick14 = new IcePick();
            m_IcePick14.Init(new Vector2(6320, secondFloor));
            m_IcePickList.Add(m_IcePick14);

            IcePick m_IcePick15 = new IcePick();
            m_IcePick15.Init(new Vector2(6350, secondFloor));
            m_IcePickList.Add(m_IcePick15);

            IcePick m_IcePick16 = new IcePick();
            m_IcePick16.Init(new Vector2(6380, secondFloor));
            m_IcePickList.Add(m_IcePick16);

            IcePick m_IcePick17 = new IcePick();
            m_IcePick17.Init(new Vector2(6410, secondFloor));
            m_IcePickList.Add(m_IcePick17);

            IcePick m_IcePick18 = new IcePick();
            m_IcePick18.Init(new Vector2(6440, secondFloor));
            m_IcePickList.Add(m_IcePick18);

            IcePick m_IcePick19 = new IcePick();
            m_IcePick19.Init(new Vector2(6470, secondFloor));
            m_IcePickList.Add(m_IcePick19);

            IcePick m_IcePick20 = new IcePick();
            m_IcePick20.Init(new Vector2(6500, secondFloor));
            m_IcePickList.Add(m_IcePick20);

            IcePick m_IcePick21 = new IcePick();
            m_IcePick21.Init(new Vector2(6530, secondFloor));
            m_IcePickList.Add(m_IcePick21);


            BeadPiece m_BeadPiece = new BeadPiece();
            m_BeadPiece.Init(new Vector2(9100, firstFloor));
            m_BeadPList.Add(m_BeadPiece);

            BeadPiece m_BeadPiece1 = new BeadPiece();
            m_BeadPiece1.Init(new Vector2(13000, secondFloor));
            m_BeadPList.Add(m_BeadPiece1);

            BeadPiece m_BeadPiece2 = new BeadPiece();
            m_BeadPiece2.Init(new Vector2(13500, secondFloor));
            m_BeadPList.Add(m_BeadPiece2);

            BeadPiece m_BeadPiece3 = new BeadPiece();
            m_BeadPiece3.Init(new Vector2(6300, firstFloor));
            m_BeadPList.Add(m_BeadPiece3);

          

            LeafPiece m_LeafPiece = new LeafPiece();
            m_LeafPiece.Init(new Vector2(1200,secondFloor));
            m_LeafPList.Add(m_LeafPiece);

            LeafPiece m_LeafPiece1 = new LeafPiece();
            m_LeafPiece1.Init(new Vector2(2200, secondFloor));
            m_LeafPList.Add(m_LeafPiece1);

            LeafPiece m_LeafPiece2 = new LeafPiece();
            m_LeafPiece2.Init(new Vector2(3200, thirdFloor));
            m_LeafPList.Add(m_LeafPiece2);

            LeafPiece m_LeafPiece3 = new LeafPiece();
            m_LeafPiece3.Init(new Vector2(4200, secondFloor));
            m_LeafPList.Add(m_LeafPiece3);

            LeafPiece m_LeafPiece4 = new LeafPiece();
            m_LeafPiece4.Init(new Vector2(5200, secondFloor));
            m_LeafPList.Add(m_LeafPiece4);

            LeafPiece m_LeafPiece5 = new LeafPiece();
            m_LeafPiece5.Init(new Vector2(6200, secondFloor));
            m_LeafPList.Add(m_LeafPiece5);

            LeafPiece m_LeafPiece6 = new LeafPiece();
            m_LeafPiece6.Init(new Vector2(7200, secondFloor));
            m_LeafPList.Add(m_LeafPiece6);

            LeafPiece m_LeafPiece7 = new LeafPiece();
            m_LeafPiece7.Init(new Vector2(8200, secondFloor));
            m_LeafPList.Add(m_LeafPiece7);

            LeafPiece m_LeafPiece8 = new LeafPiece();
            m_LeafPiece8.Init(new Vector2(9200, secondFloor));
            m_LeafPList.Add(m_LeafPiece8);

            LeafPiece m_LeafPiece9 = new LeafPiece();
            m_LeafPiece9.Init(new Vector2(10200, secondFloor));
            m_LeafPList.Add(m_LeafPiece9);

            LeafPiece m_LeafPiece10 = new LeafPiece();
            m_LeafPiece10.Init(new Vector2(11200, secondFloor));
            m_LeafPList.Add(m_LeafPiece10);

            LeafPiece m_LeafPiece11 = new LeafPiece();
            m_LeafPiece11.Init(new Vector2(12200, secondFloor));
            m_LeafPList.Add(m_LeafPiece11);

            LeafPiece m_LeafPiece12 = new LeafPiece();
            m_LeafPiece12.Init(new Vector2(13200, secondFloor));
            m_LeafPList.Add(m_LeafPiece12);

            LeafPiece m_LeafPiece13 = new LeafPiece();
            m_LeafPiece13.Init(new Vector2(9700, secondFloor));
            m_LeafPList.Add(m_LeafPiece13);

            LeafPiece m_LeafPiece14 = new LeafPiece();
            m_LeafPiece14.Init(new Vector2(200, secondFloor));
            m_LeafPList.Add(m_LeafPiece14);

            SnowFall m_SnowFall1 = new SnowFall();
            m_SnowFall1.Init(new Vector2(1650, firstFloor));
            m_SnowFallList.Add(m_SnowFall1);

            SnowFall m_SnowFall2 = new SnowFall();
            m_SnowFall2.Init(new Vector2(11070, firstFloor));
            m_SnowFallList.Add(m_SnowFall2);

            Enemy m_Enemy = new Enemy();
            m_Enemy.Init(new Vector2(4500, thirdFloor), 4450, 4600);
            m_Enemylist.Add(m_Enemy);

            Enemy m_Enemy5 = new Enemy();
            m_Enemy5.Init(new Vector2(8300, thirdFloor), 8200, 8400);
            m_Enemylist.Add(m_Enemy5);

            Enemy m_Enemy1 = new Enemy();
            m_Enemy1.Init(new Vector2(12500, thirdFloor), 12450, 12550);
            m_Enemylist.Add(m_Enemy1);

            Enemy m_Enemy2 = new Enemy();
            m_Enemy2.Init(new Vector2(12700, thirdFloor), 12600, 12750);
            m_Enemylist.Add(m_Enemy2);

            Enemy m_Enemy3 = new Enemy();
            m_Enemy3.Init(new Vector2(12900, thirdFloor), 12800, 12900);
            m_Enemylist.Add(m_Enemy3);

            Enemy m_Enemy4 = new Enemy();
            m_Enemy4.Init(new Vector2(13100,thirdFloor), 13000, 13100);
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

        List<LeafPiece> m_LeafPList = new List<LeafPiece>();
        List<BeadPiece> m_BeadPList = new List<BeadPiece>();
        List<IcePick> m_IcePickList = new List<IcePick>();
        List<SnowFall> m_SnowFallList = new List<SnowFall>();
        List<Enemy> m_Enemylist = new List<Enemy>();
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

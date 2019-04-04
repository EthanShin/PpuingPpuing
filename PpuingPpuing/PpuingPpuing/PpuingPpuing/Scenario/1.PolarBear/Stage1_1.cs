using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PpuingPpuing
{
    class Stage1_1 : IScenario
    {
        int[] m_tile = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 5, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                         1, 3, 3, 4, 2, 5, 1, 4, 2, 5, 0, 0, 5, 1, 3, 2, 0, 0, 5, 1, 2, 5, 1, 3, 3, 2, 5, 0, 0, 0, 5, 1, 3, 3, 2, 5, 1, 2, 5, 1, 3, 3, 3, 3, 3, 3, 3,
                         0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 1, 2, 5, 0, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0
                       };

        public override void Init()
        {
            m_StageSize = (int)((m_tile.Length / 10 - (int)(800 / (283 * tileSize) + 1)) * 283 * tileSize);
            m_StageTile = m_tile;

            LeafPiece m_LeafPiece = new LeafPiece();
            m_LeafPiece.Init(new Vector2(800, secondFloor));
            m_LeafPieceList.Add(m_LeafPiece);

            LeafPiece m_LeafPiece1 = new LeafPiece();
            m_LeafPiece1.Init(new Vector2(1000, secondFloor));
            m_LeafPieceList.Add(m_LeafPiece1);

            LeafPiece m_LeafPiece2 = new LeafPiece();
            m_LeafPiece2.Init(new Vector2(1400, secondFloor));
            m_LeafPieceList.Add(m_LeafPiece2);

            LeafPiece m_LeafPiece3 = new LeafPiece();
            m_LeafPiece3.Init(new Vector2(2050, secondFloor));
            m_LeafPieceList.Add(m_LeafPiece3);

            LeafPiece m_LeafPiece4 = new LeafPiece();
            m_LeafPiece4.Init(new Vector2(3225, secondFloor));
            m_LeafPieceList.Add(m_LeafPiece4);

            BeadPiece m_beadPiece = new BeadPiece();
            m_beadPiece.Init(new Vector2(2400, thirdFloor));
            m_BeadPieceList.Add(m_beadPiece);

            //BeadPiece m_beadPiece1 = new BeadPiece();
            //m_beadPiece1.Init(new Vector2(3740, thirdFloor));
            //m_BeadPieceList.Add(m_beadPiece1);

            IcePick m_IcePick = new IcePick();
            m_IcePick.Init(new Vector2(1400, secondFloor));
            m_IcePickList.Add(m_IcePick);

            IcePick m_IcePick1 = new IcePick();
            m_IcePick1.Init(new Vector2(2375, secondFloor));
            m_IcePickList.Add(m_IcePick1);

            IcePick m_IcePick2 = new IcePick();
            m_IcePick2.Init(new Vector2(2400, secondFloor));
            m_IcePickList.Add(m_IcePick2);

            IcePick m_IcePick3 = new IcePick();
            m_IcePick3.Init(new Vector2(2425, secondFloor));
            m_IcePickList.Add(m_IcePick3);

            IcePick m_IcePick4 = new IcePick();
            m_IcePick4.Init(new Vector2(3225, secondFloor));
            m_IcePickList.Add(m_IcePick4);

            SnowFall m_SnowFall = new SnowFall();
            m_SnowFall.Init(new Vector2(2050, firstFloor));
            m_SnowFallList.Add(m_SnowFall);

            SnowFall m_SnowFall1 = new SnowFall();
            m_SnowFall1.Init(new Vector2(3740, firstFloor));
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
        List<SnowFall> m_SnowFallList = new List<SnowFall>();
        List<LeafPiece> m_LeafPieceList = new List<LeafPiece>();
        List<BeadPiece> m_BeadPieceList = new List<BeadPiece>();

        public override List<IcePick> GetIcePick()
        {
            return m_IcePickList;
        }
        public override List<SnowFall> GetSnowFall()
        {
            return m_SnowFallList;
        }
        public override List<BeadPiece> GetBeadPiece()
        {
            return m_BeadPieceList;
        }
        public override List<LeafPiece> GetLeafPiece()
        {
            return m_LeafPieceList;
        }
    }
}

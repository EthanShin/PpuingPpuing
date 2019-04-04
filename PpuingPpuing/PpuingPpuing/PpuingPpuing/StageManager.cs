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
    class StageManager
    {
        IScenario senario;
        public IScenario SelectStage(string MapName, string StageName)
        {
            switch (MapName + StageName)
            {
                case "PolarBearFirst": senario = new Stage1_1(); break;
                case "PolarBearSecond": senario = new Stage1_2(); break;
                case "PolarBearThird": senario = new Stage1_3(); break;
                case "PolarBearFourth": senario = new Stage1_4(); break;
                case "PolarBearFinal": senario = new Stage1_5(); break;

                case "PandaFirst": senario = new Stage2_1(); break;
                case "PandaSecond": senario = new Stage2_2(); break;
                case "PandaThird": senario = new Stage2_3(); break;
                case "PandaFourth": senario = new Stage2_4(); break;
                case "PandaFinal": senario = new Stage2_5(); break;

                case "TunaFirst": senario = new Stage3_1(); break;
                case "TunaSecond": senario = new Stage3_2(); break;
                case "TunaThird": senario = new Stage3_3(); break;
                case "TunaFourth": senario = new Stage3_4(); break;
                case "TunaFinal": senario = new Stage3_5(); break;

                case "AntelopeFirst": senario = new Stage4_1(); break;
                case "AntelopeSecond": senario = new Stage4_2(); break;
                case "AntelopeThird": senario = new Stage4_3(); break;
                case "AntelopeFourth": senario = new Stage4_4(); break;
                case "AntelopeFinal": senario = new Stage4_5(); break;

                case "RhinocerosFirst": senario = new Stage5_1(); break;
                case "RhinocerosSecond": senario = new Stage5_2(); break;
                case "RhinocerosThird": senario = new Stage5_3(); break;
                case "RhinocerosFourth": senario = new Stage5_4(); break;
                case "RhinocerosFinal": senario = new Stage5_5(); break;

                case "FrogFirst": senario = new Stage6_1(); break;
                case "FrogSecond": senario = new Stage6_2(); break;
                case "FrogThird": senario = new Stage6_3(); break;
                case "FrogFourth": senario = new Stage6_4(); break;
                case "FrogFinal": senario = new Stage6_5(); break;

                case "ArmadilloFirst": senario = new Stage7_1(); break;
                case "ArmadilloSecond": senario = new Stage7_2(); break;
                case "ArmadilloThird": senario = new Stage7_3(); break;
                case "ArmadilloFourth": senario = new Stage7_4(); break;
                case "ArmadilloFinal": senario = new Stage7_5(); break;
            }
            senario.Init();
            return senario;
        }
    }
}

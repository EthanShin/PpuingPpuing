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
    enum MoveDirection
    {
        Right, Left, Down
    }
    enum SkillNumber
    {
        Ppuooo, PolarBear, Panda, Tuna, Antelope, Rhinoceros, Frog, Armadillo
    }

    class PlayScreen : IScreen
    {
        #region 변수
        #region 배경관련변수
        Texture2D m_BackgroundImage;
        Texture2D m_BackgroundImage2;
        int m_BackgroundPosition;
        int m_BackgroundPosition2;
        #endregion

        //뿌우 시작 위치 수정
        #region 뿌우이미지관련변수
        Texture2D m_PpuoooStandingImage;
        Texture2D m_PpuoooMovingImage;
        Texture2D m_PpuoooAttackingImage;
        Texture2D m_PpuoooAttackedImage;
        Texture2D m_PpuoooDyingImage;
        int m_PpuoooStandingImageNumber;
        int m_PpuoooMovingImageNumber;
        int m_PpuoooAttackImageNumber;
        int m_PpuoooDieImageNumber;
        int m_PpuoooPosition_X;
        int m_PpuoooPosition_Y = 250;
        int m_SpriteSpeed;
        int m_AttackImageSpeed;
        int m_AttackedImageSpeed;
        int m_DieImageSpeed;
        float m_PpuoooImageSize = 0.40f;
        #endregion
        #region 뿌우상태관련변수
        Texture2D m_PpuoooStateSkill;
        Texture2D m_PpuoooStateGood;
        Texture2D m_PpuoooStateTired;
        Texture2D m_PpuoooStateHard_First;
        Texture2D m_PpuoooStateHard_Second;
        Texture2D m_PpuoooStateDanger_First;
        Texture2D m_PpuoooStateDanger_Second;
        Texture2D m_PpuoooStateDead;
        Texture2D m_PpuoooHealthImage;
        Texture2D m_PpuoooManaImage;
        Texture2D m_PpuoooBeadImage;
        SpriteFont m_Font;
        int m_PpuoooHealth = 100;
        int m_PpuoooMana = 100;
        int m_CurrentBeads = 0;
        int m_CurrentLeafs = 0;
        int m_PpuoooPower = 10;
        int m_TwinkleHardStateSpeed = 0;
        int m_TwinkleDangerStateSpeed = 0;
        #endregion
        #region 뿌우스킬변수
        SkillNumber selecedSkill;
        Texture2D m_CurrentSkillState;
        Texture2D m_CurrentSkillBorder;

        Texture2D m_PolarBearStanding;
        Texture2D m_PandaStanding;
        Texture2D m_TunaStanding;
        Texture2D m_AntelopeStanding;
        Texture2D m_RhinocerosStanding;
        Texture2D m_FrogStanding;
        Texture2D m_ArmadilloStanding;

        Texture2D m_PolarBearMoving;
        Texture2D m_PandaMoving;
        Texture2D m_TunaMoving;
        Texture2D m_AntelopeMoving;
        Texture2D m_RhinocerosMoving;
        Texture2D m_FrogMoving;
        Texture2D m_ArmadilloMoving;

        Texture2D m_PolarBearAction;
        Texture2D m_PandaAction;
        Texture2D m_TunaAction;
        Texture2D m_AntelopeAction;
        Texture2D m_RhinocerosAction;
        Texture2D m_FrogAction;
        Texture2D m_ArmadilloAction;

        Texture2D m_PolarBearAttacked;
        Texture2D m_PandaAttacked;
        Texture2D m_TunaAttacked;
        Texture2D m_AntelopeAttacked;
        Texture2D m_RhinocerosAttacked;
        Texture2D m_FrogAttacked;
        Texture2D m_ArmadilloAttacked;

        Texture2D m_PolarBearDying;
        Texture2D m_PandaDying;
        Texture2D m_TunaDying;
        Texture2D m_AntelopeDying;
        Texture2D m_RhinocerosDying;
        Texture2D m_FrogDying;
        Texture2D m_ArmadilloDying;
        #endregion

        //수치 수정
        #region 움직임관련변수
        MoveDirection m_PpuoooMoveDirection;
        bool m_IsLeft;
        const int MOVE = 7;
        const int GRAVITY = 5;
        int m_ActivitySpeed = 0;

        int m_JumpingTime;
        bool m_IsJumping;
        bool m_IsGround;
        bool m_IsMoving;
        bool m_IsAttacking;
        bool m_IsAttacked;
        bool m_IsDead;
        bool m_IsDiving;
        bool m_IsSuccess;
        #endregion
        #region 컨트롤관련변수
        Button m_OptionButton;
        Button m_LeftButton;
        Button m_RightButton;
        Button m_JumpButton;
        Button m_ActionButton;
        SkillButton m_SkillButton;
        ReleaseButton m_FailedButton;
        ReleaseButton m_SuccessButton;
        #endregion
        #region 옵션메뉴관련변수
        Texture2D m_OptionBackground;
        ReleaseButton m_ContinueButton;
        ReleaseButton m_ResetButton;
        ReleaseButton m_HomeButton;
        bool m_IsPressOption;
        #endregion
        #region 시나리오관련변수
        IScenario m_Scenario;
        int m_StageSize;
        int[] m_StageTile;
        #endregion
        #region 필드관련변수
        Texture2D m_LeftField;
        Texture2D m_RightField;
        Texture2D m_FlatField;
        Texture2D m_ConvexField;
        Texture2D m_CompletePosition;
        double m_TileSize;
        int m_TilePosition;
        int m_TileInterval = 45;
        int m_TilePositionWithJump;
        bool m_IsDropField;
        #endregion

        #region 스테이지요소관련변수
        Texture2D m_IcePick;
        Texture2D m_SnowFall;
        Texture2D m_LeafPiece;
        Texture2D m_BeadPiece;
        Texture2D m_IceFall;
        List<IcePick> m_IcePickList = new List<IcePick>();
        List<SnowFall> m_SnowFallList = new List<SnowFall>();
        List<BeadPiece> m_BeadPieceList = new List<BeadPiece>();
        List<LeafPiece> m_LeafPieceList = new List<LeafPiece>();
        List<IceFall> m_IceFallList = new List<IceFall>();
        int m_IcePickNum;
        int m_SnowFallNum;
        int m_IceFallNum;
        int m_LeafPieceNum;
        int m_BeadPieceNum;
        #endregion

        #region 효과음변수
        SoundEffect m_PpuoooHurt;
        SoundEffect m_EnermyAttack;
        SoundEffect m_PpuoooPunch;
        #endregion
        #region 적관련변수
        List<Enemy> m_EnemyList = new List<Enemy>();
        List<EnemyBoss> m_EnemyBossList = new List<EnemyBoss>();
        List<Song> m_BGMS = new List<Song>();
        //EnemyBoss m_EnemyBoss = new EnemyBoss();
        List<BGM> m_BGM = new List<BGM>();
        Texture2D m_EnemyBossImage;
        Texture2D m_EnemyBossAttackingImage;
        Texture2D m_EnemyBossTiredImage;
        Texture2D m_EnemyBossBounceImage;
        Texture2D m_EnemyEntireImage;
        Texture2D m_EnemyAttackedImage;
        Texture2D m_EnemyAttackingImage;
        int m_EnemyImageNumber;
        int m_EnemyAttackImageNumber;
        int m_EnemyBossImageNumber;
        int m_EnemyBossAttackImageNumber;
        int m_EnemyBossNumber;
        int m_EnemyNumber;
        float m_EnemyImageSize = 0.30f;
        float m_EnemyBossSize = 0.7f;
        #endregion
        #endregion

        public override void Init(ContentManager content, string mapName, string stageName, IScenario scenario)
        {
            InitStage(scenario);
            InitStageElement(scenario, content);
            InitPpuooo(content);
            InitSkill(content);
            InitField(content, mapName);
            InitEnemy(content);
            InitControl(content);
            InitOption(content);
            /////////////////////////////////////
            InitMusic(content);
        }
        #region Init
        private void InitStage(IScenario scenario)
        {
            m_TileSize = IScenario.tileSize;
            m_Scenario = scenario;
            m_StageSize = m_Scenario.GetSize();
            m_StageTile = m_Scenario.GetTile();
        }
        private void InitStageElement(IScenario scenario, ContentManager content)
        {
            m_IcePickList = m_Scenario.GetIcePick();
            m_SnowFallList = m_Scenario.GetSnowFall();
            m_LeafPieceList = m_Scenario.GetLeafPiece();
            m_IceFallList = m_Scenario.GetIceFall();
            m_BeadPieceList = m_Scenario.GetBeadPiece();

            m_IcePick = content.Load<Texture2D>("PlayScreen/StageElement/IcePick");
            m_SnowFall = content.Load<Texture2D>("PlayScreen/StageElement/SnowFall");
            m_IceFall = content.Load<Texture2D>("PlayScreen/StageElement/IceFall");
            m_BeadPiece = content.Load<Texture2D>("PlayScreen/StageElement/BeadPiece");
            m_LeafPiece = content.Load<Texture2D>("PlayScreen/StageElement/LeafPiece");
        }
        private void InitPpuooo(ContentManager content)
        {
            m_PpuoooStandingImage = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Standing");
            m_PpuoooMovingImage = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Moving");
            m_PpuoooAttackingImage = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Attacking");
            m_PpuoooAttackedImage = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Attacked");
            m_PpuoooDyingImage = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Dying");

            m_PpuoooStateSkill = content.Load<Texture2D>("PlayScreen/State/State_Skill");
            m_PpuoooStateGood = content.Load<Texture2D>("PlayScreen/State/State_Good");
            m_PpuoooStateTired = content.Load<Texture2D>("PlayScreen/State/State_Tired");
            m_PpuoooStateHard_First = content.Load<Texture2D>("PlayScreen/State/State_Hard_First");
            m_PpuoooStateHard_Second = content.Load<Texture2D>("PlayScreen/State/State_Hard_Second");
            m_PpuoooStateDanger_First = content.Load<Texture2D>("PlayScreen/State/State_Danger_First");
            m_PpuoooStateDanger_Second = content.Load<Texture2D>("PlayScreen/State/State_Danger_Second");
            m_PpuoooStateDead = content.Load<Texture2D>("PlayScreen/State/State_Dead");

            m_PpuoooHealthImage = content.Load<Texture2D>("PlayScreen/State/Bar_Health");
            m_PpuoooManaImage = content.Load<Texture2D>("PlayScreen/State/Bar_Mana");

            m_PpuoooBeadImage = content.Load<Texture2D>("ResultScreen/FullBead");
        }
        private void InitSkill(ContentManager content)
        {
            m_CurrentSkillState = content.Load<Texture2D>("PlayScreen/SkillImage/SkillState");
            m_CurrentSkillBorder = content.Load<Texture2D>("PlayScreen/SkillImage/SkillBorder");

            //m_PolarBearStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_PolarBear_Standing");
            //m_PandaStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Panda_Standing");
            //m_TunaStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Tuna_Standing");
            //m_AntelopeStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Antelope_Standing");
            //m_RhinocerosStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Rhinoceros_Standing");
            //m_FrogStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Frog_Standing");
            //m_ArmadilloStanding = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Armadillo_Standing");

            m_PolarBearMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_PolarBear_Moving");
            m_PandaMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Panda_Moving");
            //m_TunaMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Tuna_Moving");
            //m_AntelopeMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Antelope_Moving");
            //m_RhinocerosMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Rhinoceros_Moving");
            m_FrogMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Frog_Moving");
            //m_ArmadilloMoving = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Armadillo_Moving");

            m_PolarBearAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_PolarBear_Action");
            //m_PandaAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Panda_Action");
            //m_TunaAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Tuna_Action");
            //m_AntelopeAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Antelope_Action");
            //m_RhinocerosAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Rhinoceros_Action");
            //m_FrogAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Frog_Action");
            //m_ArmadilloAction = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Armadillo_Action");

            //m_PolarBearAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_PolarBear_Attacked");
            //m_PandaAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Panda_Attacked");
            //m_TunaAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Tuna_Attacked");
            //m_FrogAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Frog_Attacked");
            //m_AntelopeAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Antelope_Attacked");
            //m_RhinocerosAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Rhinoceros_Attacked");
            //m_ArmadilloAttacked = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Armadillo_Attacked");

            //m_PolarBearDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_PolarBear_Dying");
            //m_PandaDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Panda_Dying");
            //m_TunaDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Tuna_Dying");
            //m_AntelopeDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Antelope_Dying");
            //m_RhinocerosDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Rhinoceros_Dying");
            //m_FrogDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Frog_Dying");
            //m_ArmadilloDying = content.Load<Texture2D>("PlayScreen/Character/Ppuooo_Armadillo_Dying");
        }
        private void InitField(ContentManager content, string mapName)
        {
            m_BackgroundImage = content.Load<Texture2D>("PlayScreen/" + mapName + "/Background");
            m_BackgroundImage2 = m_BackgroundImage;
            m_BackgroundPosition2 = m_BackgroundImage.Width;

            m_CompletePosition = content.Load<Texture2D>("PlayScreen/" + mapName + "/CompletePosition");

            m_LeftField = content.Load<Texture2D>("PlayScreen/" + mapName + "/LeftField");
            m_RightField = content.Load<Texture2D>("PlayScreen/" + mapName + "/RightField");
            m_FlatField = content.Load<Texture2D>("PlayScreen/" + mapName + "/FlatField");
            m_ConvexField = content.Load<Texture2D>("PlayScreen/" + mapName + "/ConvexField");
            m_Font = content.Load<SpriteFont>("PlayScreen/State/myFont");
        }
        private void InitEnemy(ContentManager content)
        {
            m_EnemyList = m_Scenario.GetEnemy();
            m_EnemyEntireImage = content.Load<Texture2D>("PlayScreen/Character/Enemy_Moving");
            m_EnemyAttackedImage = content.Load<Texture2D>("PlayScreen/Character/Enemy_Attacked");
            m_EnemyAttackingImage = content.Load<Texture2D>("PlayScreen/Character/Enemy_Attacking");
          
        }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <param name="content"></param>
        private void InitEnemyBoss(ContentManager content)
        {
            m_EnemyBossList = m_Scenario.GetBoss();
            m_EnemyBossImage = content.Load<Texture2D>("Boss/Boss_Moving");
            m_EnemyBossAttackingImage = content.Load<Texture2D>("Boss/Boss_Attack");
            m_EnemyBossTiredImage = content.Load<Texture2D>("Boss/Boss_Tired");
            m_EnemyBossBounceImage = content.Load<Texture2D>("Boss/Boss_Bounce");

        }
        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>
        /// <param name="content"></param>
        private void InitControl(ContentManager content)
        {
            m_OptionButton = new Button();
            m_OptionButton.Init(content, new Vector2(715, 5), 0.5f, "UI/Option");
            m_OptionButton.UserTouchEvent = OnTouchOptionButton;

            m_LeftButton = new Button();
            m_LeftButton.Init(content, new Vector2(60, 350), 0.6f, "PlayScreen/Control/LeftButton");
            m_LeftButton.UserTouchEvent = OnTouchLeftButton;

            m_RightButton = new Button();
            m_RightButton.Init(content, new Vector2(200, 350), 0.6f, "PlayScreen/Control/RightButton");
            m_RightButton.UserTouchEvent = OnTouchRightButton;

            m_JumpButton = new Button();
            m_JumpButton.Init(content, new Vector2(650, 370), 0.6f, "PlayScreen/Control/JumpButton");
            m_JumpButton.UserTouchEvent = OnTouchJumpButton;

            m_ActionButton = new Button();
            m_ActionButton.Init(content, new Vector2(680, 270), 0.6f, "PlayScreen/Control/AttackButton");
            m_ActionButton.UserTouchEvent = OnTouchActionButton;

            m_SkillButton = new SkillButton();
            m_SkillButton.Init(content, new Vector2(690, 170), 0.6f, "PolarBearSkill", "PandaSkill");
            m_SkillButton.UserTouchEvent = OnTouchSkillButton;

            m_FailedButton = new ReleaseButton();
            m_FailedButton.Init(content, new Vector2(100, 100), 0.4f, "PlayScreen/failed");
            m_FailedButton.UserTouchEvent = OnClickFailedButton;

            m_SuccessButton = new ReleaseButton();
            m_SuccessButton.Init(content, new Vector2(100, 100), 0.4f, "PlayScreen/success");
            m_SuccessButton.UserTouchEvent = OnClickSuccessButton;
        }
        private void InitOption(ContentManager content)
        {
            m_OptionBackground = content.Load<Texture2D>("UI/SettingBackground");

            m_ContinueButton = new ReleaseButton();
            m_ContinueButton.Init(content, new Vector2(650, 110) ,0.6f, "UI/SettingCancel");
            m_ContinueButton.UserTouchEvent = OnTouchContinueButton;

            m_ResetButton = new ReleaseButton();
            m_ResetButton.Init(content, new Vector2(500, 210), "UI/Replay");
            m_ResetButton.UserTouchEvent = OnTouchResetButton;

            m_HomeButton = new ReleaseButton();
            m_HomeButton.Init(content, new Vector2(75, 110),0.5f, "UI/SettingHome");
            m_HomeButton.UserTouchEvent = OnTouchHomeButton;
        }
        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="content"></param>
        private void InitMusic(ContentManager content)
        {
            List<Song> m_BGMS = new List<Song>();
            m_EnermyAttack = content.Load<SoundEffect>("Music/knife");
            m_PpuoooHurt = content.Load<SoundEffect>("Music/hurt");
            m_PpuoooPunch = content.Load<SoundEffect>("Music/punch");
            m_BGMS.Add(content.Load<Song>("Music/PlayBGM"));
            MediaPlayer.Stop();
            MediaPlayer.Play(m_BGMS[0]);
           
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////
        /// </summary>
        #endregion.

        #region 터치이벤트
        private void OnTouchLeftButton()
        {
            m_PpuoooMoveDirection = MoveDirection.Left;
            m_IsLeft = true;

            if (m_SpriteSpeed++ > 3)
            {
                m_SpriteSpeed = 0;
                if (m_PpuoooMovingImageNumber++ >= 5)
                    m_PpuoooMovingImageNumber = 0;
            }
        }
        private void OnTouchRightButton()
        {
            m_PpuoooMoveDirection = MoveDirection.Right;
            m_IsLeft = false;

            if (m_SpriteSpeed++ > 3)
            {
                m_SpriteSpeed = 0;
                if (m_PpuoooMovingImageNumber++ >= 5)
                    m_PpuoooMovingImageNumber = 0;
            }
        }

        private void OnTouchJumpButton()
        {
            if (m_IsGround)
                m_IsJumping = true;
        }
        private void OnTouchSkillButton()
        {
            switch (m_SkillButton.selectSkill)
            {
                case 0: selecedSkill = SkillNumber.Ppuooo; break;
                case 1: selecedSkill = SkillNumber.PolarBear; break;
                case 2: selecedSkill = SkillNumber.Panda; break;
                case 3: selecedSkill = SkillNumber.Tuna; break;
                case 4: selecedSkill = SkillNumber.Antelope; break;
                case 5: selecedSkill = SkillNumber.Rhinoceros; break;
                case 6: selecedSkill = SkillNumber.Frog; break;
                case 7: selecedSkill = SkillNumber.Armadillo; break;
            }
        }
        private void OnTouchActionButton()
        {
            switch (selecedSkill)
            {
                case SkillNumber.Ppuooo: ActionOfPpuooo(); break;
                case SkillNumber.PolarBear: ActionOfPolarBear(); break;
                case SkillNumber.Panda: ActionOfPanda(); break;
                case SkillNumber.Tuna: ActionOfTuna(); break;
                case SkillNumber.Antelope: ActionOfAntelope(); break;
                case SkillNumber.Rhinoceros: ActionOfRhinoceros(); break;
                case SkillNumber.Frog: ActionOfFrog(); break;
                case SkillNumber.Armadillo: ActionOfArmadillo(); break;
            }
        }
        private void ActionOfPpuooo()
        {
            m_PpuoooPunch.Play();
            if (!m_IsAttacking)
                m_IsAttacking = true;
            m_PpuoooPower = 10;
        }
        private void ActionOfPolarBear()
        {
            if (m_PpuoooMana > 4)
            {
                m_PpuoooPunch.Play();
                if (!m_IsAttacking)
                {
                    m_PpuoooMana -= 5;
                    m_IsAttacking = true;
                    m_PpuoooPower = 15;
                }
            }
        }
        private void ActionOfPanda()
        {
        }
        private void ActionOfTuna()
        {
        }
        private void ActionOfAntelope()
        {
        }
        private void ActionOfRhinoceros()
        {
        }
        private void ActionOfFrog()
        {
        }
        private void ActionOfArmadillo()
        {
        }

        private void OnTouchOptionButton()
        {
            m_IsPressOption = true;
        }
        private void OnTouchContinueButton()
        {
            m_IsPressOption = false;
        }
        private void OnTouchResetButton()
        {
            m_ScreenManager.SelectScreen(Mode.StageScreen);
        }
        private void OnTouchHomeButton()
        {
            m_ScreenManager.SelectScreen(Mode.TitleScreen);
        }

        private void OnClickFailedButton()
        {
            m_ScreenManager.SelectScreen(Mode.StageScreen);
        }
        private void OnClickSuccessButton()
        {
            m_ScreenManager.SelectScreen(Mode.StageScreen);
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            m_PpuoooMoveDirection = MoveDirection.Down;

            UpdateControl(gameTime);
            UpdateWithPpuoooState();
            UpdateMusic();

            if (m_ActivitySpeed++ > 7 && !m_IsDead)
            {
                UpdateWithEnemy();
                
                UpdateWithStageElement();
                m_ActivitySpeed = 0;
            }
               // UpdateWithEnemyBoss();
        }
        #region Update
        private void UpdateControl(GameTime gameTime)
        {
            if (m_IsDead)
            {
                m_FailedButton.Update(gameTime);
            }
            else if (m_IsSuccess)

            {
                m_SuccessButton.Update(gameTime);
            }
            if (m_IsPressOption)
            {
                m_ContinueButton.Update(gameTime);
                m_ResetButton.Update(gameTime);
                m_HomeButton.Update(gameTime);
            }
            else if (!m_IsDead && !m_IsSuccess)
            {
                if (!m_IsAttacking && !m_IsDiving)
                {
                    m_LeftButton.Update(gameTime);
                    m_RightButton.Update(gameTime);
                    m_JumpButton.Update(gameTime);
                }
                m_SkillButton.Update(gameTime);
                m_ActionButton.Update(gameTime);
                m_OptionButton.Update(gameTime);
            }
        }

        private void UpdateWithPpuoooState()
        {
            if (m_PpuoooHealth <= 0)
            {
                m_PpuoooHealth = 0;
                m_IsDead = true;
                m_ScreenManager.SelectScreen(Mode.ResultScreen);
            }

            if (m_IsDead)
            {
                if (m_DieImageSpeed++ > 1)
                    if (m_PpuoooDieImageNumber < 1)
                        m_PpuoooDieImageNumber++;
            }
            else if (!m_IsDead)
            {
                PpuoooStateMoving();

                if (m_IsJumping)
                    PpuoooStateJumping();
                else if (!m_IsJumping)
                    PpuoooStateNotJumping();

                CollisionInspectionWithEnemy();
            }
        }
        private void UpdateMusic()
        {
            //MediaPlayer.Stop();
        }
        private void PpuoooStateMoving()
        {
            m_IsMoving = false;
            if (m_PpuoooMoveDirection == MoveDirection.Left)
            {
                m_IsMoving = true;
                if ((m_PpuoooPosition_X -= MOVE) < -40)
                    m_PpuoooPosition_X = -40;
            }
            else if (m_PpuoooMoveDirection == MoveDirection.Right)
            {
                m_IsMoving = true;
                if (m_PpuoooPosition_X + m_PpuoooMovingImage.Width / 6 * m_PpuoooImageSize >= GraphicsDeviceManager.DefaultBackBufferWidth / 2
                    && m_TilePosition > -m_StageSize)
                {
                    m_BackgroundPosition -= MOVE / 5;
                    m_BackgroundPosition2 -= MOVE / 5;
                    if (m_BackgroundPosition == -m_BackgroundImage.Width)
                        m_BackgroundPosition = m_BackgroundImage.Width;
                    if (m_BackgroundPosition2 == -m_BackgroundImage.Width)
                        m_BackgroundPosition2 = m_BackgroundImage.Width;

                    m_TilePosition -= MOVE;
                }
                else
                {
                    if (m_PpuoooPosition_X >= 650)
                        m_IsSuccess = true;
                    m_PpuoooPosition_X += MOVE;
                }
            }

            if (!m_IsMoving)
            {
                if (m_PpuoooStandingImageNumber++ > 0)
                    m_PpuoooStandingImageNumber = 0;
            }
        }
        private void PpuoooStateJumping()
        {
            m_PpuoooPosition_Y -= GRAVITY;
            m_TilePositionWithJump += GRAVITY;
            if (m_JumpingTime++ > 13)
            {
                m_IsJumping = false;
                m_IsGround = false;
                m_JumpingTime = 0;
            }
        }
        private void PpuoooStateNotJumping()
        {
            if (CollisionInspectionWithTile())
            {
                m_IsGround = false;
                m_PpuoooPosition_Y += GRAVITY;
                if (!m_IsDropField)
                    m_TilePositionWithJump -= GRAVITY;

                if (m_PpuoooPosition_Y >= GraphicsDeviceManager.DefaultBackBufferHeight)
                {
                    m_PpuoooHealth--;
                    m_IsDiving = true;
                }
            }
        }
        private bool CollisionInspectionWithTile()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 55, m_PpuoooPosition_Y,
                 30, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            bool containZeroTile = true;

            float fieldSize = (float)(m_LeftField.Width * m_TileSize);
            int drawFieldDownPosition = (int)((m_StageSize + 800) / fieldSize) + 1;
            for (int i = 0; i < m_StageTile.Length; i++)
            {
                var tile_X = i % drawFieldDownPosition;
                var tile_Y = i / drawFieldDownPosition;

                if (IsDropField(i))
                {
                    var tileRec = new Rectangle((int)(fieldSize * tile_X) + m_TilePosition - 5, m_TileInterval * tile_Y + m_TilePositionWithJump,
                        (int)fieldSize + 10, (int)(m_LeftField.Height * m_TileSize));

                    if (tileRec.Contains(PpuoooRec))
                        m_IsDropField = true;
                }

                else if(IsCompletePosition(i))
                {
                    var tileRec = new Rectangle((int)(fieldSize * tile_X) + m_TilePosition - 5, m_TileInterval * tile_Y + m_TilePositionWithJump,
                           (int)fieldSize + 10, (int)(m_LeftField.Height * m_TileSize));

                    if (tileRec.Contains(PpuoooRec))
                    {
                        m_IsSuccess = true;
                        m_ScreenManager.SelectScreen(Mode.ResultScreen);
                    }
                }

                else if (IsCollisionWithTile(i))
                {
                    var tileRec = new Rectangle((int)(fieldSize * tile_X) + m_TilePosition, m_TileInterval * tile_Y + 40 + m_TilePositionWithJump,
                        (int)fieldSize, (int)(m_LeftField.Height * m_TileSize));

                    if (tileRec.Intersects(PpuoooRec))
                    {
                        containZeroTile = false;
                        switch (m_PpuoooMoveDirection)
                        {
                            case MoveDirection.Down: m_IsGround = true; break;
                            case MoveDirection.Left:
                                if (!m_IsGround && tileRec.Top >= PpuoooRec.Bottom - 9)
                                    m_IsGround = true;
                                else if (tileRec.Top < PpuoooRec.Bottom - 9)
                                {
                                    containZeroTile = true;
                                    m_PpuoooPosition_X += MOVE;
                                }
                                break;
                            case MoveDirection.Right:
                                if (!m_IsGround && tileRec.Top >= PpuoooRec.Bottom - 9)
                                {
                                    m_IsGround = true;
                                }
                                else if (tileRec.Top < PpuoooRec.Bottom - 9)
                                {
                                    containZeroTile = true;
                                    m_PpuoooPosition_X -= MOVE;
                                    if (m_PpuoooPosition_X + m_PpuoooMovingImage.Width / 6 * m_PpuoooImageSize >= GraphicsDeviceManager.DefaultBackBufferWidth / 2)
                                    {
                                        m_BackgroundPosition += MOVE / 5;
                                        m_BackgroundPosition2 += MOVE / 5;
                                        m_TilePosition += MOVE;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return containZeroTile;
        }
        private bool IsCollisionWithTile(int checkIndex)
        {
            if (m_StageTile[checkIndex] != 0 && m_StageTile[checkIndex] != 5 && m_StageTile[checkIndex] != 9)
                return true;

            return false;
        }
        private bool IsDropField(int checkIndex)
        {
            if (m_StageTile[checkIndex] == 5)
                return true;

            return false;
        }
        private bool IsCompletePosition(int checkIndex)
        {
            if (m_StageTile[checkIndex] == 9)
                return true;

            return false;
        }
        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        private void UpdateWithEnemy()
        {
            if (m_EnemyList.Count > 0)
            {
                for (int i = 0; i < m_EnemyList.Count; i++)
                    m_EnemyList[i].EnemyMoving();

                if (m_AttackImageSpeed++ > 2)
                {
                    m_AttackImageSpeed = 0;
                    m_EnemyList[m_EnemyNumber].m_IsAttacked = false;
                }
            }

            PpuoooStateAttack();
            PpuoooStateAttacked();
        }

        private void UpdatewithBoss()
        {
            if (m_EnemyBossList.Count > 0)
            {
                for (int i = 0; i < m_EnemyBossList.Count; i++)
                    m_EnemyBossList[i].EnemyMoving();

                if (m_AttackImageSpeed++ > 2)
                {
                    m_AttackImageSpeed = 0;
                    m_EnemyBossList[m_EnemyNumber].m_IsAttacked = false;
                }
            }

            PpuoooStateAttack();
            PpuoooStateAttacked();
        }
       
        private void PpuoooStateAttack()
        {
            if (m_IsAttacking)
            {
                if (m_PpuoooAttackImageNumber++ > 2)
                {
                    m_PpuoooAttackImageNumber = 1;
                    m_IsAttacking = false;
                    CollisionInspectionWithAttack();
                }
            }
            else
            {
                m_PpuoooAttackImageNumber = 0;
            }
        }
        private void PpuoooStateAttacked()
        {
            if (m_IsAttacked)
            {
                if (m_AttackedImageSpeed++ > 2)
                {
                    m_AttackedImageSpeed = 0;
                    m_PpuoooHurt.Play();
                    m_IsAttacked = false;

                }
                m_PpuoooAttackImageNumber = 0;
            }

            CollisionInspectionWithAttacked();
            if (m_EnemyList.Count > 0)
            {
                if (m_EnemyList[m_EnemyNumber].m_IsAttacking)
                {
                    if (m_EnemyAttackImageNumber++ > 2)
                    {
                        m_EnermyAttack.Play();
                        m_EnemyAttackImageNumber = 0;
                        m_EnemyList[m_EnemyNumber].m_IsAttacking = false;
                        m_PpuoooHealth -= m_EnemyList[m_EnemyNumber].getEnemyPower();
                        if (m_PpuoooPosition_X > m_EnemyList[m_EnemyNumber].getPosition().X)
                            m_PpuoooPosition_X += 10;
                        else
                            m_PpuoooPosition_X -= 10;
                        m_IsAttacked = true;
                    }
                    if (m_EnemyList[m_EnemyNumber].m_IsAttacked)
                        m_EnemyList[m_EnemyNumber].m_IsAttacking = false;
                }
                else if (!m_EnemyList[m_EnemyNumber].m_IsAttacked)
                {
                    if (m_EnemyImageNumber++ > 5)
                        m_EnemyImageNumber = 0;
                    m_EnemyAttackImageNumber = 0;
                }
            }
            if (m_EnemyBossList.Count > 0)
            {
                if (m_EnemyBossList[m_EnemyBossNumber].m_IsAttacking)
                {
                    if (m_EnemyAttackImageNumber++ > 2)
                    {
                        m_EnermyAttack.Play();
                        m_EnemyBossAttackImageNumber = 0;
                        m_EnemyBossList[m_EnemyBossNumber].m_IsAttacking = false;
                        m_PpuoooHealth -= m_EnemyBossList[m_EnemyBossNumber].getEnemyPower();
                        if (m_PpuoooPosition_X > m_EnemyBossList[m_EnemyBossNumber].getPosition().X)
                            m_PpuoooPosition_X += 10;
                        else
                            m_PpuoooPosition_X -= 10;
                        m_IsAttacked = true;
                    }
                    if (m_EnemyBossList[m_EnemyNumber].m_IsAttacked)
                        m_EnemyBossList[m_EnemyNumber].m_IsAttacking = false;
                }
                else if (!m_EnemyBossList[m_EnemyBossNumber].m_IsAttacked)
                {
                    if (m_EnemyBossImageNumber++ > 5)
                        m_EnemyBossImageNumber = 0;
                    m_EnemyBossAttackImageNumber = 0;
                }
            }
        }
        
        private void CollisionInspectionWithAttack()
        {
            Rectangle PpuoooRec;

            if (!m_IsLeft)
                PpuoooRec = new Rectangle(m_PpuoooPosition_X + 60, m_PpuoooPosition_Y,
                 100, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));
            else
                PpuoooRec = new Rectangle(m_PpuoooPosition_X + 5, m_PpuoooPosition_Y,
                 100, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));


            for (int i = 0; i < m_EnemyList.Count; i++)
            {
                var EnemyRec = new Rectangle((int)(m_EnemyList[i].getPosition().X + m_TilePosition), (int)(m_EnemyList[i].getPosition().Y + m_TilePositionWithJump),
                    (int)(m_EnemyEntireImage.Width / 7 * m_EnemyBossSize), (int)(m_EnemyEntireImage.Height * m_EnemyImageSize));

                if (EnemyRec.Intersects(PpuoooRec))
                {
                    if (EnemyRec.X < PpuoooRec.X)
                        m_EnemyList[i].m_IsRight = true;
                    else
                        m_EnemyList[i].m_IsRight = false;
                    m_EnemyList[i].m_IsAttacked = true;
                    m_EnemyList[i].DecreaseHealth(m_PpuoooPower);
                    m_EnemyNumber = i;
                }
            }
            for (int i = 0; i < m_EnemyBossList.Count; i++)
            {
                var EnemyBossRec = new Rectangle((int)(m_EnemyBossList[i].getPosition().X + m_TilePosition), (int)(m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump),
                    (int)(m_EnemyBossImage.Width / 7 * m_EnemyBossSize), (int)(m_EnemyBossImage.Height * m_EnemyBossSize));

                if (EnemyBossRec.Intersects(PpuoooRec))
                {
                    if (EnemyBossRec.X < PpuoooRec.X)
                        m_EnemyBossList[i].m_IsRight = true;
                    else
                        m_EnemyBossList[i].m_IsRight = false;
                    m_EnemyBossList[i].m_IsAttacked = true;
                    m_EnemyBossList[i].DecreaseHealth(m_PpuoooPower);
                    m_EnemyBossNumber = i;
                }
            }
      
        }

     
        private void CollisionInspectionWithAttacked()
        {
            Rectangle PpuoooRec;

            if (!m_IsLeft)
                PpuoooRec = new Rectangle(m_PpuoooPosition_X + 60, m_PpuoooPosition_Y,
                 60, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));
            else
                PpuoooRec = new Rectangle(m_PpuoooPosition_X + 5, m_PpuoooPosition_Y,
                 60, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));


            for (int i = 0; i < m_EnemyList.Count; i++)
            {
                if (!m_EnemyList[i].m_IsDead && !m_IsDead)
                {
                    var EnemyRec = new Rectangle((int)(m_EnemyList[i].getPosition().X + m_TilePosition - 10), (int)(m_EnemyList[i].getPosition().Y + m_TilePositionWithJump),
                        (int)(m_EnemyEntireImage.Width / 7 * m_EnemyImageSize), (int)(m_EnemyEntireImage.Height * m_EnemyImageSize));

                    if (EnemyRec.Intersects(PpuoooRec))
                    {
                        if (EnemyRec.X < PpuoooRec.X)
                            m_EnemyList[i].m_IsRight = true;
                        else
                            m_EnemyList[i].m_IsRight = false;
                        m_EnemyList[i].m_IsAttacking = true;
                        m_EnemyNumber = i;
                    }
                }
            }
            for (int i = 0; i < m_EnemyBossList.Count; i++)
            {
                if (!m_EnemyBossList[i].m_IsDead && !m_IsDead)
                {
                    var EnemyBossRec = new Rectangle((int)(m_EnemyBossList[i].getPosition().X + m_TilePosition - 10), (int)(m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump),
                        (int)(m_EnemyBossImage.Width / 7 * m_EnemyBossSize), (int)(m_EnemyBossImage.Height * m_EnemyBossSize));

                    if (EnemyBossRec.Intersects(PpuoooRec))
                    {
                        if (EnemyBossRec.X < PpuoooRec.X)
                            m_EnemyBossList[i].m_IsRight = true;
                        else
                            m_EnemyBossList[i].m_IsRight = false;
                        m_EnemyBossList[i].m_IsAttacking = true;
                        m_EnemyBossNumber = i;
                    }
                }
            }
       
        }
       
        private void CollisionInspectionWithEnemy()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 60, m_PpuoooPosition_Y,
                 45, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            for (int i = 0; i < m_EnemyList.Count; i++)
            {
                if (!m_EnemyList[i].m_IsDead)
                {
                    var EnemyRec = new Rectangle((int)m_EnemyList[i].getPosition().X + m_TilePosition, (int)m_EnemyList[i].getPosition().Y + m_TilePositionWithJump, 100, 100);
                    if (EnemyRec.Intersects(PpuoooRec))
                    {
                        if (EnemyRec.X < PpuoooRec.X)
                            m_PpuoooPosition_X = (int)m_EnemyList[i].getPosition().X + m_TilePosition + 115;
                        else
                            m_PpuoooPosition_X = (int)m_EnemyList[i].getPosition().X + m_TilePosition - 115;
                    }
                }
            }
            for (int i = 0; i < m_EnemyBossList.Count; i++)
            {
                if (!m_EnemyBossList[i].m_IsDead)
                {
                    var EnemyBossRec = new Rectangle((int)m_EnemyBossList[i].getPosition().X + m_TilePosition, (int)m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump, 100, 100);
                    if (EnemyBossRec.Intersects(PpuoooRec))
                    {
                        if (EnemyBossRec.X < PpuoooRec.X)
                            m_PpuoooPosition_X = (int)m_EnemyBossList[i].getPosition().X + m_TilePosition + 115;
                        else
                            m_PpuoooPosition_X = (int)m_EnemyBossList[i].getPosition().X + m_TilePosition - 115;
                    }
                }
            }

  
        }
        /// <summary>
        /// /////////////////////////////////////////////////////
        /// </summary>

        private void UpdateWithStageElement()
        {
            if (m_IsAttacked)
            {
                if (m_AttackedImageSpeed++ > 2)
                {
                    m_AttackedImageSpeed = 0;
                    m_PpuoooHurt.Play();
                    m_IsAttacked = false;
                }
                m_PpuoooAttackImageNumber = 0;
            }

            if (m_IcePickList.Count > 0)
            {
                CollisionInspectionWithIcePick();
                if (m_IcePickList[m_IcePickNum].m_IsTouching)
                {
                    m_IcePickList[m_IcePickNum].m_IsTouching = false;

                    m_PpuoooHurt.Play();
                    m_PpuoooPosition_X -= 10;
                    PpuoooStateAttack();
                    m_PpuoooHealth -= 10;
                }
            }

            if (m_SnowFallList.Count > 0)
            {
                CollisionInspectionWithSnowFall();
                if (!m_SnowFallList[m_SnowFallNum].m_IsTouching)
                {
                    m_SnowFallList[m_SnowFallNum].m_IsTouching = false;
                }
            }

            if (m_LeafPieceList.Count > 0)
            {
                CollisionInspectionWithLeafPiece();
            }
            if (m_BeadPieceList.Count > 0)
            {
                CollisionInspectionWithBeadPiece();
            }
        }
        private void CollisionInspectionWithIcePick()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 55, m_PpuoooPosition_Y,
                 30, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            for (int i = 0; i < m_IcePickList.Count; i++)
            {
                if (!m_IcePickList[i].m_IsTouching)
                {
                    var IcePickRect = new Rectangle((int)(m_IcePickList[i].getPosition().X + 5 + m_TilePosition), (int)(m_IcePickList[i].getPosition().Y + m_TilePositionWithJump),
                        10, (int)(m_IcePick.Height * 0.38f));

                    if (IcePickRect.Intersects(PpuoooRec))
                    {
                        m_IcePickList[i].m_IsTouching = true;
                        m_IcePickNum = i;
                    }
                }
            }
        }
        private void CollisionInspectionWithSnowFall()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 55, m_PpuoooPosition_Y,
                 30, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            for (int i = 0; i < m_SnowFallList.Count; i++)
            {
                if (!m_SnowFallList[i].m_IsTouching)
                {
                    var m_SnowFallRect = new Rectangle((int)(m_SnowFallList[i].getPosition().X + m_TilePosition - 10), (int)(m_SnowFallList[i].getPosition().Y + m_TilePositionWithJump),
                        (int)(m_SnowFall.Width * 0.38f), (int)(m_SnowFall.Height * 0.38f));

                    if (m_SnowFallRect.Intersects(PpuoooRec))
                    {
                        m_SnowFallList[i].m_IsTouching = true;
                        m_SnowFallNum = i;
                    }
                }
            }
        }       
        private void CollisionInspectionWithIceFall()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 50, m_PpuoooPosition_Y,
                 35, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

        }
        private void CollisionInspectionWithBeadPiece()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 50, m_PpuoooPosition_Y,
                 35, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            for (int i = 0; i < m_BeadPieceList.Count; i++)
            {
                if (!m_BeadPieceList[i].m_IsTouching)
                {
                    var beaPRec = new Rectangle((int)(m_BeadPieceList[i].getPosition().X + m_TilePosition - 10 ), (int)(m_BeadPieceList[i].getPosition().Y + m_TilePositionWithJump),
                       100, (int)(m_BeadPiece.Height * 0.38f));

                    if (beaPRec.Intersects(PpuoooRec))
                    {
                        m_BeadPieceList[i].m_IsTouching = true;
                        m_BeadPieceNum = i;
                        m_CurrentBeads += 1;
                    }
                }
            }
        }
        private void CollisionInspectionWithLeafPiece()
        {
            Rectangle PpuoooRec;

            PpuoooRec = new Rectangle(m_PpuoooPosition_X + 50, m_PpuoooPosition_Y,
                 35, (int)(m_PpuoooMovingImage.Height * m_PpuoooImageSize));

            for (int i = 0; i < m_LeafPieceList.Count; i++)
            {
                if (!m_LeafPieceList[i].m_IsTouching)
                {
                    var LeafPieceRec = new Rectangle((int)(m_LeafPieceList[i].getPosition().X + m_TilePosition -10 ), (int)(m_LeafPieceList[i].getPosition().Y + m_TilePositionWithJump),
                       100, (int)(m_LeafPiece.Height * 0.38f));

                    if (LeafPieceRec.Intersects(PpuoooRec))
                    {
                        m_LeafPieceList[i].m_IsTouching = true;
                        m_LeafPieceNum = i;
                        m_CurrentLeafs += 1;
                    }
                }
            }
        }
       
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            DrawBackground(spriteBatch);
            DrawTile(spriteBatch);
            DrawStageElement(spriteBatch);
            DrawUI(spriteBatch);
            DrawEnemy(spriteBatch);
            DrawBossEnemy(spriteBatch);
            DrawPpuoooooo(spriteBatch);
            DrawControl(spriteBatch);
            
            
            spriteBatch.End();
        }
        #region Draw
        private void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_BackgroundImage, new Vector2(m_BackgroundPosition, 0), null, Color.White);
            spriteBatch.Draw(m_BackgroundImage2, new Vector2(m_BackgroundPosition2, 0), null, Color.White);
        }
        private void DrawTile(SpriteBatch spriteBath)
        {
            float completePosition_X = 0;
            float completePosition_Y = 0;

            float fieldSize = (float)(m_LeftField.Width * m_TileSize);
            int drawFieldDownPosition = (int)((m_StageSize + 800) / fieldSize) + 1;
            for (int i = 0; i < m_StageTile.Length; i++)
            {
                var tile_X = i % drawFieldDownPosition;
                var tile_Y = i / drawFieldDownPosition;

                switch (m_StageTile[i])
                {
                    case 0: break;
                    case 1: spriteBath.Draw(m_LeftField, new Vector2((fieldSize * tile_X) + m_TilePosition, m_TileInterval * tile_Y + m_TilePositionWithJump), null, Color.White, 0, Vector2.Zero, (float)m_TileSize, SpriteEffects.None, 0); break;
                    case 2: spriteBath.Draw(m_RightField, new Vector2((fieldSize * tile_X) + m_TilePosition, m_TileInterval * tile_Y + m_TilePositionWithJump), null, Color.White, 0, Vector2.Zero, (float)m_TileSize, SpriteEffects.None, 0); break;
                    case 3: spriteBath.Draw(m_FlatField, new Vector2((fieldSize * tile_X) + m_TilePosition, m_TileInterval * tile_Y + m_TilePositionWithJump), null, Color.White, 0, Vector2.Zero, (float)m_TileSize, SpriteEffects.None, 0); break;
                    case 4: spriteBath.Draw(m_ConvexField, new Vector2((fieldSize * tile_X) + m_TilePosition, m_TileInterval * tile_Y + m_TilePositionWithJump), null, Color.White, 0, Vector2.Zero, (float)m_TileSize, SpriteEffects.None, 0); break;

                    case 9: completePosition_X = tile_X; completePosition_Y = tile_Y; break;
                }
            }
            spriteBath.Draw(m_CompletePosition, new Vector2((fieldSize * completePosition_X) + m_TilePosition, m_TileInterval * completePosition_Y + m_TilePositionWithJump), null, Color.White, 0, Vector2.Zero, (float)(m_TileSize), SpriteEffects.None, 0);
        }
        private void DrawStageElement(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < m_BeadPieceList.Count; i++)
            {
                if (!m_BeadPieceList[i].m_IsTouching)
                {
                    spriteBatch.Draw(m_BeadPiece, new Vector2(m_BeadPieceList[i].getPosition().X + m_TilePosition, m_BeadPieceList[i].getPosition().Y + m_TilePositionWithJump),
                        new Rectangle(0, 0, m_BeadPiece.Width, m_BeadPiece.Height), Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
                }
            }
            for (int i = 0; i < m_IcePickList.Count; i++)
            {
                spriteBatch.Draw(m_IcePick, new Vector2(m_IcePickList[i].getPosition().X + m_TilePosition, m_IcePickList[i].getPosition().Y + m_TilePositionWithJump),
                    new Rectangle(0, 0, m_IcePick.Width, m_IcePick.Height), Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
            }
            for (int i = 0; i < m_SnowFallList.Count; i++)
            {
                if (!m_SnowFallList[i].m_IsTouching)
                {
                spriteBatch.Draw(m_SnowFall, new Vector2(m_SnowFallList[i].getPosition().X + m_TilePosition, m_SnowFallList[i].getPosition().Y + m_TilePositionWithJump),
                    new Rectangle(0, 0, m_SnowFall.Width, m_SnowFall.Height), Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
                }
            }
            for (int i = 0; i < m_LeafPieceList.Count; i++)
            {
                if (!m_LeafPieceList[i].m_IsTouching)
                {
                    spriteBatch.Draw(m_LeafPiece, new Vector2(m_LeafPieceList[i].getPosition().X + m_TilePosition, m_LeafPieceList[i].getPosition().Y + m_TilePositionWithJump),
                        new Rectangle(0, 0, m_LeafPiece.Width, m_LeafPiece.Height), Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
                }
            }
            
        }
        private void DrawEnemy(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < m_EnemyList.Count; i++)
            {
                if (!m_EnemyList[i].m_IsDead)
                {
                    if (m_EnemyList[i].m_IsAttacked)
                        spriteBatch.Draw(m_EnemyAttackedImage, new Vector2(m_EnemyList[i].getPosition().X + m_TilePosition, m_EnemyList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle(0, 0, m_EnemyAttackedImage.Width, m_EnemyAttackedImage.Height), Color.White, 0, Vector2.Zero, m_EnemyImageSize, m_EnemyList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                    else if (m_EnemyList[i].m_IsAttacking)
                        spriteBatch.Draw(m_EnemyAttackingImage, new Vector2(m_EnemyList[i].getPosition().X + m_TilePosition, m_EnemyList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle((m_EnemyAttackingImage.Width / 4 * m_EnemyAttackImageNumber), 0, (m_EnemyAttackingImage.Width / 4), m_EnemyAttackingImage.Height), Color.White, 0, Vector2.Zero, m_EnemyImageSize, m_EnemyList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                    else
                        spriteBatch.Draw(m_EnemyEntireImage, new Vector2(m_EnemyList[i].getPosition().X + m_TilePosition, m_EnemyList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle((m_EnemyEntireImage.Width / 7) * m_EnemyImageNumber, 0, (m_EnemyEntireImage.Width / 7), m_EnemyEntireImage.Height), Color.White, 0, Vector2.Zero, m_EnemyImageSize, m_EnemyList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                }
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawBossEnemy(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < m_EnemyBossList.Count; i++)
            {
                if (!m_EnemyBossList[i].m_IsDead)
                {
                    if (m_EnemyBossList[i].m_IsAttacked)
                        spriteBatch.Draw(m_EnemyBossTiredImage, new Vector2(m_EnemyBossList[i].getPosition().X + m_TilePosition, m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle(0, 0, m_EnemyBossTiredImage.Width, m_EnemyBossTiredImage.Height), Color.White, 0, Vector2.Zero, m_EnemyBossSize, m_EnemyBossList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                    else if (m_EnemyBossList[i].m_IsAttacking)
                        spriteBatch.Draw(m_EnemyBossAttackingImage, new Vector2(m_EnemyBossList[i].getPosition().X + m_TilePosition, m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle((m_EnemyBossAttackingImage.Width / 4 * m_EnemyBossAttackImageNumber), 0, (m_EnemyBossAttackingImage.Width / 4), m_EnemyBossAttackingImage.Height), Color.White, 0, Vector2.Zero, m_EnemyBossSize, m_EnemyBossList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                    else
                        spriteBatch.Draw(m_EnemyBossImage, new Vector2(m_EnemyBossList[i].getPosition().X + m_TilePosition, m_EnemyBossList[i].getPosition().Y + m_TilePositionWithJump),
                            new Rectangle((m_EnemyBossImage.Width / 7) * m_EnemyImageNumber, 0, ( m_EnemyBossImage.Width / 7),  m_EnemyBossImage.Height), Color.White, 0, Vector2.Zero, m_EnemyBossSize, m_EnemyBossList[i].m_IsRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                }
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawPpuoooooo(SpriteBatch spriteBatch)
        {
            if (m_IsAttacking)
            {
                Texture2D tempPpuoooImage = m_PpuoooAttackingImage;
                switch (selecedSkill)
                {
                    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearAction; break;
                    case SkillNumber.Panda: tempPpuoooImage = m_PandaAction; break;
                    case SkillNumber.Tuna: tempPpuoooImage = m_TunaAction; break;
                    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeAction; break;
                    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosAction; break;
                    case SkillNumber.Frog: tempPpuoooImage = m_FrogAction; break;
                    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloAction; break;
                }
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(m_PpuoooAttackImageNumber * m_PpuoooAttackingImage.Width / 4, 0, m_PpuoooAttackingImage.Width / 4, m_PpuoooAttackingImage.Width), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

            else if (m_IsAttacked)
            {
                Texture2D tempPpuoooImage = m_PpuoooAttackedImage;
                switch (selecedSkill)
                {
                    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearAttacked; break;
                    case SkillNumber.Panda: tempPpuoooImage = m_PandaAttacked; break;
                    case SkillNumber.Tuna: tempPpuoooImage = m_TunaAttacked; break;
                    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeAttacked; break;
                    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosAttacked; break;
                    case SkillNumber.Frog: tempPpuoooImage = m_FrogAttacked; break;
                    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloAttacked; break;
                }
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(0, 0, m_PpuoooAttackedImage.Width, m_PpuoooAttackedImage.Height), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

            else if (m_IsDead)
            {
                Texture2D tempPpuoooImage = m_PpuoooDyingImage;
                switch (selecedSkill)
                {
                    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearDying; break;
                    case SkillNumber.Panda: tempPpuoooImage = m_PandaDying; break;
                    case SkillNumber.Tuna: tempPpuoooImage = m_TunaDying; break;
                    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeDying; break;
                    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosDying; break;
                    case SkillNumber.Frog: tempPpuoooImage = m_FrogDying; break;
                    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloDying; break;
                }
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(m_PpuoooDieImageNumber * m_PpuoooDyingImage.Width / 2, 0, m_PpuoooDyingImage.Width / 2, m_PpuoooDyingImage.Height), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

            else if (m_IsJumping)
            {
                Texture2D tempPpuoooImage = m_PpuoooMovingImage;
                switch (selecedSkill)
                {
                    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearMoving; break;
                    case SkillNumber.Panda: tempPpuoooImage = m_PandaMoving; break;
                    case SkillNumber.Tuna: tempPpuoooImage = m_TunaMoving; break;
                    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeMoving; break;
                    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosMoving; break;
                    case SkillNumber.Frog: tempPpuoooImage = m_FrogMoving; break;
                    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloMoving; break;
                }
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(1 * m_PpuoooMovingImage.Width / 6, 0, m_PpuoooMovingImage.Width / 6, m_PpuoooMovingImage.Height), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

            else if (m_IsMoving)
            {
                Texture2D tempPpuoooImage = m_PpuoooMovingImage;
                switch (selecedSkill)
                {
                    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearMoving; break;
                    case SkillNumber.Panda: tempPpuoooImage = m_PandaMoving; break;
                    case SkillNumber.Tuna: tempPpuoooImage = m_TunaMoving; break;
                    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeMoving; break;
                    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosMoving; break;
                    case SkillNumber.Frog: tempPpuoooImage = m_FrogMoving; break;
                    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloMoving; break;
                }
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(m_PpuoooMovingImageNumber * m_PpuoooMovingImage.Width / 6, 0, m_PpuoooMovingImage.Width / 6, m_PpuoooMovingImage.Height), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }
            
            else
            {
                Texture2D tempPpuoooImage = m_PpuoooStandingImage;
                //switch (selecedSkill)
                //{
                //    case SkillNumber.PolarBear: tempPpuoooImage = m_PolarBearStanding; break;
                //    case SkillNumber.Panda: tempPpuoooImage = m_PandaStanding; break;
                //    case SkillNumber.Tuna: tempPpuoooImage = m_TunaStanding; break;
                //    case SkillNumber.Antelope: tempPpuoooImage = m_AntelopeStanding; break;
                //    case SkillNumber.Rhinoceros: tempPpuoooImage = m_RhinocerosStanding; break;
                //    case SkillNumber.Frog: tempPpuoooImage = m_FrogStanding; break;
                //    case SkillNumber.Armadillo: tempPpuoooImage = m_ArmadilloStanding; break;
                //}
                spriteBatch.Draw(tempPpuoooImage, new Vector2(m_PpuoooPosition_X, m_PpuoooPosition_Y), new Rectangle(m_PpuoooStandingImageNumber * m_PpuoooStandingImage.Width / 2, 0, m_PpuoooStandingImage.Width / 2, m_PpuoooStandingImage.Height), Color.White, 0, Vector2.Zero, m_PpuoooImageSize, m_IsLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }
        }
        private void DrawUI(SpriteBatch spriteBatch)
        {
            if (!m_IsDead && !m_IsSuccess)
            {
                m_OptionButton.Draw(spriteBatch);
                DrawControl(spriteBatch);
                DrawSkillState(spriteBatch);
            }

            Texture2D tempPpuoooState = m_PpuoooStateDead;
            if (m_SkillButton.isTouch)
                tempPpuoooState = m_PpuoooStateSkill;
            else if (m_PpuoooHealth >= 80)
                tempPpuoooState = m_PpuoooStateGood;
            else if (m_PpuoooHealth >= 50)
                tempPpuoooState = m_PpuoooStateTired;
            else if (m_PpuoooHealth >= 25)
            {
                m_TwinkleHardStateSpeed++;
                if (m_TwinkleHardStateSpeed < 10)
                {
                    tempPpuoooState = m_PpuoooStateHard_First;
                }
                else if (m_TwinkleHardStateSpeed < 20)
                {
                    tempPpuoooState = m_PpuoooStateHard_Second;
                    if (m_TwinkleHardStateSpeed == 19)
                        m_TwinkleHardStateSpeed = 0;
                }
            }
            else if (m_PpuoooHealth > 0)
            {
                m_TwinkleDangerStateSpeed++;
                if (m_TwinkleDangerStateSpeed < 5)
                {
                    tempPpuoooState = m_PpuoooStateDanger_First;
                }
                else if (m_TwinkleDangerStateSpeed < 10)
                {
                    tempPpuoooState = m_PpuoooStateDanger_Second;
                    if (m_TwinkleDangerStateSpeed == 9)
                        m_TwinkleDangerStateSpeed = 0;
                }
            }

            spriteBatch.Draw(tempPpuoooState, new Vector2(5, 5), null, Color.White, 0, Vector2.Zero, 0.52f, SpriteEffects.None, 0);

            spriteBatch.Draw(m_PpuoooHealthImage, new Vector2(100, 15), new Rectangle(0, 0, (m_PpuoooHealthImage.Width * m_PpuoooHealth / 100), m_PpuoooHealthImage.Height), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0);
            spriteBatch.DrawString(m_Font, m_PpuoooHealth.ToString() + "/100", new Vector2(100, 15), Color.Black);

            spriteBatch.Draw(m_PpuoooManaImage, new Vector2(100, 50), new Rectangle(0, 0, (m_PpuoooManaImage.Width * m_PpuoooMana / 100), m_PpuoooManaImage.Height), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0);
            spriteBatch.DrawString(m_Font, m_PpuoooMana.ToString() + "/100", new Vector2(100, 50), Color.Black);

            spriteBatch.Draw(m_BeadPiece, new Vector2(100, 95), null, Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
            spriteBatch.DrawString(m_Font, "X " + m_CurrentBeads.ToString(), new Vector2(140, 95), Color.Black);

            spriteBatch.Draw(m_LeafPiece, new Vector2(10, 95), null, Color.White, 0, Vector2.Zero, 0.38f, SpriteEffects.None, 0);
            spriteBatch.DrawString(m_Font, "X " + m_CurrentLeafs.ToString(), new Vector2(50, 95), Color.Black);
        }
        private void DrawSkillState(SpriteBatch spriteBatch)
        {
            Vector2 Border;
            switch (selecedSkill)
            {
                case SkillNumber.Ppuooo: Border = new Vector2(500, 5); break;
                case SkillNumber.PolarBear: Border = new Vector2(540, 5); break;
                case SkillNumber.Tuna: Border = new Vector2(580, 45); break;
                case SkillNumber.Panda: Border = new Vector2(580, 5); break;
                case SkillNumber.Antelope: Border = new Vector2(500, 45); break;
                case SkillNumber.Rhinoceros: Border = new Vector2(540, 45); break;
                case SkillNumber.Frog: Border = new Vector2(620, 5); break;
                default: Border = new Vector2(580, 45); break;
            }
            spriteBatch.Draw(m_CurrentSkillState, new Vector2(500, 5), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            spriteBatch.Draw(m_CurrentSkillBorder, Border, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
        }
        private void DrawControl(SpriteBatch spriteBatch)
        {
            if (!m_IsDead && !m_IsSuccess)
            {
                m_LeftButton.Draw(spriteBatch);
                m_RightButton.Draw(spriteBatch);
                m_JumpButton.Draw(spriteBatch);
                m_SkillButton.Draw(spriteBatch);
                m_ActionButton.Draw(spriteBatch);
            }

            if (m_IsPressOption)
                DrawOptionMenu(spriteBatch);

            if (m_IsDead)
                m_FailedButton.Draw(spriteBatch);
            else if (m_IsSuccess)
                m_SuccessButton.Draw(spriteBatch);
        }
        private void DrawOptionMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_OptionBackground, new Vector2(50, 50), null, Color.White, 0, Vector2.Zero, 0.43f, SpriteEffects.None, 0);
            m_ContinueButton.Draw(spriteBatch);
            m_ResetButton.Draw(spriteBatch);
            m_HomeButton.Draw(spriteBatch);
        }
        #endregion
    }
}
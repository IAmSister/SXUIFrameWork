

using System.Security.Permissions;
//using Games.SkillModle;
using GCGame;
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
//using Games.Events;
//using Games.Animation_Modle;
using GCGame.Table;
//using Module.Log;

    public partial class Obj_Character : Obj_Mono
    {

        #region Obj移动相关
       //obj的移动速度,无NavAgent时使用
        public float m_fMoveSpeed = 5.0f;

        //是否在移动中
        private bool m_bIsMoving;
        public bool IsMoving
        {
            get { return m_bIsMoving; }
            set
            {
                m_bIsMoving = value;
            }
        }

        private bool m_bIsTracing = false;//是否在追踪
        public bool IsTracing
        {
            get { return m_bIsTracing; }
            set { m_bIsTracing = value; }
        }

        //移动的目标点
        private Vector3 m_vecTargetPos;
        public Vector3 VecTargetPos
        {
            get { return m_vecTargetPos; }
            set
            {
                m_vecTargetPos = value;
                m_bIsMoving = true;
            }
        }

        //寻路代理
        private UnityEngine.AI.NavMeshAgent m_NavAgent = null;
        public UnityEngine.AI.NavMeshAgent NavAgent
        {
            get { return m_NavAgent; }
            set { m_NavAgent = value; }
        }

        /// <summary>
        /// 初始化寻路代理
        /// </summary>
        public void InitNavAgent()
        {
            //获取寻路 没有添加
            //寻路不空开始设置数据
          
        }

        private bool m_bIsMoveToNoFaceTo = false; //调用moveto时 是否禁用了朝向旋转
        public bool IsMoveToNoFaceTo
        {
            get { return m_bIsMoveToNoFaceTo; }
            set { m_bIsMoveToNoFaceTo = value; }
        }

        private UniformAcceleratedMotion m_AcceleratedMotion = null; //UniformAcceleratedMotion���
        public UniformAcceleratedMotion AcceleratedMotion
        {
            get { return m_AcceleratedMotion; }
            set { m_AcceleratedMotion = value; }
        }

        //是否允许移动过程中根据目标点调整方向
        private bool m_EnableMovingRotation = true;
        /// <summary>
        /// 打开移动旋转
        /// </summary>
        /// <param name="bEnable"></param>
        public void EnableMovingRotation(bool bEnable)
        {
            //角度速度 寻路不空 可以打开 速度30000.0f 否则0
           
        }
        private GameObject m_MoveTarget = null;
        
        public GameObject MoveTarget
        {
            get { return m_MoveTarget; }
            set
            {
                if (value != m_MoveTarget)
                {
                    m_MoveTarget = value;
                    if (null != m_MoveTarget)
                    {
                        m_moveTargetTrans = m_MoveTarget.transform;
                    }
                    else
                    {
                        m_moveTargetTrans = null;
                    }
                }
            }
        }
        //停止距离
        private float m_fStopRange;
        public float StopRange
        {
            get { return m_fStopRange; }
            set { m_fStopRange = value; }
        }
        //防卡住措施
        private Vector3 m_LastPosition = new Vector3(0, 0, 0);
        private float m_LastPositionTime = 0.0f;

        public bool m_IsMJ = false;
        /// <summary>
        /// 重新设置移动后时间
        /// </summary>
        void ResetMoveOverEvent()
        {
           
        }
        /// <summary>
        /// 在移动之前操作
        /// </summary>
        /// <param name="bIsAutoSearch"></param>
        public void BeforeMoveTo(bool bIsAutoSearch)
        {

        }
        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="targetObj"></param>
        /// <param name="fStopRange"></param>
        /// <param name="bIsAutoSearch"></param>
        public void MoveTo(Vector3 targetPos, GameObject targetObj = null, float fStopRange = 2.0f, bool bIsAutoSearch = false)
        {

         
        }
        /// <summary>
        /// 停止移动
        /// </summary>
        public void StopMove()
        {
            
        }

        /// <summary>
        /// 面向镜头
        /// </summary>
        public void FaceToScreen()
        {
            gameObject.transform.Rotate(new Vector3(0, 145, 0));
        }

        /// <summary>
        /// 面向一个位置
        /// </summary>
        /// <param name="facePos"></param>
        public void FaceTo(Vector3 facePos)
        {
           
        }

     
        Transform m_moveTargetTrans = null;
        /// <summary>
        /// 更新目标移动
        /// </summary>
        protected void UpdateTargetMove()
        {
            
        }
        /// <summary>
        /// 移动后操作
        /// </summary>
        protected virtual void OnMoveOver()
        {
        }

       
        static float s_MovingCheckInterval = 0.5f;
       /// <summary>
       /// 移动到一个位置
       /// </summary>
       /// <param name="targetPos"></param>
       /// <param name="fStopRange"></param>
        public void MoveToPosition(Vector3 targetPos, float fStopRange)
        {

           
           
        }

        private int m_Tag = 0;
        /// <summary>
        /// 其他玩家移动
        /// </summary>
        private void OtherPlayerMove()
        {
          
        }
        /// <summary>
        /// 其他玩家是否移动
        /// </summary>
        private bool OtherPlayerIsMove(Vector3 targetPos, float fStopRange)
        {

            return true;
        }

      
        private GameDefine_Globe.OBJ_ANIMSTATE m_CurObjAnimState;
     
        public GameDefine_Globe.OBJ_ANIMSTATE CurObjAnimState
        {
            get { return m_CurObjAnimState; }
            set
            {
                OnSwithObjAnimState(value);
            }
        }
        private string m_AnimationFilePath = "";
        public string AnimationFilePath
        {
            get { return m_AnimationFilePath; }
            set { m_AnimationFilePath = value; }
        }

        public float walkMaxAnimationSpeed = 0.75f;

        protected Animation m_Objanimation; //玩家动画控制器
        public UnityEngine.Animation Objanimation
        {
            get { return m_Objanimation; }

        }

       /// <summary>
       /// 初始化控制器
       /// </summary>
        public void InitAnimation()
        {
           
        }
        /// <summary>
        /// 更新控制器
        /// </summary>
        protected void UpdateAnimation()
        {
          
        }

        private float m_fLastPlayHitSoundTime = 0; 
        /// <summary>
        /// 选择物体动画状态
        /// </summary>
        /// <param name="ObjState"></param>
        public virtual void OnSwithObjAnimState(GameDefine_Globe.OBJ_ANIMSTATE ObjState)
        {



        }
        /// <summary>
        /// 默认状态
        /// </summary>
        void ProcessIdleAnimState()
        {
           
        }
        /// <summary>
        /// 行走状态
        /// </summary>
        void ProcessWalkAnimState()
        {
           
        }

        /// <summary>
        ///有衰减的音效播放，目前用在NPC的受击、死亡音效上
        /// </summary>
        /// <param name="ObjType"></param>
        /// <param name="nSoundID"></param>
        /// <param name="playingPos"></param>
        public void PlaySoundAtPos(GameDefine_Globe.OBJ_TYPE ObjType, int nSoundID, Vector3 playingPos)
        {
           
        }

        /// <summary>
        ///  行走状态处理
        /// </summary>
        void ProcessDeathAnimState()
        {
            
        }
        /// <summary>
        /// 受击状态处理
        /// </summary>
        void ProcessHitAnimState()
        {
          
        }
        //隐身
        public float m_fXSLastTime = 8.0f;
        private float m_fYScurTime = 0.0f;
        public bool m_bIsYS = false;
        GameObject obj3 = null;
        GameObject obj4 = null;
        GameObject obj5 = null;
        /// <summary>
        /// 攻击
        /// </summary>
        public void AttackYS()
        {
          

        }
        /// <summary>
        /// 更新攻击技能
        /// </summary>
        public void UpdateAttckYS()
        {

           


        }
        //消失
        private float m_fXSLastTime2 = 0.467f;
        private float m_fXSLastTime3 = 1.667f;
        private float m_fXScurTime = 0.0f;
        private bool m_bIsXS = false;
        public void AttackXS()
        {
            if (m_bIsXS)
            {
                return;
            }

            m_bIsXS = true;
            m_fXScurTime = Time.time;

            StopMove();
            
        }
        GameObject obj2 = null;
        public void UpdateAttckXS()
        {

            

        }
        //后退
        private float m_fHTLastTime = 1.1f;
        private float m_fHTcurTime = 0.0f;
        private bool m_bIsCanHT = false;
        private Vector3 m_vecHTTarget = Vector3.zero;
        private float m_fHTSpeed = 1;
        private Vector3 m_vecHTTar2 = Vector3.zero;
        public void AttackHT()
        {
          

        }

        public void UpdateAttckHT()
        {

        
        }
        //瞬移
        private float m_fSXLastTime = 1.0f;
        private float m_fSXcurTime = 0.0f;
        private bool m_bIsCanSY = false;
        private Vector3 m_vecTarget = Vector3.zero;
        private float m_fSYSpeed = 300;
        private Vector3 m_vecTar2 = Vector3.zero;
        public void AttackSY()
        {
          
        }

        public void UpdateAttckSY()
        {

         

        }
        //普攻前的冲锋
        private float m_fAttackPGCFSpeed = 12.0f;
        private float m_fAttackPGCFLastTime = 3.0f;
        private float m_fAttackPGCFMaxHight = 0.0f;
        private float m_fAttckPGCFBeginTime = 0.0f;
        private Vector3 m_VecAttcakPGCFSrc = new Vector3(0, 0, 0);
        private Vector3 m_VecAttcakPGCFDst = new Vector3(0, 0, 0);
        public bool m_bIsCanPGCF = false;
        private Obj_Character m_cfPGTarget = null;

        public void AttackPGCF(Obj_Character vtarget)
        {
         
        }

        public void UpdateAttckPGCF(int profess)
        {
         	

        }
        public void EndAttckPGCF()
        {
         
        }

       //冲锋
        private float m_fAttackCFSpeed = 12.0f;
        private float m_fAttackCFLastTime = 3.0f;
        private float m_fAttackCFMaxHight = 0.0f;
        private float m_fAttckCFBeginTime = 0.0f;
        private Vector3 m_VecAttcakCFSrc = new Vector3(0, 0, 0);
        private Vector3 m_VecAttcakCFDst = new Vector3(0, 0, 0);
        public bool m_bIsCanCF = false;
        private Obj_Character m_cfTarget = null;

        public void AttackCF(Obj_Character vtarget)
        {
        }

        public void UpdateAttckCF(int profess)
        {

        }
        public void EndAttckCF()
        {
            m_bIsCanCF = false;
          
        }
        private float m_fAttackFlySpeed = 0.0f;
        private float m_fAttackFlyTime = 0.0f;
        private float m_fAttackFlyMaxHight = 0.0f;
        private float m_fAttckFlyBeginTime = 0.0f;
        private Vector3 m_VecAttcakFlySrc = new Vector3(0, 0, 0);
        private Vector3 m_VecAttcakFlyDst = new Vector3(0, 0, 0);
        private bool m_bIsCanAttckFly = false;
        public void AttackFly(int nDis, int nHight, float fTime)
        {
            
        }

        public void UpdateAttckFly()
        {
          
        }
      
        /// <summary>
        /// 动画回调
        /// </summary>
        /// <param name="animationID"></param>
        virtual public void OnAnimationCallBack(int animationID)
        {


        }
        virtual public void OnAnimationFinish(int animationID)
        {

          
        }

        private int m_AnimInfoNextAnimId; 
        public int AnimInfoNextAnimId
        {
            get { return m_AnimInfoNextAnimId; }
            set { m_AnimInfoNextAnimId = value; }
        }

        virtual public void OnAnimationStop(int aninationID)
        {
           
        }
        /// <summary>
        /// 检查是否是冲锋
        /// </summary>
        /// <param name="skillid"></param>
        /// <returns></returns>
        public bool CheckChongFeng(int skillid)
        {
            return false;
        }
        public bool IsMoveNavAgent(Vector3 targetVector3)
        {
            if (this.m_NavAgent == null)
            {
                return false;
            }
            return this.m_NavAgent.CalculatePath(targetVector3, this.m_NavAgent.path);
        }
        // by dys 检查是否是普攻
        public bool CheckPG()//SkillCore skillcore
        { return false; }

            /// <summary>
            /// 设置慢镜头
            /// </summary>
            public void SetMJ()
        {
            m_IsMJ = !m_IsMJ;
        }
        #endregion
    
}
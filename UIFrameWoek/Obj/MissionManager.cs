

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GCGame.Table;
using Games.LogicObj;
using Games.GlobeDefine;

namespace Games.Mission
{
    //任务类型
    public enum MISSIONTYPE
    {
        MISSION_INVALID = -1,
        MISSION_DAILY = 0,  //日常
        MISSION_MAIN = 1,   //主线
        MISSION_BRANCH = 2, //支线
        MISSION_GUILD = 3,  //帮会
        MISSION_MASTER = 4, //师门
        MISSION_BIZ = 17
    }

    // 任务逻辑类型
    public enum TableType
    {
        Table_Invalid = -1,
        Table_Story,          //剧情
        Table_KillMonster,    //杀怪
        Table_Delivery,   // 送信
        Table_CollectItem,   //杀怪掉落
        Table_Enterarea,  // 探索区域
        Table_LootItem,   // 杀怪掉落
        Table_CopySceneMonster,   // 副本杀怪掉落
        Table_LevelUp,  // 升级
        Table_OperationNum, // 操作次数
        Mission_Num
    }
    public enum DailyMissionType
    {
        DailyMissionType_Invalid = -1,
        DailyMissionType_Master,          //门派
        DailyMissionType_KillMonster,    //杀怪
        DailyMissionType_CopyScene,     //副本
        DailyMissionType_Strength,   // 强化
        DailyMissionType_Pvp,  // 竞技
        DailyMissionType_GuildWar,   // 帮战
        DailyMissionType_Award,   // 抽奖
        DailyMissionType_Belle,   // 美人
        DailyMissionType_Fellow,   // 伙伴
        DailyMissionType_Num
    }

    public enum MissionState
    {
        Mission_None,       // 未接取
        Mission_Accepted,   // 已接任务未完成
        Mission_Completed,  // 已完成未提交
        Mission_Failed,     // 任务失败
    }

    public enum MISSION_QUALITY
    {
        MISSION_QUALITY_NONE = 0,
        MISSION_QUALITY_WHITE = 1,
        MISSION_QUALITY_GREEN = 2,
        MISSION_QUALITY_BLUE = 3,
        MISSION_QUALITY_PURPLE = 4,
        MISSION_QUALITY_ORANGE = 5,
    }

    /// <summary>
    /// 当前拥有的任务信息,需要服务器同步
    /// </summary>
    public class CurOwnMission
    {
        public const byte MAX_MISSION_PARAM_NUM = 8;

        public int m_nMissionID;   //任务ID

        public byte m_yStatus;      //任务状态，1表示进行中，2表示完成，3表示失败
        public byte m_yFlags;       // 0x0000 |FollowChanged事件|ItemChanged事件|EnterZone事件|KillObject事件|
        public byte m_yQuality;    // 任务品质 白、绿、蓝、紫、橙
        public Int32[] m_nParam;

        public CurOwnMission()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            if (null == m_nParam)
            {
                m_nParam = new Int32[MAX_MISSION_PARAM_NUM];
            }
            m_nMissionID = -1;
            m_yStatus = 0;
            m_yFlags = 0;
            m_yQuality = 0;

            for (int i = 0; i < MAX_MISSION_PARAM_NUM; ++i)
            {
                m_nParam[i] = 0;
            }
        }

        public void SetStatus(byte status)
        {
            m_yStatus = status;
        }
    }

    /// <summary>
    /// 任务列表
    /// </summary>
    public class MissionList
    {
        public const byte MAX_CHAR_MISSION_NUM = 9;
        public const UInt16 MAX_CHAR_MISSION_FLAG_LEN = 32;

        public byte m_Count = 0;

        public Dictionary<int, CurOwnMission> m_aMission;         //角色目前拥有的任务数据
        public UInt32[] m_aMissionHaveDoneFlags;   //角色的任务完成标志，支持最多1024个任务

        public MissionList()
        {
            m_Count = 0;
            m_aMission = new Dictionary<int, CurOwnMission>();
            m_aMissionHaveDoneFlags = new UInt32[MAX_CHAR_MISSION_FLAG_LEN];
        }

        public bool IsMissionFull()
        {
            if (m_aMission.Count > MAX_CHAR_MISSION_NUM)
            {
                return true;
            }
            return false;
        }

        public void CleanUp()
        {
            m_aMission.Clear();
            for (int i = 0; i < MAX_CHAR_MISSION_FLAG_LEN; i++)
            {
                m_aMissionHaveDoneFlags[i] = 0;
            }
        }

    };

    public class MissionManager
    {
        private MissionList m_MissionList;  //任务列表

        // 忽略前序任务标记
        private int m_IgnoreMissionPreFlag;
        public int IgnoreMissionPreFlag
        {
            set { m_IgnoreMissionPreFlag = value; }
        }

        public MissionManager()
        {
            m_MissionList = new MissionList();
            m_IgnoreMissionPreFlag = 0;
        }

        /// <summary>
        /// 客户端检查，是否可以接受任务
        /// </summary>
        /// <param name="nMissionID">任务ID</param>
        /// <returns>成功与否</returns>
        public bool CanAcceptMission(int nMissionID)
        {
   
            return true;
        }

        public bool CanDoAcceptMission(int nMissionID)
        {

            return true;
        }



        /// <summary>
        /// 客户端添加任务
        /// </summary>
        /// <param name="nMissionID">任务ID</param>
        /// <returns>返回添加成功与否</returns>
        bool AddMission(int nMissionID, byte yQuality)
        {
            if (nMissionID < 0)
            {
                return false;
            }

            if (m_MissionList.m_aMission.ContainsKey(nMissionID))
            {
                return false;
            }

            CurOwnMission tempMission = new CurOwnMission();
            tempMission.CleanUp();
            tempMission.m_nMissionID = nMissionID;
            tempMission.m_yQuality = yQuality;
            m_MissionList.m_aMission.Add(nMissionID, tempMission);

            return true;
        }

        /// <summary>
        /// 客户端删除一个任务
        /// </summary>
        /// <param name="nMissionID"></param>
        /// <returns></returns>
        bool DelMission(int nMissionID)
        {
            if (nMissionID < 0)
            {
                return false;
            }

            bool bRet = m_MissionList.m_aMission.Remove(nMissionID);
            return bRet;
        }

        /// <summary>
        /// 完成任务，这里以后需要由服务器同步过来
        /// </summary>
        /// <param name="nMissionID"></param>
        /// <returns></returns>
        bool SetMissionHaveDone(int nMissionID)
        {
            int idIndex = (nMissionID >> 5);
            if (idIndex < MissionList.MAX_CHAR_MISSION_FLAG_LEN)
            {
                UInt32 uData = (UInt32)nMissionID & 0x0000001f;
                m_MissionList.m_aMissionHaveDoneFlags[idIndex] |= (UInt32)(0x00000001 << (Int32)uData);

                return true;
            }
            return false;
        }

        bool IsMissionHaveDone(int nMissionID)
        {
            if (nMissionID < 0)
            {
                return false;
            }
            int idIndex = (nMissionID >> 5);
            if (idIndex < MissionList.MAX_CHAR_MISSION_FLAG_LEN)
            {
                UInt32 uRet = (UInt32)(0x00000001 << ((Int32)nMissionID & 0x0000001F)) & m_MissionList.m_aMissionHaveDoneFlags[idIndex];
                return (uRet != 0);
            }

            return false;
        }

        public bool IsMissionNotFaild(int missionId)
        {
            if (IsHaveMission(missionId))
            {
                MissionState missionState = (MissionState)GetMissionState(missionId);
                if ((missionState != MissionState.Mission_None) && (missionState != MissionState.Mission_Failed))
                {
                    return true;
                }
            }
            return false;
        }

        // 通过任务ID取该任务在任务表表的索引值， 无该任务时返回UINT_MAX
        public int GetMissionIndexByID(int nMissionID) { return 1; }

        // 任务参数
        public void SetMissionParam(int nMissionID, int nParamIndex, int nValue)
        {
       

        }
        public int GetMissionParam(int nMissionID, int nParamIndex)
        {
            if (!m_MissionList.m_aMission.ContainsKey(nMissionID))
            {
                return -1;
            }
            if (nParamIndex >= 0 && nParamIndex < CurOwnMission.MAX_MISSION_PARAM_NUM)
            {
                return m_MissionList.m_aMission[nMissionID].m_nParam[nParamIndex];
            }
            return -1;
        }

        // 接任务 给服务器发包
        public bool AcceptMission(int nMissionID)
        {
            // 添加任务接取判断条件

            // 给服务器发包


            return true;
        }

        // 任务接取成功后 客户端处理
        public bool AddMissionToUser(int nMissionID, byte yQualityType)
        {
            return true;
        }

        // 提交任务，给服务器发包
        public bool CompleteMission(int nMissionID)
        {
        

            return true;
        }

        // 任务提交成功后 客户端处理
        public bool CompleteMissionOver(int nMissionID)
        {

            return true;
        }

        // 放弃任务
        public bool AbandonMission(int nMissionID)
        {


            return true;
        }

        public bool AbandonMissionOver(int nMissionID)
        {

 
            return true;
        }

        public bool IsHaveMission(int nMissionID)
        {
            if (nMissionID < 0)
            {
                return false;
            }

            if (m_MissionList.m_aMission.ContainsKey(nMissionID))
            {
                return true;
            }
            return false;
        }
        public bool SetMissionState(int nMissionID, byte nStatus)
        {
      

            return true;
        }
        public byte GetMissionState(int nMissionID)
        {
            if (false == IsHaveMission(nMissionID))
            {
                return 0;
            }
            return m_MissionList.m_aMission[nMissionID].m_yStatus;
        }

        public byte GetMissionQuality(int nMissionID)
        {
            if (true == IsHaveMission(nMissionID))
            {
                return m_MissionList.m_aMission[nMissionID].m_yQuality;
            }
            return (byte)MISSION_QUALITY.MISSION_QUALITY_NONE;
        }

        // 任务更新UI
        public void NotifyMissionUI(int nMissionID, string strOpt)
        {
    

        }

        public bool IsClientMission(int nMissionID)
        {

            return false;
        }

        // 剧情任务 在客户端完成
        public bool SetStoryMissionState(int nMissionID, byte byState)
        {
          
            return false;
        }

        // 获取玩家身上的任务
        public List<int> GetAllMissionID()
        {
            List<int> nMissionIDList = new List<int>();

           
            return nMissionIDList;
        }

        // 获取玩家身上的非日常任务
        public List<int> GetAllNotDailyMissionList()
        {
            List<int> nMissionIDList = new List<int>();

          
            
            return nMissionIDList;
        }

        // 遍历场景中前nNum个可接任务（按等级先大后小） 任务日志用
        public List<int> GetCanAcceptedMissionID(int nNum)
        {
          

            return new List<int>();
        }
        // 按任务限制等级排序 任务日志用
        bool AddMissionIDByLevel(List<int> MissionList, int nMissionID)
        {
        

            return true;
        }

        // 任务追踪、任务日志寻路
        public void MissionPathFinder(int nMissionID)
        {
        
        }

        // 任务寻路完成后 任务相关事件处理
        void MoveOverMissionEvent(int nMissionID)
        {

        
        }

        //MissionBoard用，Npc头顶任务特效
        //public bool IsHaveMissionAccepted(Obj_NPC oNpc)
        //{
           

        //    return false;
        //}
     
       

       

        // 采集任务处理
        public void MissionCollectItem()
        {
           
            
        }

        // 显示日常任务界面
        void OpenDailyMissionUI()
        {//关闭其它主界面
            
        }

        void OpenGuildMissionWindow()
        {//关闭其它主界面
          
        }

        // 显示任务界面
        void OpenMissionUI()
        {
           
        }

        void OpenDailyLuckyUI()
        {
           
        }

        int GetDailyMissionType(int nMissionID)
        {

            // return DailyMission.Type;
            return 0;
        }

        void ShowDailyMissionOver(bool bSuccess, object param)
        {

        }

        void ShowGuildMissionOver(bool bSuccess, object param)
        {
        }

        // 特殊不可接任务
        public bool SpecialMission_CanAccept(int nMissionID)
        {

            return true;
        }

        // 新手指引任务 点击指引
        bool Mission_NewPlayerGuide(int nMissionID)
        {
          
            return false;
        }

        // 日常任务 显示对应界面
        bool OpenMissionWindow(int nMissionID)
        {
          

            return false;
        }
        void OpenEquipStar(bool bSuccess, object param)
        {
        
        }

        void OpenEquipGem(bool bSuccess, object param)
        {
    
        }

        void OpenRoleView(bool bSuccess, object param)
        {
      
        }
        void OpenFellow(bool bSuccess, object param)
        {
          
        }
        // 任务相关 打开相关界面
        void ShowMissionWindow(bool bSuccess, object param)
        {

          
        }
    }

}

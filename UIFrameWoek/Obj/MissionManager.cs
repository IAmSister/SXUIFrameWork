

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
    //��������
    public enum MISSIONTYPE
    {
        MISSION_INVALID = -1,
        MISSION_DAILY = 0,  //�ճ�
        MISSION_MAIN = 1,   //����
        MISSION_BRANCH = 2, //֧��
        MISSION_GUILD = 3,  //���
        MISSION_MASTER = 4, //ʦ��
        MISSION_BIZ = 17
    }

    // �����߼�����
    public enum TableType
    {
        Table_Invalid = -1,
        Table_Story,          //����
        Table_KillMonster,    //ɱ��
        Table_Delivery,   // ����
        Table_CollectItem,   //ɱ�ֵ���
        Table_Enterarea,  // ̽������
        Table_LootItem,   // ɱ�ֵ���
        Table_CopySceneMonster,   // ����ɱ�ֵ���
        Table_LevelUp,  // ����
        Table_OperationNum, // ��������
        Mission_Num
    }
    public enum DailyMissionType
    {
        DailyMissionType_Invalid = -1,
        DailyMissionType_Master,          //����
        DailyMissionType_KillMonster,    //ɱ��
        DailyMissionType_CopyScene,     //����
        DailyMissionType_Strength,   // ǿ��
        DailyMissionType_Pvp,  // ����
        DailyMissionType_GuildWar,   // ��ս
        DailyMissionType_Award,   // �齱
        DailyMissionType_Belle,   // ����
        DailyMissionType_Fellow,   // ���
        DailyMissionType_Num
    }

    public enum MissionState
    {
        Mission_None,       // δ��ȡ
        Mission_Accepted,   // �ѽ�����δ���
        Mission_Completed,  // �����δ�ύ
        Mission_Failed,     // ����ʧ��
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
    /// ��ǰӵ�е�������Ϣ,��Ҫ������ͬ��
    /// </summary>
    public class CurOwnMission
    {
        public const byte MAX_MISSION_PARAM_NUM = 8;

        public int m_nMissionID;   //����ID

        public byte m_yStatus;      //����״̬��1��ʾ�����У�2��ʾ��ɣ�3��ʾʧ��
        public byte m_yFlags;       // 0x0000 |FollowChanged�¼�|ItemChanged�¼�|EnterZone�¼�|KillObject�¼�|
        public byte m_yQuality;    // ����Ʒ�� �ס��̡������ϡ���
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
    /// �����б�
    /// </summary>
    public class MissionList
    {
        public const byte MAX_CHAR_MISSION_NUM = 9;
        public const UInt16 MAX_CHAR_MISSION_FLAG_LEN = 32;

        public byte m_Count = 0;

        public Dictionary<int, CurOwnMission> m_aMission;         //��ɫĿǰӵ�е���������
        public UInt32[] m_aMissionHaveDoneFlags;   //��ɫ��������ɱ�־��֧�����1024������

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
        private MissionList m_MissionList;  //�����б�

        // ����ǰ��������
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
        /// �ͻ��˼�飬�Ƿ���Խ�������
        /// </summary>
        /// <param name="nMissionID">����ID</param>
        /// <returns>�ɹ����</returns>
        public bool CanAcceptMission(int nMissionID)
        {
   
            return true;
        }

        public bool CanDoAcceptMission(int nMissionID)
        {

            return true;
        }



        /// <summary>
        /// �ͻ����������
        /// </summary>
        /// <param name="nMissionID">����ID</param>
        /// <returns>������ӳɹ����</returns>
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
        /// �ͻ���ɾ��һ������
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
        /// ������������Ժ���Ҫ�ɷ�����ͬ������
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

        // ͨ������IDȡ�������������������ֵ�� �޸�����ʱ����UINT_MAX
        public int GetMissionIndexByID(int nMissionID) { return 1; }

        // �������
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

        // ������ ������������
        public bool AcceptMission(int nMissionID)
        {
            // ��������ȡ�ж�����

            // ������������


            return true;
        }

        // �����ȡ�ɹ��� �ͻ��˴���
        public bool AddMissionToUser(int nMissionID, byte yQualityType)
        {
            return true;
        }

        // �ύ���񣬸�����������
        public bool CompleteMission(int nMissionID)
        {
        

            return true;
        }

        // �����ύ�ɹ��� �ͻ��˴���
        public bool CompleteMissionOver(int nMissionID)
        {

            return true;
        }

        // ��������
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

        // �������UI
        public void NotifyMissionUI(int nMissionID, string strOpt)
        {
    

        }

        public bool IsClientMission(int nMissionID)
        {

            return false;
        }

        // �������� �ڿͻ������
        public bool SetStoryMissionState(int nMissionID, byte byState)
        {
          
            return false;
        }

        // ��ȡ������ϵ�����
        public List<int> GetAllMissionID()
        {
            List<int> nMissionIDList = new List<int>();

           
            return nMissionIDList;
        }

        // ��ȡ������ϵķ��ճ�����
        public List<int> GetAllNotDailyMissionList()
        {
            List<int> nMissionIDList = new List<int>();

          
            
            return nMissionIDList;
        }

        // ����������ǰnNum���ɽ����񣨰��ȼ��ȴ��С�� ������־��
        public List<int> GetCanAcceptedMissionID(int nNum)
        {
          

            return new List<int>();
        }
        // ���������Ƶȼ����� ������־��
        bool AddMissionIDByLevel(List<int> MissionList, int nMissionID)
        {
        

            return true;
        }

        // ����׷�١�������־Ѱ·
        public void MissionPathFinder(int nMissionID)
        {
        
        }

        // ����Ѱ·��ɺ� ��������¼�����
        void MoveOverMissionEvent(int nMissionID)
        {

        
        }

        //MissionBoard�ã�Npcͷ��������Ч
        //public bool IsHaveMissionAccepted(Obj_NPC oNpc)
        //{
           

        //    return false;
        //}
     
       

       

        // �ɼ�������
        public void MissionCollectItem()
        {
           
            
        }

        // ��ʾ�ճ��������
        void OpenDailyMissionUI()
        {//�ر�����������
            
        }

        void OpenGuildMissionWindow()
        {//�ر�����������
          
        }

        // ��ʾ�������
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

        // ���ⲻ�ɽ�����
        public bool SpecialMission_CanAccept(int nMissionID)
        {

            return true;
        }

        // ����ָ������ ���ָ��
        bool Mission_NewPlayerGuide(int nMissionID)
        {
          
            return false;
        }

        // �ճ����� ��ʾ��Ӧ����
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
        // ������� ����ؽ���
        void ShowMissionWindow(bool bSuccess, object param)
        {

          
        }
    }

}

/********************************************************************************
 *	文件名：	ActiveSceneManager.cs
 *	全路径：	\Script\Scene\ActiveSceneManager.cs
 *	创建人：	李嘉
 *	创建时间：2013-10-29
 *
 *	功能说明：游戏当前激活场景,负责游戏的场景数据保存和提供常用方法
 *	修改记录：
*********************************************************************************/

using System;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using GCGame.Table;
//using Module.Log;
using System.IO;
using GCGame;
using Games.LogicObj;
//using Clojure;
namespace Games.Scene
{
    public class Scene_Init_Data
    {
        Scene_Init_Data()
        {
            m_bIsValid = false;
        }

        public bool m_bIsValid;         //该结构体是否合法，创建的时候不合法，必须手动赋值后再设置该项
        public int m_nCurSceneSrvID;    //场景服务器ID
    }

    public class ActiveScene
    {
        private GameObject m_MainCamera; //主摄像机
        /// <summary>
        /// 场景主摄像机
        /// </summary>
        public GameObject MainCamera
        {
            get { return m_MainCamera; }
        }
        private GameObject m_Light; //灯光
        /// <summary>
        /// 场景灯光
        /// </summary>
        public GameObject Lighting
        {
            get { return m_Light; }
        }
        private int m_nCurSceneServerID;  //当前场景的服务器ID（考虑到副本场景可能资源ID和场景服务器ID不一致的情况）
        public int CurSceneServerID
        {
            get { return m_nCurSceneServerID; }
            set { m_nCurSceneServerID = value; }
        }

        private GameObject m_UIRoot;      //当前场景UI根节点
        public GameObject UIRoot
        {
            get { return m_UIRoot; }
            set { m_UIRoot = value; }
        }

        public GameObject NameBoardRoot { set; get; }

        public GameObject FakeObjRoot { get; set; }
        public GameObject FakeObjTrans
        {
            get { return FakeObjRoot.transform.Find("TransformOff").gameObject; }
        }

        private GameObject[] m_SceneAudioSources;
        public GameObject[] SceneAudioSources
        {
            get { return m_SceneAudioSources; }
            set { m_SceneAudioSources = value; }
        }
        private GameObject m_Teleport;      // 传送点
        public GameObject Teleport
        {
            get { return m_Teleport; }
            set { m_Teleport = value; }
        }
        private GameObject m_TeleportCopyScene;      // 传送下一个副本
        public GameObject TeleportCopyScene
        {
            get { return m_TeleportCopyScene; }
            set { m_TeleportCopyScene = value; }
        }
        private GameObject m_DamageBoardRoot = null;
        public GameObject DamageBoardRoot
        {
            get { return m_DamageBoardRoot; }
        }
        public DamageBoardManager m_DamageBoardManager = null;
        public DamageBoardManager DamageBoardManager
        {
            get { return m_DamageBoardManager; }
        }

        private GameObject[] m_QingGongPointList;
        public GameObject[] QingGongPointList
        {
            get { return m_QingGongPointList; }
            set { m_QingGongPointList = value; }
        }

        private float m_ChangeTime = -1;
        private float m_SceneTimeScaleStart = -1;
        //地形文件
        //private TerrainManager m_TerrainData = null;
        //public TerrainManager TerrainData
        //{
        //    get { return m_TerrainData; }
        //    set { m_TerrainData = value; }
       // }

    //名字版池子
    //private GameObjectPool m_NameBoardPool = null;
    //public GameObjectPool NameBoardPool
    //{
    //    get { return m_NameBoardPool; }
    //    set { m_NameBoardPool = value; }
    //}

    //掉落包节点
    public GameObject DropItemBoardRoot { set; get; }
        //////////////////////////////////////////////////////////////////////////
        //地面特效部分
        //////////////////////////////////////////////////////////////////////////
        private GameObject m_MovingCircle = null;      //地表移动特效
        private GameObject m_SelectCircle = null;      //NPC选中特效
        public GameObject m_sele1 = null;
        public GameObject m_sele2 = null;
        private GameObject m_SelectObj = null;         //NPC脚下光圈的目标

        private GameObject m_GuideArrow;
        public UnityEngine.GameObject SelectObj
        {
            get { return m_SelectObj; }
            set { m_SelectObj = value; }
        }
        //设置移动特效状态和位置
        public void ActiveMovingCircle(Vector3 pos)
        {
            if (null == m_MovingCircle)
            {
                return;
            }
            //Singleton<ObjManager>.Instance.MainPlayer.m_playerHeadInfo.ToggleXunLu(false);
            //ObjManager.Instance.MainPlayer.AutoXunLu = false;
            if (!m_MovingCircle.activeSelf)
            {
                m_MovingCircle.SetActive(true);
            }

            for (int i = 0; i < m_MovingCircle.transform.childCount; ++i)
            {
                GameObject child = m_MovingCircle.transform.GetChild(i).gameObject;
                if (null != child)
                {
                    ParticleSystem particle = child.GetComponent<ParticleSystem>();
                    if (null != particle)
                    {
                        particle.time = 0.0f;
                    }
                }
            }

            ////由于特效需要显示在最上层，所以判断点击点和地表哪个更高，取最高值
            //float height = 0;
            //if (GameManager.gameManager.ActiveScene.IsT4MScene())
            //{
            //    height = GameManager.gameManager.ActiveScene.GetTerrainHeight(pos);
            //}
            //else
            //{
            //    height = UnityEngine.Terrain.activeTerrain.SampleHeight(pos);
            //}
            //if (height > pos.y)
            //{
            //    pos.y = height;
            //}
            m_MovingCircle.transform.position = pos + new Vector3(0, 0.3f, 0);
        }

        public void DeactiveMovingCircle()
        {
            if (null != m_MovingCircle)
            {
                m_MovingCircle.SetActive(false);
            }
        }

        //设置选择特效状态和位置
        public void ActiveSelectCircle(GameObject obj, Obj_Character chara)
        {
          
        }

        public void DeactiveSelectCircle()
        {
            //在开启显示服务器主角位置的情况下，选中特效作为位置显示使用，不参与选中逻辑
           
        }

        private void UpdateSelectCircle()
        {
            //在开启显示服务器主角位置的情况下，选中特效作为位置显示使用，不参与选中逻辑
         
        }

        //主角服务器位置测试选项
        public void ShowMainPlayerServerPosition(float fX, float fZ)
        {
            
        }

        public bool Init()
        {
          
            return true;
        }

        bool IsScriptScene = false;
        public void OnLoad(int sceneID)
        {
         
        }


        public void MainPlayerCreateOver()
        {
           
        }
        public void Update()
        {

        }

        public void RelaseActiveSceneData()
        {
         
        }

        public void SceneTimeScale(int nTimeScaleType)
        {
           
        }

        void UpdateSceneTimeScale()
        {
          
        }

        //判断是否为T4M场景，只要判断有没有高度图raw文件即可
        public bool IsT4MScene()
        {
           // return (m_TerrainData != null);
            return false;
        }

        public float GetTerrainHeight(Vector3 pos)
        {
            return 0;
        }

        //根据给定点获得在导航网格上的高度
        public float GetNavSampleHeight(Vector3 pos)
        {
            return 0.0f;
        }

        public float GetTerrainHeightSample(Vector3 pos)
        {
           
            return 0;
        }

        public bool IsCopyScene()
        {
            return false;
        }

        public void SetSceneSoundEffect(bool bIsActive)
        {
            for (int i = 0; i < m_SceneAudioSources.Length; ++i)
            {
                if (m_SceneAudioSources[i] != null)
                {
                    m_SceneAudioSources[i].SetActive(bIsActive);
                }
            }
        }


        public static Vector3 GetTrrainPositionByAndroid(Vector3 orgPosition)
        {
            Vector3 newPosition = orgPosition;

            return newPosition;
        }
        public static bool IsInActive(Vector3 orgPosition)
        {

            return false;
        }
        public static Vector3 GetActivePos(Vector3 orgPosition)
        {
            Vector3 newPosition = orgPosition;
      
            return orgPosition;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgPosition"></param>
        /// <param name="isTag">标记Android下，是否读取默认配置中的值。只在场景首次加载时使用</param>
        /// <returns></returns>
        static public Vector3 GetTerrainPosition(Vector3 orgPosition, bool isTag = true)
        {
           

            return Vector3.zero;
        }

        public void InitFakeObjRoot(GameObject topleft, GameObject bottomright)
        {
         
        }

        public void ShowFakeObj()
        {
            FakeObjRoot.SetActive(true);
        }

        public void HideFakeObj()
        {
            if (FakeObjRoot != null)
                FakeObjRoot.SetActive(false);
        }
    }
}



using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.GlobeDefine;
using Games.Scene;
/*using Games.Events*/
//using GCGame.Table;
//using Games.Mission;
//using Module.Log;
//using Games;

public class GameManager : MonoBehaviour
{
    private GameManager()
    {
        //初始化各个数据
        //m_ActiveScene = new ActiveScene();
        //m_MissionManager = new MissionManager();
        //m_TableManager = new TableManager();
        //m_UILoadResource = new UILoadResource();
        //m_PlayerDataPool = new PlayerData();
        //m_OtherPlayerData = new OtherPlayerData();
    }
    //GameManager以单件形式存在
    //隐身shader
    //当前场景SceneLogic

    ////游戏当前状态


    //由于处于在线状态还是离线状态
    //在线状态需要连接服务器


    //测试选项，是否显示主角服务器位置

    //场景管理器,保存全局的场景相关信息
    
    private ActiveScene m_ActiveScene;
    //任务管理器
    ///读表器
    //声音管理器
    //网络管理器 --暂时放这里
    

   
    //主角在游戏中一直存在的数据
    

    //其他玩家的数据
  
    //自动寻路数据
   



    void Awake()
    {
        //为gameManager赋值，所有的其他操作都要放在后面
       //自己加载不销毁
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //如果单机版 InitGame();
     
    }
    // Update is called once per frame
    void Update()
    {
        //处理事件
      

        //更新ActiveScene
       
    }

    //玩家状态改变之后全局变量清理工作，为玩家重新上线做准备
    //适用范围包括玩家掉线，切换角色，切换帐号
    public void PlayerStateChange()
    {
      
    }

    public void InitGame()
    {
        //初始化全局管理器
      
        //测试
      
        //自动寻路代理
     
        //默认进入Login状态
        //GameStatus = GameDefine_Globe.GAMESTATUS.GAMESTATUS_LOGIN;

        //设置为非第一次进入游戏
       
        //从这里开始添加其他操作
        
        //加载隐身shader
       
        //加载隐身shader
        
        //加载隐身shader
        
    }

    //初始化全局管理器
    bool InitGlobeManager()
    {
        return false;
    }

    // 本想使用异步回调， 但考虑到项目现有整体机制， 想了又想，还是先注释掉吧
    public delegate void InitDataFinishDelegate();
    public delegate void LoadRawDataFinishDelegate(byte[] bytes);

    public LoadRawDataFinishDelegate rawDataCallback;
    public InitDataFinishDelegate initDataCallback;

    public void GetRawData(string strPath)
    {
        strRawPath = strPath;
        StartCoroutine(GetWWWRawData());
    }

    private string strRawPath = "";
    public WWW rawWWW = null;
    public IEnumerator GetWWWRawData()
    {
        //
        rawWWW = new WWW(strRawPath);
        yield return rawWWW;

        bool isError = string.IsNullOrEmpty(rawWWW.error);
        if (!isError)
        {
            Debug.Log("Raw Data WWW Error" + rawWWW.url);
        }

        rawDataCallback(rawWWW.bytes);
        initDataCallback();
    }
    public void ChangeTimeScal(float scale)
    {
        //if(m_IsMj==false)
        Time.timeScale = scale;
        Invoke("ResetTimeScal", 0.5f);
    }
    public void ResetTimeScal()
    {
        Time.timeScale = 1.0f;
    }
}

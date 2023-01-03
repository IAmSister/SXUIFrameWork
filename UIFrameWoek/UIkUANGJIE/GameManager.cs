

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
        //��ʼ����������
        //m_ActiveScene = new ActiveScene();
        //m_MissionManager = new MissionManager();
        //m_TableManager = new TableManager();
        //m_UILoadResource = new UILoadResource();
        //m_PlayerDataPool = new PlayerData();
        //m_OtherPlayerData = new OtherPlayerData();
    }
    //GameManager�Ե�����ʽ����
    //����shader
    //��ǰ����SceneLogic

    ////��Ϸ��ǰ״̬


    //���ڴ�������״̬��������״̬
    //����״̬��Ҫ���ӷ�����


    //����ѡ��Ƿ���ʾ���Ƿ�����λ��

    //����������,����ȫ�ֵĳ��������Ϣ
    
    private ActiveScene m_ActiveScene;
    //���������
    ///������
    //����������
    //��������� --��ʱ������
    

   
    //��������Ϸ��һֱ���ڵ�����
    

    //������ҵ�����
  
    //�Զ�Ѱ·����
   



    void Awake()
    {
        //ΪgameManager��ֵ�����е�����������Ҫ���ں���
       //�Լ����ز�����
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //��������� InitGame();
     
    }
    // Update is called once per frame
    void Update()
    {
        //�����¼�
      

        //����ActiveScene
       
    }

    //���״̬�ı�֮��ȫ�ֱ�����������Ϊ�������������׼��
    //���÷�Χ������ҵ��ߣ��л���ɫ���л��ʺ�
    public void PlayerStateChange()
    {
      
    }

    public void InitGame()
    {
        //��ʼ��ȫ�ֹ�����
      
        //����
      
        //�Զ�Ѱ·����
     
        //Ĭ�Ͻ���Login״̬
        //GameStatus = GameDefine_Globe.GAMESTATUS.GAMESTATUS_LOGIN;

        //����Ϊ�ǵ�һ�ν�����Ϸ
       
        //�����￪ʼ�����������
        
        //��������shader
       
        //��������shader
        
        //��������shader
        
    }

    //��ʼ��ȫ�ֹ�����
    bool InitGlobeManager()
    {
        return false;
    }

    // ����ʹ���첽�ص��� �����ǵ���Ŀ����������ƣ� �������룬������ע�͵���
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

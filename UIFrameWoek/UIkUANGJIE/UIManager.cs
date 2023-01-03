using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Transform BaseUIRoot;      // 位于UI最底层，常驻场景，基础交互
    private Transform PopUIRoot;       // 位于UI上层，弹出式，互斥
    private Transform StoryUIRoot;     // 故事背景层
    private Transform TipUIRoot;       // 位于UI顶层，弹出重要提示信息等
    private Transform MenuPopUIRoot;
    private Transform MessageUIRoot;
    private Transform DeathUIRoot;

    private Dictionary<string, GameObject> m_dicTipUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicBaseUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicPopUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicStoryUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicMenuPopUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicMessageUI = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_dicDeathUI = new Dictionary<string, GameObject>();

    private Dictionary<string, GameObject> m_dicCacheUI = new Dictionary<string, GameObject>();

    private Dictionary<string, int> m_dicWaitLoad = new Dictionary<string, int>();

    private static UIManager m_instance;
    public static UIManager Instance()
    {
        return m_instance;
    }
    private const int GCCollectTime = 1;
    void Awake()
    {
        m_dicTipUI.Clear();
        m_dicBaseUI.Clear();
        m_dicPopUI.Clear();
        m_dicStoryUI.Clear();
        m_dicMenuPopUI.Clear();
        m_dicMessageUI.Clear();
        m_dicDeathUI.Clear();
        m_dicCacheUI.Clear();
        m_instance = this;

        BaseUIRoot = gameObject.transform.Find("BaseUIRoot");
        if (null == BaseUIRoot)
        {
            BaseUIRoot = AddObjToRoot("BaseUIRoot").transform;
        }

        PopUIRoot = gameObject.transform.Find("PopUIRoot");
        if (null == PopUIRoot)
        {
            PopUIRoot = AddObjToRoot("PopUIRoot").transform;
        }

        StoryUIRoot = gameObject.transform.Find("StoryUIRoot");
        if (null == StoryUIRoot)
        {
            StoryUIRoot = AddObjToRoot("StoryUIRoot").transform;
        }

        TipUIRoot = gameObject.transform.Find("TipUIRoot");
        if (null == TipUIRoot)
        {
            TipUIRoot = AddObjToRoot("TipUIRoot").transform;
        }

        MenuPopUIRoot = gameObject.transform.Find("MenuPopUIRoot");
        if (null == MenuPopUIRoot)
        {
            MenuPopUIRoot = AddObjToRoot("MenuPopUIRoot").transform;
        }

        MessageUIRoot = gameObject.transform.Find("MessageUIRoot");
        if (null == MessageUIRoot)
        {
            MessageUIRoot = AddObjToRoot("MessageUIRoot").transform;
        }

        DeathUIRoot = gameObject.transform.Find("DeathUIRoot");
        if (null == DeathUIRoot)
        {
            DeathUIRoot = AddObjToRoot("DeathUIRoot").transform;
        }

        BaseUIRoot.gameObject.SetActive(true);
        TipUIRoot.gameObject.SetActive(true);
        PopUIRoot.gameObject.SetActive(true);
        StoryUIRoot.gameObject.SetActive(true);
        MenuPopUIRoot.gameObject.SetActive(true);
        MessageUIRoot.gameObject.SetActive(true);
        DeathUIRoot.gameObject.SetActive(true);
    }
    //生成根节点
    GameObject AddObjToRoot(string name)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.name = name;
        return obj;
    }
    // 展示UI，根据类型不同，触发不同行为
    public static bool ShowUI(UIPathData pathData)
    {
        if (null == m_instance)
        {
            Debug.Log("game manager is not init");
            return false;
        }
        //加载节点计数
        m_instance.AddLoadDicRefCount(pathData.name);
        //拿对应数据
        Dictionary<string, GameObject> curDic = null;
        switch (pathData.uiType)
        {
            case UIPathData.UIType.TYPE_BASE:
                curDic = m_instance.m_dicBaseUI;
                break;
            case UIPathData.UIType.TYPE_POP:
                curDic = m_instance.m_dicPopUI;
                break;
            case UIPathData.UIType.TYPE_STORY:
                curDic = m_instance.m_dicStoryUI;
                break;
            case UIPathData.UIType.TYPE_TIP:
                curDic = m_instance.m_dicTipUI;
                break;
            case UIPathData.UIType.TYPE_MENUPOP:
                curDic = m_instance.m_dicMenuPopUI;
                break;
            case UIPathData.UIType.TYPE_MESSAGE:
                curDic = m_instance.m_dicMessageUI;
                break;
            case UIPathData.UIType.TYPE_DEATH:
                curDic = m_instance.m_dicDeathUI;

                break;
            default:
                return false;
        }

        if (null == curDic)
        {
            return false;
        }
        //打的缓存池有  小的没有小的添加 大的移除
        if (m_instance.m_dicCacheUI.ContainsKey(pathData.name))
        {
            if (!curDic.ContainsKey(pathData.name))
            {
                curDic.Add(pathData.name, m_instance.m_dicCacheUI[pathData.name]);
            }

            m_instance.m_dicCacheUI.Remove(pathData.name);
        }

        if (curDic.ContainsKey(pathData.name))
        {
            //显现 
            curDic[pathData.name].SetActive(true);

            m_instance.DoAddUI(pathData, curDic[pathData.name]);
            return true;
        }
        //加载ui
        m_instance.LoadUI(pathData);

        return true;
    }
    /// <summary>
    ///   加载该路径下预制体
    /// </summary>
    /// <param name="uiData"></param>
    void LoadUI(UIPathData uiData)
    {

        GameObject curWindow = ResourceManager.LoadResource("Prefab/UI/" + uiData.name) as GameObject;
        if (null != curWindow)
        {
            //不同类型操作
            DoAddUI(uiData, curWindow);

            return;
        }
        //走AB加载
        if (uiData.uiGroupName != null)
        {
            GameObject objCacheBundle = BundleManager.GetGroupUIItem(uiData);
            if (null != objCacheBundle)
            {
                DoAddUI(uiData, objCacheBundle);
                return;
            }
        }
        //开携程走AB包
        //StartCoroutine(BundleManager.LoadUI(uiData, DoAddUI));
    }
    void DoAddUI(UIPathData uiData, GameObject curWindow)
    {
        //        if (!m_dicWaitLoad.Remove(uiData.name))
        //        {
        //            return;
        //        }      
        if (null != curWindow)
        {
            Transform parentRoot = null;
            Dictionary<string, GameObject> relativeDic = null;
            switch (uiData.uiType)
            {
                case UIPathData.UIType.TYPE_BASE:
                    parentRoot = BaseUIRoot;
                    relativeDic = m_dicBaseUI;
                    break;
                case UIPathData.UIType.TYPE_POP:
                    parentRoot = PopUIRoot;
                    relativeDic = m_dicPopUI;
                    break;
                case UIPathData.UIType.TYPE_STORY:
                    parentRoot = StoryUIRoot;
                    relativeDic = m_dicStoryUI;
                    break;
                case UIPathData.UIType.TYPE_TIP:
                    parentRoot = TipUIRoot;
                    relativeDic = m_dicTipUI;
                    break;
                case UIPathData.UIType.TYPE_MENUPOP:
                    parentRoot = MenuPopUIRoot;
                    relativeDic = m_dicMenuPopUI;
                    break;
                case UIPathData.UIType.TYPE_MESSAGE:
                    parentRoot = MessageUIRoot;
                    relativeDic = m_dicMessageUI;
                    break;
                case UIPathData.UIType.TYPE_DEATH:
                    parentRoot = DeathUIRoot;
                    relativeDic = m_dicDeathUI;
                    break;
                default:
                    break;

            }
        }
    }
    private void AddLoadDicRefCount(string pathName)
    {
        if (m_dicWaitLoad.ContainsKey(pathName))
        {
            m_dicWaitLoad[pathName]++;
        }
        else
        {
            m_dicWaitLoad.Add(pathName, 1);
        }

    }
    public void NewPlayerGuideCloseSubUI()
    {
        //缓存中找找到后关闭
    }

}

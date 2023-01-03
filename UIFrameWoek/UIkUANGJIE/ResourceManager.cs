
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.LogicObj;


public class ResourceManager : MonoBehaviour
{
    private static Dictionary<string, int> m_ResourceInstantCounter = null;
    /// <summary>
    /// 资源动态加载记数，只需传入资源路径即可
    /// </summary>
    /// <param name="szKey"></param>
    private static void IncreaseInstantResource(string szKey)
    {
        
    }

    /// <summary>
    /// 资源记数-1，如果发现为0则从统计表中删除
    /// </summary>
    /// <param name="szKey"></param>
    private static void DecreaseInstantResource(string szKey)
    {
        
    }

    /// <summary>
    /// 重置资源动态加载计数器
    /// </summary>
    public static void ResetResourceLoadCounter()
    {
    }

    private static List<string> m_ResourceLoadCounter = null;       //只调用Resource.Load但是没有Instant的资源
    private static void IncreaseResourceLoadCount(string szKey)
    {
        
    }

    /// <summary>
    /// 向内存中加载一个资源
    /// 因为只会创建内存数据，所以不会调用instantiate方法
    /// 此方法不支持异步加载
    /// 但是失败会输出日志
    /// </summary>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public static UnityEngine.Object LoadResource(string resPath, System.Type systemTypeInstance = null)
    {
        UnityEngine.Object resObject = null;
       

        return resObject;
    }

    /// <summary>
    /// 销毁GameObject,记数-1，不会自动置空
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="bImmediate"></param>
    public static void DestroyResource(GameObject obj, bool bImmediate = false)
    {
        
    }

    /// <summary>
    /// 销毁GameObject,记数-1，会自动置空
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="bImmediate"></param>
    public static void DestroyResource(ref GameObject obj, bool bImmediate = false)
    {
    }

    //根据资源动态创建一个GameObject
    /// <summary>
    /// 在场景中创建一个GameObject
    /// 加载成功或失败都会输出日志
    /// 此方法不支持异步加载
    /// </summary>
    /// <param name="resPath">资源路径</param>
    /// <param name="szKey">GameObject的名称，主要用作ObjPools的Key值</param>
    /// 成功和失败都会输入日志，但是成功之后会对统计记数递增
    /// <returns></returns>
    public static UnityEngine.Object InstantiateResource(string resPath, string szKey = "", System.Type systemTypeInstance = null)
    {
        

        return null;
    }

    //加载BackCamera的Prefab
    public static void LoadBackCamera()
    {
        //UIManager.LoadItem(UIInfo.BackCamera, OnLoadBackCameraOver);
    }

    private static void OnLoadBackCameraOver(GameObject resObj, object param)
    {
        if (null == resObj)
        {
            return;
        }

        GameObject newElement = GameObject.Instantiate(resObj) as GameObject;
    }

    /// <summary>
    /// 加载UI
    /// </summary>
    /// <param name="strUIName">UI名字</param>
    /// <param name="nLevel">UI级别</param>
    /// <returns></returns>
    public static GameObject LoadUIPrefab(string strUIName, int nUILevel)
    {
      
        return new GameObject();
    }

    public delegate void LoadHeadInfoDelegate(GameObject objHeadInfo);
    /// <summary>
    /// 加载头顶信息Prefab
    /// </summary>
    /// <param name="nParent">父节点</param>
    /// <param name="strPrefabName">Prefab名字</param>
    /// <returns></returns>
    public static void LoadHeadInfoPrefab(UIPathData uiData, GameObject nParent, string strPrefabName, LoadHeadInfoDelegate delFun)
    {
        
    }

    static void OnLoadHeadInfo(GameObject resObj, object parent, object fun)
    {
       
    }

    public static void UnLoadHeadInfoPrefab(GameObject headInfo)
    {
       
    }

    public static GameObject LoadTitleInvestitiveItem(GameObject TitleInvestitiveGrid, int nTitleInvestitiveItemIndex)
    {
        return new GameObject();
    }

    public static GameObject LoadLastSpeakerItem(GameObject LastSpeakerGrid, int nLastSpeakerItemIndex)
    {
       
        return new GameObject();
    }

    public static GameObject LoadChatLink(GameObject LinkRoot)
    {
        string strPath = "Prefab/UI/ChatLink";
        string strPrefabName = "ChatLink";
        GameObject ChatLink = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != ChatLink)
        {
            if (null != LinkRoot)
                ChatLink.transform.parent = LinkRoot.transform;
            ChatLink.transform.localPosition = Vector3.zero;
            ChatLink.transform.localScale = Vector3.one;
            ChatLink.name = strPrefabName;
        }
        return ChatLink;
    }

    public static GameObject LoadEmotionItem(GameObject ChatInfoEmotion)
    {
        string strPath = "Prefab/UI/EmotionItem";
        string strPrefabName = "EmotionItem";
        GameObject EmotionItem = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != EmotionItem)
        {
            if (null != ChatInfoEmotion)
                EmotionItem.transform.parent = ChatInfoEmotion.transform;
            EmotionItem.transform.localPosition = Vector3.zero;
            EmotionItem.transform.localScale = Vector3.one;
            EmotionItem.name = strPrefabName;
        }
        return EmotionItem;
    }

    public static GameObject LoadChatVIPIcon(GameObject ChatVIPIcon)
    {
        string strPath = "Prefab/UI/SGChatVIPIcon";
        string strPrefabName = "SGChatVIPIcon";
        GameObject EmotionItem = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != EmotionItem)
        {
            if (null != ChatVIPIcon)
                EmotionItem.transform.parent = ChatVIPIcon.transform;
            EmotionItem.transform.localPosition = Vector3.zero;
            EmotionItem.transform.localScale = Vector3.one;
            EmotionItem.name = strPrefabName;
        }
        return EmotionItem;
    }

    public static GameObject LoadMessageIcon(GameObject detailBandRoot)
    {
        string strPath = "Prefab/UI/MessageIcon";
        string strPrefabName = "MessageIcon";
        GameObject MessageIcon = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != MessageIcon)
        {
            if (null != detailBandRoot)
                MessageIcon.transform.parent = detailBandRoot.transform;
            MessageIcon.transform.localPosition = Vector3.zero;
            MessageIcon.transform.localScale = Vector3.one;
            MessageIcon.name = strPrefabName;
        }
        return MessageIcon;
    }

    public static GameObject LoadFastReplyItem(GameObject FastReplyGrid, int nFastReplyItemIndex)
    {
        string strPath = "Prefab/UI/FastReplyItem";
        string strPrefabName = "";
        if (nFastReplyItemIndex < 10)
        {
            strPrefabName = "FastReplyItem" + "0" + nFastReplyItemIndex.ToString();
        }
        else
        {
            strPrefabName = "FastReplyItem" + nFastReplyItemIndex.ToString();
        }
        GameObject FastReplyItem = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != FastReplyItem)
        {
            if (null != FastReplyGrid)
                FastReplyItem.transform.parent = FastReplyGrid.transform;
            FastReplyItem.transform.localPosition = Vector3.zero;
            FastReplyItem.transform.localScale = Vector3.one;
            FastReplyItem.name = strPrefabName;
        }
        return FastReplyItem;
    }


    public static GameObject LoadEmotionButton(GameObject EmotionGrid, int nEmotionButtonIndex)
    {
        string strPath = "Prefab/UI/EmotionButton";
        string strPrefabName = "";
        if (nEmotionButtonIndex < 10)
        {
            strPrefabName = "EmotionButton" + "0" + nEmotionButtonIndex.ToString();
        }
        else
        {
            strPrefabName = "EmotionButton" + nEmotionButtonIndex.ToString();
        }
        GameObject EmotionButton = InstantiateResource(strPath, strPrefabName) as GameObject;
        if (null != EmotionButton)
        {
            if (null != EmotionGrid)
                EmotionButton.transform.parent = EmotionGrid.transform;
            EmotionButton.transform.localPosition = Vector3.zero;
            EmotionButton.transform.localScale = Vector3.one;
            EmotionButton.name = strPrefabName;
        }
        return EmotionButton;
    }
}
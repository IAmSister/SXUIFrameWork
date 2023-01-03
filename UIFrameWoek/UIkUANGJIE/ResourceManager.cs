
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.LogicObj;


public class ResourceManager : MonoBehaviour
{
    private static Dictionary<string, int> m_ResourceInstantCounter = null;
    /// <summary>
    /// ��Դ��̬���ؼ�����ֻ�贫����Դ·������
    /// </summary>
    /// <param name="szKey"></param>
    private static void IncreaseInstantResource(string szKey)
    {
        
    }

    /// <summary>
    /// ��Դ����-1���������Ϊ0���ͳ�Ʊ���ɾ��
    /// </summary>
    /// <param name="szKey"></param>
    private static void DecreaseInstantResource(string szKey)
    {
        
    }

    /// <summary>
    /// ������Դ��̬���ؼ�����
    /// </summary>
    public static void ResetResourceLoadCounter()
    {
    }

    private static List<string> m_ResourceLoadCounter = null;       //ֻ����Resource.Load����û��Instant����Դ
    private static void IncreaseResourceLoadCount(string szKey)
    {
        
    }

    /// <summary>
    /// ���ڴ��м���һ����Դ
    /// ��Ϊֻ�ᴴ���ڴ����ݣ����Բ������instantiate����
    /// �˷�����֧���첽����
    /// ����ʧ�ܻ������־
    /// </summary>
    /// <param name="resPath"></param>
    /// <returns></returns>
    public static UnityEngine.Object LoadResource(string resPath, System.Type systemTypeInstance = null)
    {
        UnityEngine.Object resObject = null;
       

        return resObject;
    }

    /// <summary>
    /// ����GameObject,����-1�������Զ��ÿ�
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="bImmediate"></param>
    public static void DestroyResource(GameObject obj, bool bImmediate = false)
    {
        
    }

    /// <summary>
    /// ����GameObject,����-1�����Զ��ÿ�
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="bImmediate"></param>
    public static void DestroyResource(ref GameObject obj, bool bImmediate = false)
    {
    }

    //������Դ��̬����һ��GameObject
    /// <summary>
    /// �ڳ����д���һ��GameObject
    /// ���سɹ���ʧ�ܶ��������־
    /// �˷�����֧���첽����
    /// </summary>
    /// <param name="resPath">��Դ·��</param>
    /// <param name="szKey">GameObject�����ƣ���Ҫ����ObjPools��Keyֵ</param>
    /// �ɹ���ʧ�ܶ���������־�����ǳɹ�֮����ͳ�Ƽ�������
    /// <returns></returns>
    public static UnityEngine.Object InstantiateResource(string resPath, string szKey = "", System.Type systemTypeInstance = null)
    {
        

        return null;
    }

    //����BackCamera��Prefab
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
    /// ����UI
    /// </summary>
    /// <param name="strUIName">UI����</param>
    /// <param name="nLevel">UI����</param>
    /// <returns></returns>
    public static GameObject LoadUIPrefab(string strUIName, int nUILevel)
    {
      
        return new GameObject();
    }

    public delegate void LoadHeadInfoDelegate(GameObject objHeadInfo);
    /// <summary>
    /// ����ͷ����ϢPrefab
    /// </summary>
    /// <param name="nParent">���ڵ�</param>
    /// <param name="strPrefabName">Prefab����</param>
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
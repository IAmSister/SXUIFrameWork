using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Games.GlobeDefine;
//ab����Դ����
public class BundleManager
{
    public static string LocalLoadPath = Application.streamingAssetsPath;
    public static string FolderLoginUI = "Login";
    public static string FolderMainUI = "Main";
    public static string FolderCommonUI = "Common";

    public static string UIFontName = "font.data";
    public static string UIBaseName = "baseui.data";
    public static string UISoundName = "uisound.data";
    public static string UILoginName = "login.data";
    public static string UIMainName = "main.data";
    public static string UICommonName = "common.data";

    public static string PathUICommon = "/UI/CommonData";
    public static string PathUIPrefab = "/UI/Prefab";
    public static string PathModelPrefab = "/Model";
    public static string PathEffectPrefab = "/Effect";
    public static string PathSoundPrefab = "/Sounds";
    public static string PathAnimationAsset = "/Animations";
    public static string PathTableData = "/Tables";
    public static string PathSceneData = "/Scene";

    public static string AppOutputPath = Application.streamingAssetsPath;
    public static string DevelopOutputPath = Application.dataPath + "/BundleAssets";
    public static string UpdateOutputPath = Application.dataPath + "/../Release/ResData/StreamingAssets";

    private static Dictionary<string, AssetBundle> m_BundleDicUIGroup = new Dictionary<string, AssetBundle>();
    private static Dictionary<string, AssetBundle> m_BundleDicUIRef = new Dictionary<string, AssetBundle>();
    // ���ظ��º��ŵ�·��
    public static string LocalPathRoot
    {
        get
        {
            return Application.persistentDataPath + "/ResData";
        }
    }


    public static string m_loadUrlHead = "file://";

    // ���ֳ�פ�ڴ�����
    private static List<AssetBundle> m_BundleListFont = new List<AssetBundle>();
    private static List<AssetBundle> m_BundleListCommon = new List<AssetBundle>();
    private static List<AssetBundle> m_BundleListLoginUI = new List<AssetBundle>();
    private static List<AssetBundle> m_BundleListMainUI = new List<AssetBundle>();

    private static List<string> m_BundleUILoadingList = new List<string>();


    private static int m_cacheBundleSize = 0;           // �����ϴ�unload����Ĵ�С
    private static int m_cacheBundleAddCount = 0;       // �������
    private const int m_cacheBundleMax = 500 * 1000;    // �����С����     
    private const int m_cacheBundleAddMax = 10;         // �����������

    public delegate void LoadBundleFinish(UIPathData uiData, GameObject retObj, object param1, object param2);
    public static string GetBundleLoadUrl(string subFolder, string localName)
    {
        return "";
        if (false)
        {
            string localPath = LocalPathRoot + subFolder + "/" + localName;

            if (File.Exists(localPath))
            {
                return m_loadUrlHead + localPath;
            }
        }
    }
    // ����Bundle
    private static void CacheBundle(WWW wwwBundle)
    {
        if (null == wwwBundle)
        {
            return;
        }

        if (wwwBundle.assetBundle != null)
        {
            //m_cacheBundleSize += wwwBundle.bytesDownloaded;
            //m_cacheBundleAddCount++;
            Debug.Log("add bundle size" + m_cacheBundleSize + "  name: " + wwwBundle.assetBundle.name);
            wwwBundle.assetBundle.Unload(false);
        }
    }


    /// <summary>
    /// ��ȡitem
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static GameObject GetGroupUIItem(UIPathData data)
    {
        if (null == data.uiGroupName)
        {
            return null;
        }
        if (m_BundleDicUIGroup.ContainsKey(data.uiGroupName))
        {
            //����
            return m_BundleDicUIGroup[data.uiGroupName].LoadAsset(data.name) as GameObject;
        }

        return null;
    }
    public static IEnumerator LoadUI(UIPathData uiData, LoadBundleFinish delFinish, object param1, object param2)
    {
        yield return null;
        // by dsy  ��ʱ���ã����շ�����ʱ��⿪


        // ����ͨ����Դ
 

        // ����Login��Դ
       

        // ���ص�ǰUI

       

       
    }



}
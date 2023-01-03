using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathData
{
    //ui����
    public enum UIType
    {
        TYPE_ITEM,         
        TYPE_BASE,         
        TYPE_POP,         
        TYPE_STORY,        
        TYPE_TIP,          
        TYPE_MENUPOP,    
        TYPE_MESSAGE,    
        TYPE_DEATH,
    }
    public static Dictionary<string, UIPathData> m_DicUIInfo = new Dictionary<string, UIPathData>();
    public static Dictionary<string, UIPathData> m_DicUIName = new Dictionary<string, UIPathData>();
    public string path;
    public string name;
    public UIType uiType;
    public string uiGroupName;
    public bool isMainAsset;            // �Ƿ�������Դ���������ԴUI���ر�
    public bool isDestroyOnUnload;

    // group���������ƣ��Ὣͬһ���ܵ�UI�����һ��
    // isMainAsset  �Ƿ�����Դ
    // bDestroyOnUnload ֻ��PopUI������
    public UIPathData(string _path, UIType _uiType, string groupName = null, bool bMainAsset = false, bool bDestroyOnUnload = true)
    {
        path = _path;
        uiType = _uiType;
        int lastPathPos = _path.LastIndexOf('/');
        if (lastPathPos > 0)
        {
            name = path.Substring(lastPathPos + 1);
        }
        else
        {
            name = path;
        }

        uiGroupName = groupName;
        isMainAsset = bMainAsset;

        isDestroyOnUnload = bDestroyOnUnload;

        //���·��
        m_DicUIInfo.Add(_path, this);
        //���Ԥ��������
        m_DicUIName.Add(name, this);
    }
}
/// <summary>
/// ����Ԥ�������·��
/// </summary>
public class UIInfo 
{
    //public static UIPathData TargetFrameRoot = new UIPathData("Prefab/UI/SGTargetFrameRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
    //public static UIPathData PlayerFrameRoot = new UIPathData("Prefab/UI/SGPlayerFrameRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
    public static UIPathData FunctionButtonRoot = new UIPathData("Prefab/UI/SGFunctionButtonRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathData
{
    //ui类型
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
    public bool isMainAsset;            // 是否是主资源，如果主资源UI被关闭
    public bool isDestroyOnUnload;

    // group捆绑打包名称，会将同一功能的UI打包在一起
    // isMainAsset  是否主资源
    // bDestroyOnUnload 只对PopUI起作用
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

        //存放路径
        m_DicUIInfo.Add(_path, this);
        //存放预制体名字
        m_DicUIName.Add(name, this);
    }
}
/// <summary>
/// 所有预制体加载路径
/// </summary>
public class UIInfo 
{
    //public static UIPathData TargetFrameRoot = new UIPathData("Prefab/UI/SGTargetFrameRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
    //public static UIPathData PlayerFrameRoot = new UIPathData("Prefab/UI/SGPlayerFrameRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
    public static UIPathData FunctionButtonRoot = new UIPathData("Prefab/UI/SGFunctionButtonRoot", UIPathData.UIType.TYPE_BASE, "MainBaseUI");
}

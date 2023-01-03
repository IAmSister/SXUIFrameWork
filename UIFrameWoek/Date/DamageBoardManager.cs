
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.GlobeDefine;

public class DamageBoardManager : MonoBehaviour
{
    //鼠标按键枚举
    public enum MOUSE_BUTTON
    {
        MOUSE_BUTTON_LEFT,
        MOUSE_BUTTON_RIGHT,
        MOUSE_BUTTON_MIDDLE,
    }

    //伤害板改为全局，每一种类型根据配表定上限
    static private Dictionary<int, List<DamageBoard>> m_EnabledDictionary = null;   // 使用中的信息板 改用dictionary
    static private Dictionary<int, List<DamageBoard>> m_DisabledDictionary = null; // 未使用的信息板 循环使用 不必每次都new 改用dictionary

   // static public Dictionary<int, List<Tab_DamageBoardType>> DamageBoardType = null;

    static public void ClearDamageDictionary()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DeleteDamageBoard();
    }

    //预加载一些伤害板
    static public void PreloadDamageBoard()
    {
    
    }

    /// <summary>
    /// 显示伤害信息板
    /// </summary>
    /// <param name="nType">伤害信息板类型 对应DamageBoardType表ID</param>
    /// <param name="nValue">显示的内容</param>
    public void ShowDamageBoard(int nType, string strValue, Vector3 pos, bool isProfessionSkill = true)
    {
        

    }

    static IEnumerator DelayShowDamageBoard(int nType, string strValue, Vector3 pos, bool isProfessionSkill = true)
    {

        yield return null;

    }

    static void OnLoadDamageBoard(GameObject resObj, object param)
    {
    }


    /// 将播放完Tween动画的信息板加入DisabledList中 并从EnabledList删除
    /// </summary>
    void DeleteDamageBoard()
    {
     
    }
}

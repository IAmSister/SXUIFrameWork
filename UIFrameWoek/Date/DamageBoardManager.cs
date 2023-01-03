
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.GlobeDefine;

public class DamageBoardManager : MonoBehaviour
{
    //��갴��ö��
    public enum MOUSE_BUTTON
    {
        MOUSE_BUTTON_LEFT,
        MOUSE_BUTTON_RIGHT,
        MOUSE_BUTTON_MIDDLE,
    }

    //�˺����Ϊȫ�֣�ÿһ�����͸����������
    static private Dictionary<int, List<DamageBoard>> m_EnabledDictionary = null;   // ʹ���е���Ϣ�� ����dictionary
    static private Dictionary<int, List<DamageBoard>> m_DisabledDictionary = null; // δʹ�õ���Ϣ�� ѭ��ʹ�� ����ÿ�ζ�new ����dictionary

   // static public Dictionary<int, List<Tab_DamageBoardType>> DamageBoardType = null;

    static public void ClearDamageDictionary()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DeleteDamageBoard();
    }

    //Ԥ����һЩ�˺���
    static public void PreloadDamageBoard()
    {
    
    }

    /// <summary>
    /// ��ʾ�˺���Ϣ��
    /// </summary>
    /// <param name="nType">�˺���Ϣ������ ��ӦDamageBoardType��ID</param>
    /// <param name="nValue">��ʾ������</param>
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


    /// ��������Tween��������Ϣ�����DisabledList�� ����EnabledListɾ��
    /// </summary>
    void DeleteDamageBoard()
    {
     
    }
}

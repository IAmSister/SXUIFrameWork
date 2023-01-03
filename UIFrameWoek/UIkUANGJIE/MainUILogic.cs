using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUILogic : MonoBehaviour
{
    private static MainUILogic m_Instance = null;
    public static MainUILogic Instance()
    {
        return m_Instance;

    }
    private void Awake()
    {
        m_Instance = this;
    }
   
    void Start()
    {
        LoadUIPrefab();
    }

    private void LoadUIPrefab()
    {
        //UIManager.ShowUI(UIInfo.TargetFrameRoot);
        UIManager.ShowUI(UIInfo.FunctionButtonRoot);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> where T:class,new()
{
    private static T ins;
    public static T Ins
    {
        get
        {
            if (ins==null)
            {
                ins = new T();
            }
            return ins;
        }
    }
}

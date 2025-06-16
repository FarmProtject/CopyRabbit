using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public static class Extension 
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Defines.UIEvents type)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}

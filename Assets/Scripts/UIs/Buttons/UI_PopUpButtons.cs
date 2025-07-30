using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class UI_PopUpButtons : UI_Base
{
    string buttonName;
    private void Awake()
    {
        OnAwake();
    }
    void OnAwake()
    {
        
        buttonName = this.gameObject.name;
        AddUIEvent(this.gameObject, OnClickEvent, Defines.UIEvents.Click);
    }


    protected virtual void OnClickEvent(PointerEventData evt)
    {
        GameManager._instance.PopUpUI(buttonName);
        Debug.Log("11");
    }
}

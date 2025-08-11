using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class UI_PopUpButtons : UI_Base
{
    string buttonName;
    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        
    }
    void Init()
    {
        
        buttonName = this.gameObject.name;
        AddUIEvent(this.gameObject, OnClickEvent, Defines.UIEvents.Click);
    }


    protected virtual void OnClickEvent(PointerEventData evt)
    {
        GameManager._instance.PopUpUI(buttonName);
    }
}

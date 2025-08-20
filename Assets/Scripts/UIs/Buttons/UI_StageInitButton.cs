using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class UI_StageInitButton : UI_Buttons
{
    string selectStage;


    private void Start()
    {
        AddUIEvent(this.gameObject, OnClickEvent, Defines.UIEvents.Click);
    }

    void OnClickEvent(PointerEventData evt)
    {
        Change_SelectStage();
        GameManager._instance._ui_Manager.Get_StagePanel_Script().gameObject.SetActive(false);
    }
    


    void Change_SelectStage()
    {
        GameManager._instance.Init_Stage();
    }

}

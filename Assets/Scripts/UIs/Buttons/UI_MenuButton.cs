using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UI_MenuButton : UI_PopUpButtons
{
    [SerializeField]Defines.MenuType menuType;

    protected override void OnClickEvent(PointerEventData evt)
    {

        Init_Menues();
        base.OnClickEvent(evt);
        Debug.Log("MenuButton UI Event");

    }


    void Init_Menues()
    {
        GameManager._instance.Set_MenuType(menuType);

    }

    

}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_StageButton : UI_Buttons
{
    [SerializeField] string stageId;


    private void Start()
    {
        
    }

    public virtual void Init(string id)
    {
        AddUIEvent(this.gameObject, OnClickEvent, Defines.UIEvents.Click);
        Set_MyData(id);
    }
    public void Set_MyData(string idData)
    {
        stageId = idData;
    }

    void OnClickEvent(PointerEventData evt)
    {
        if(stageId == null)
        {
            Debug.Log("Stage Id is Null In StageButton");
            return;
        }
        GameManager._instance.Change_Stage(stageId);
    }
}

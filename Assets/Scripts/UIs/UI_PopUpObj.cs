using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UI_PopUpObj : UI_Base,IPopUpUI
{
    protected virtual void Awake()
    {
        Init();

    }
    private void Start()
    {
        //Bind();
    }
    void Bind()
    {
        GameManager._instance.Bind_UI_PopUp(this);
    }

    public void Init()
    {
        GameManager._instance.Bind_UI_PopUp(this);
        Debug.Log(this.gameObject.name);
        this.gameObject.SetActive(false);
        
    }

    
}

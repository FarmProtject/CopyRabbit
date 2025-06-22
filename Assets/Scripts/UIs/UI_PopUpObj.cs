using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UI_PopUpObj : UI_Base
{

    private void Start()
    {
        Bind();
    }
    void Bind()
    {
        GameManager._instance.Bind_UI_PopUp(this);
    }
}

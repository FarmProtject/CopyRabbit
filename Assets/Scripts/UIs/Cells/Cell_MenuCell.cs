using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Cell_MenuCell : UI_PopUpButtons, ISubPanelBuilder
{

    public virtual void Set_MyType<T>(T type) where T : Enum
    {

    }
    public virtual void Set_PanelType()
    {
        
    }
}

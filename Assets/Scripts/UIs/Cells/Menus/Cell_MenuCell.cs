using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Cell_MenuCell : UI_PopUpButtons, ISubPanelBuilder,IPoolUI
{
    public void DisableFunction()
    {
        
    }

    public void EnableFunction()
    {
        
    }

    public GameObject Get()
    {
        return this.gameObject;
    }

    public void Init()
    {
       
    }

    public void Return()
    {
       this.gameObject.SetActive(false);
    }

    public virtual void Set_MyType<T>(T type) where T : Enum
    {

    }
    public virtual void Set_PanelType()
    {
        
    }

    private void OnDisable()
    {
        this.enabled = false;
    }
}

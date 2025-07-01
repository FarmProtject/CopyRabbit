using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class Input_ScreenController : UI_EventController, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject lever_Obj;
    Lever_Controller lever_Controller;
    Lever_Base lever_Base;
    private void Awake()
    {

    }

    void OnAwake()
    {
        if (lever_Controller == null)
        {
            lever_Controller = GameManager._instance.Get_LeverCtr();
        }
        if (lever_Obj == null)
        {
            lever_Obj = lever_Controller.Get_Lever_Obj();
        }
        if (lever_Base == null)
        {
            lever_Base = GameManager._instance.Get_Lever_Base();
        }
    }

    private void Start()
    {
        OnAwake();
        OnStart();
    }

    void OnStart()
    {
        OnBegineDragHandler -= OnBeginDragEvent;
        OnBegineDragHandler += OnBeginDragEvent;
        OnDragHandler += OnDragEvt;
        OnDragEndHanlder += OnEndDragEvent;
    }


    void OnBeginDragEvent(PointerEventData evt)
    {
        if (lever_Controller.Get_LeverType() == Defines.LeverType.Floating)
        {
            lever_Obj.SetActive(true);
            Vector2 pos = evt.position;
            lever_Controller.Set_Lever_Position(pos);
            Debug.Log("asdf");
        }
    }
    void OnDragEvt(PointerEventData evt)
    {
        lever_Base.OnDrag(evt);
    }
    void OnEndDragEvent(PointerEventData evt)
    {

        lever_Base.OnDragEndEvt(evt);

    }
}

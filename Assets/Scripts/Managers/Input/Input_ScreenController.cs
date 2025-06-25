using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class Input_ScreenController : UI_EventController,IDragHandler,IBeginDragHandler,IEndDragHandler
{

    Lever_Controller lever_Controller;

    private void Awake()
    {
        
    }

    private void Start()
    {
        OnStart();
    }

    void OnStart()
    {
        OnBegineDragHandler -= OnBeginDragEvent;
        OnBegineDragHandler += OnBegineDragHandler;
        OnDragHandler -= OnDragEvent;
        OnDragHandler += OnDragEvent;
        OnDragEndHanlder -= OnEndDragEvent;
        OnDragEndHanlder += OnEndDragEvent;
    }

    void OnDragEvent(PointerEventData evt)
    {
        switch (lever_Controller.Get_LeverType())
        {
            case Defines.LeverType.Fixed:
                break;
            case Defines.LeverType.Floating:
                break;
            default:
                break;
        }
    }
    void OnBeginDragEvent(PointerEventData evt)
    {
        if(lever_Controller.Get_LeverType() == Defines.LeverType.Floating)
        {

        }
    }
    void OnEndDragEvent(PointerEventData evt)
    {
        if(lever_Controller.Get_LeverType() == Defines.LeverType.Floating)
        {

        }
    }
}

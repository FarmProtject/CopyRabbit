using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
public class Lever_Controller : UI_EventController, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Defines.LeverType leverType;

    Lever_Base lever_Scr;

    Vector2 moveDir;
    void OnAwake()
    {
        lever_Scr = GameObject.Find("Lever_Base").transform.GetComponent<Lever_Base>();

    }
    private void Awake()
    {
        OnAwake();
    }

    public Defines.LeverType Get_LeverType()
    {
        return leverType;
    }

    public void LeverType_Switch(Defines.LeverType _leverType)
    {
        if (leverType == _leverType)
            return;

        leverType = _leverType;
    }

    void Lever_Drag_Start(PointerEventData evtData)
    {



    }


    void OnDragEvent()
    {

    }

    void StartDragEvent()
    {

    }


    public Vector2 GetMoveDir()
    {
        return moveDir;
    }

    public void ResetMyEvent()
    {
        OnDragEndHanlder = null;
        OnBegineDragHandler = null;
        OnDragEndHanlder = null;

    }
    /*

    public override void DragEvent(PointerEventData eventData)
    {
        
        
    }

    public override void DragStartEvent(PointerEventData eventData)
    {
        
    }


    public override void DragEndEvent(PointerEventData eventData)
    {
        myRect.anchoredPosition = Vector2.zero;
    }
    */

}

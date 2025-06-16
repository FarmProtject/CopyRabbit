using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
public class Lever_Controller : UI_EventController, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    

    void OnAwake()
    {


    }
    private void Awake()
    {
        OnAwake();
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

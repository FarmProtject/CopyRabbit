using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class UI_EventController : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{



    public void OnBeginDrag(PointerEventData eventData)
    {
        DragStartEvent(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        DragEndEvent(eventData);
    }
    public virtual void DragStartEvent(PointerEventData eventData)
    {

    }

    public virtual void DragEvent(PointerEventData eventData)
    {

    }

    public virtual void DragEndEvent(PointerEventData eventData)
    {

    }
    
}

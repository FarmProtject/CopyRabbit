using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
public class Lever_Controller : UI_EventController, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    RectTransform parentsTr;
    RectTransform myRect;
    void OnAwake()
    {
        parentsTr = transform.GetComponentInParent<RectTransform>();
        myRect = transform.GetComponent<RectTransform>();
    }
    private void Awake()
    {
        OnAwake();
    }

    /*

    public override void DragEvent(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;
        float maxRadius = parentsTr.rect.size.x;
        Vector2 clamped = Vector2.ClampMagnitude(pos, maxRadius);
        myRect.anchoredPosition = clamped;
        Debug.Log("OnDrag");
        Debug.Log($"my Pos : {myRect.position}");
        Debug.Log($"my Local Pos  : {myRect.localPosition}");
        Vector2 moveVector = myRect.localPosition.normalized*0.1f;
        
        if(GameManager._instance.inputManager == null)
        {
            Debug.Log("InputManager Null !! ");
        }
        else
        {
            GameManager._instance.inputManager.MoveTo(moveVector);
        }
        
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

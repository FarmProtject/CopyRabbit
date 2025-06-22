using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Lever_Base : UI_Base
{

    GameObject lever_Base;
    GameObject lever_Stick;
    RectTransform lever_Base_rect;
    RectTransform lever_Stick_rect;
    Vector2 lever_Pos;

    bool isMoveable = false;

    void OnAwake()
    {
        lever_Base = GameObject.Find("Lever_Base");
        lever_Stick = GameObject.Find("Lever_Stick");
    }
    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        lever_Base_rect = Utils.GetOrAddComponent<RectTransform>(lever_Base);
        lever_Stick_rect = Utils.GetOrAddComponent<RectTransform>(lever_Stick);

        lever_Pos = new Vector2(-820, 400);
        AddUIEvent(this.gameObject, OnDragStart, Defines.UIEvents.DragStart);
        AddUIEvent(this.gameObject, OnDragEnd, Defines.UIEvents.DragEnd);
        AddUIEvent(lever_Base, OnDrag, Defines.UIEvents.Drag);
    }



    public void OnDragStart(PointerEventData evt)
    {
        if (isMoveable)
        {
            lever_Base.SetActive(true);
        }
    }

    public void OnDragEnd(PointerEventData evt)
    {
        if (isMoveable)
        {
            lever_Base.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData evt)
    {
        Vector2 pos = evt.position;
        float maxRadius = lever_Base_rect.rect.size.x;
        Vector2 clamped = Vector2.ClampMagnitude(pos, maxRadius);
        lever_Stick_rect.anchoredPosition = clamped;
        Debug.Log("OnDrag");
        Debug.Log($"my Pos : {lever_Stick_rect.position}");
        Debug.Log($"my Local Pos  : {lever_Stick_rect.localPosition}");
        Vector2 moveVector = lever_Stick_rect.localPosition.normalized * 0.1f;

        if (GameManager._instance.inputManager == null)
        {
            Debug.Log("InputManager Null !! ");
        }
        else
        {
            GameManager._instance.inputManager.MoveTo(moveVector);
        }
    }

    void MoveableChange()
    {
        if (isMoveable)
        {
            isMoveable = false;
            lever_Base.SetActive(true);
            lever_Base.transform.position = lever_Pos;
        }
        else
        {
            isMoveable = true;
            lever_Base.SetActive(false);
        }
    }
}

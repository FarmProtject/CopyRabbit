using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Lever_Base : UI_EventController,IDragHandler,IEndDragHandler
{

    GameObject lever_Base;
    GameObject lever_Stick;
    RectTransform lever_Base_rect;
    RectTransform lever_Stick_rect;
    Vector2 lever_Pos;


    void OnAwake()
    {
        lever_Base = GameObject.Find("Lever_Base");
        lever_Stick = GameObject.Find("Lever_Stick");
        lever_Base_rect = lever_Base.transform.GetComponent<RectTransform>();
        lever_Stick_rect = lever_Stick.transform.GetComponent<RectTransform>();
    }
    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        lever_Pos = new Vector2(-820, 400);
        OnDragHandler += OnDragEvt;
        OnDragEndHanlder += OnDragEndEvt;
        /*
        lever_Base_rect = Utils.GetOrAddComponent<RectTransform>(lever_Base);
        lever_Stick_rect = Utils.GetOrAddComponent<RectTransform>(lever_Stick);

        
        AddUIEvent(this.gameObject, OnDragStart, Defines.UIEvents.DragStart);
        AddUIEvent(this.gameObject, OnDragEnd, Defines.UIEvents.DragEnd);
        AddUIEvent(lever_Base, OnDrag, Defines.UIEvents.Drag);*/
    }


    protected virtual void OnDragEvt(PointerEventData evt)
    {
        Vector2 pos = evt.position;

        SetStickPos(pos);
        Vector2 moveDir = Calculate_MoveDir(pos);

        if (GameManager._instance.inputManager == null)
        {
            Debug.Log("InputManager Null !! ");
        }
        else
        {
            GameManager._instance.Set_Player_MoveDir(moveDir);
        }
    }

    Vector2 Calculate_MoveDir(Vector2 pos)
    {
        Vector2 myPos = new Vector2(lever_Base_rect.position.x, lever_Base_rect.position.y);
        Vector2 moveDir = pos - myPos;
        return moveDir.normalized*0.1f;
    }

    void SetStickPos(Vector2 dir)
    {
        float maxRadius = lever_Base_rect.rect.size.x*0.5f;
        Vector2 clamped = Vector2.ClampMagnitude(dir, maxRadius);
        lever_Stick_rect.localPosition = clamped;
    }

    public void OnDragEndEvt(PointerEventData evt)
    {
        Vector2 reset = Vector2.zero;
        GameManager._instance.Set_Player_MoveDir(reset);
        lever_Stick_rect.localPosition = new Vector2(0, 0);
        if(GameManager._instance.GetLeverType() == Defines.LeverType.Floating)
        {
            Hide();
        }
    }


    void Hide()
    {
        this.gameObject.SetActive(false);
    }
}

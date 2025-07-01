using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Lever_Controller : UI_EventController, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]Defines.LeverType leverType;

    Lever_Base lever_Scr;
    GameObject lever_Obj;
    RectTransform lever_Rect;
    Image lever_Image;
    Vector2 moveDir;

    PlayerEntity playerEntity;
    void OnAwake()
    {
        if(lever_Obj == null)
        {
            lever_Obj = GameObject.Find("Lever_Base");
        }
        if(lever_Scr == null)
        {
            lever_Scr = lever_Obj.GetComponent<Lever_Base>();
        }
        if(lever_Rect == null)
        {
            lever_Image = lever_Obj.transform.GetComponent<Image>();
        }
        playerEntity = GameManager._instance.GetPlayerEntity();
    }
    private void Awake()
    {
        OnAwake();
    }
    private void FixedUpdate()
    {
        
    }
    void Test()
    {
        if(leverType == Defines.LeverType.Floating)
        {
            lever_Image.raycastTarget = false;
        }
    }
    public GameObject Get_Lever_Obj()
    {
        return lever_Obj;
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
        switch (leverType)
        {
            case Defines.LeverType.Fixed:
                break;
            case Defines.LeverType.Floating:
                break;
            default:
                break;
        }
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

    public Lever_Base Get_Lever_Base()
    {
        return lever_Scr;
    }
    public void SetMoveDir(Vector2 dir)
    {
        GameManager._instance.Set_Player_MoveDir(dir);
    }
    public Vector2 GetMoveDir()
    {
        return moveDir;
    }

    public void Set_Lever_Position(Vector2 pos)
    {
        lever_Obj.transform.position = pos;
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

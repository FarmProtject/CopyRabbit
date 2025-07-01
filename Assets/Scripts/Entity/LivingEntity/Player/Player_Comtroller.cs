using UnityEngine;
using System;
using System.Collections.Generic;
public class Player_Comtroller : MonoBehaviour
{
    Defines.PlayerControllType controll_Type;
    PlayerEntity player_Entity;
    PlayerState_Auto auto_State;
    Lever_Controller lever_Controller;
    Vector2 moveDir;

    bool isLocked;
    private void Awake()
    {
        OnAwake();
        controll_Type = Defines.PlayerControllType.Manual;
    }
    void OnAwake()
    {
        if(player_Entity == null)
        {
            player_Entity = transform.GetComponent<PlayerEntity>();
        }
        if(auto_State == null)
        {
            auto_State = new PlayerState_Auto();
        }
        if(lever_Controller == null)
        {
            lever_Controller = GameObject.Find("Lever_Comtroller").transform.GetComponent<Lever_Controller>();
        }
    }
    private void FixedUpdate()
    {
        switch (controll_Type)
        {
            case Defines.PlayerControllType.Auto:
                moveDir = auto_State.GetMoveDirection();
                Debug.Log("Player Controll Type : Auto");
                break;
            case Defines.PlayerControllType.Manual:
                moveDir = lever_Controller.GetMoveDir();
                Debug.Log("Player Controll Type : Manual");
                break;
            default:
                Debug.Log("Player Control State Error!");
                break;
        }
        //player_Entity.SetMoveDir(moveDir);
    }

    public void SetPlayerDir(Vector2 dir)
    {
        moveDir = dir;
        player_Entity.SetMoveDir(moveDir);
    }

    public void RequestControlType(Defines.PlayerControllType type)
    {
        if (isLocked) return; // 외부 이벤트로 잠긴 상태

        controll_Type = type;
    }
}

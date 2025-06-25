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


    private void FixedUpdate()
    {
        switch (controll_Type)
        {
            case Defines.PlayerControllType.Auto:
                moveDir = auto_State.GetMoveDirection();
                break;
            case Defines.PlayerControllType.Manual:
                moveDir = lever_Controller.GetMoveDir();
                break;
            default:
                Debug.Log("Player Control State Error!");
                break;
        }
        player_Entity.SetMoveDir(moveDir);
    }

    void SetPlayerDir()
    {
        player_Entity.SetMoveDir(moveDir);
    }

    public void RequestControlType(Defines.PlayerControllType type)
    {
        if (isLocked) return; // 외부 이벤트로 잠긴 상태

        controll_Type = type;
    }
}

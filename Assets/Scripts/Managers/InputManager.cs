using UnityEngine;
using System;
using System.Collections.Generic;
public class InputManager 
{
    GameObject playerObj;
    Transform playerTr;
    PlayerEntity playerEntity;

    Lever_Controller lever_Ctr;

    public InputManager(GameObject playerObj)
    {
        this.playerObj = playerObj;
        playerTr = playerObj.transform;
        playerEntity = playerTr.GetComponent<PlayerEntity>();
    }
    

    public void SetMoveDir(Vector2 moveTo)
    {
        playerEntity.SetMoveDir(moveTo);
    }

    public Defines.LeverType Get_LeverType()
    {
        return lever_Ctr.Get_LeverType();
    }

}

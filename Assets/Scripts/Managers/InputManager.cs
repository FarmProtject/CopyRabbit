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
        if(lever_Ctr == null)
        {
            lever_Ctr = GameObject.Find("Lever_Comtroller").transform.GetComponent<Lever_Controller>();
        }
    }
    public Lever_Controller Get_LeverController()
    {
        return lever_Ctr;
    }

    public Defines.LeverType Get_LeverType()
    {
        return lever_Ctr.Get_LeverType();
    }

}

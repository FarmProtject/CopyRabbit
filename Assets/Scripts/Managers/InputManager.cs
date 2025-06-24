using UnityEngine;
using System;
using System.Collections.Generic;
public class InputManager 
{
    GameObject playerObj;
    Transform playerTr;
    Rigidbody2D playerRigid;
    public InputManager(GameObject playerObj)
    {
        this.playerObj = playerObj;
        playerTr = playerObj.transform;
        playerRigid = playerTr.GetComponent<Rigidbody2D>();
    }
    

    public void MoveTo(Vector2 moveTo)
    {
        playerRigid.MovePosition(moveTo);
    }



}

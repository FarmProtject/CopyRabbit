using UnityEngine;
using System;
using System.Collections.Generic;
public class InputManager 
{
    GameObject playerObj;
    Transform playerTr;

    public InputManager(GameObject playerObj)
    {
        this.playerObj = playerObj;
        playerTr = playerObj.transform;
    }
    

    public void MoveTo(Vector2 moveTo)
    {
        playerTr.Translate(moveTo);
    }



}

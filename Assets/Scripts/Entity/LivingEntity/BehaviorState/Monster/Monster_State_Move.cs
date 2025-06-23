using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_State_Move : BehaviorBase
{
    public override void Act()
    {
        base.Act();
        Debug.Log("Behavior State : Move");
    }
}

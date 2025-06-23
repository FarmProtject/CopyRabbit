using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_State_Attack : BehaviorBase
{
    public override void Act()
    {
        base.Act();
        Debug.Log("Behavior State : Attack");
    }
}

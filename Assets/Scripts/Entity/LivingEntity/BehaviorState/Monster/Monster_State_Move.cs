using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_State_Move : BehaviorBase
{
    public Monster_State_Move(MonsterEntity entity)
    {
        myEntity = entity;
    }

    public override void Act()
    {
        base.Act();
        myEntity.MoveTo();
        Debug.Log("Behavior State : Move");
        
    }


   
    
}

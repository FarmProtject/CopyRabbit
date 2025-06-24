using UnityEngine;
using System;
using System.Collections.Generic;
public class Montser_State_Stay : BehaviorBase
{
    public Montser_State_Stay(MonsterEntity entity)
    {
        myEntity = entity;
    }
    public override void Act()
    {
        base.Act();
        Debug.Log("Behavior State : Stay");
    }
}

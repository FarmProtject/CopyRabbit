using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_State_Attack : BehaviorBase
{
    PlayerEntity playerEntity;
    public Monster_State_Attack(MonsterEntity entity)
    {
        myEntity = entity;
        playerEntity = GameManager._instance.GetPlayerEntity();
    }

    public override void Act()
    {
        base.Act();
        myEntity.AttackAnamy(playerEntity);
        Debug.Log("Behavior State : Attack");
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;




public class Monster_AI_Controller 
{
    BehaviorBase myBehavior;
    Defines.MonsterActState myState;
    MonsterEntity myEntity;

    public Monster_AI_Controller(MonsterEntity entity)
    {
        myEntity = entity;
    }

    public void SetMyState(Defines.MonsterActState stateType)
    {
        if(myState == stateType)
        {
            return;
        }
        myState = stateType;
        switch (myState)
        {
            case Defines.MonsterActState.Move:
                myBehavior = new Monster_State_Move(myEntity);
                break;
            case Defines.MonsterActState.Attack:
                myBehavior = new Monster_State_Attack(myEntity);
                break;
            case Defines.MonsterActState.Stay:
                myBehavior = new Montser_State_Stay(myEntity);
                break;
            default:
                break;
        }

    }
}

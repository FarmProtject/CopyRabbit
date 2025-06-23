using UnityEngine;
using System;
using System.Collections.Generic;




public class Monster_AI_Controller 
{
    BehaviorBase myBehavior;

    Defines.MonsterActState myState;

    public void SetMyState()
    {
        switch (myState)
        {
            case Defines.MonsterActState.Move:
                myBehavior = new Monster_State_Move();
                break;
            case Defines.MonsterActState.Attack:
                myBehavior = new Monster_State_Attack();
                break;
            case Defines.MonsterActState.Stay:
                myBehavior = new Montser_State_Stay();
                break;
            default:
                break;
        }

    }
}

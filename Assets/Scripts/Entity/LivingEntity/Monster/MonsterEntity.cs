using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterEntity : LivingEntity,IDamageable
{
    Monster_AI_Controller ai_Ctr;
    int attackRange = 10;
    [SerializeField]Defines.MonsterActState state;

    public override void AttackAnamy(LivingEntity targetEntity)
    {
        base.AttackAnamy(targetEntity);
    }
    protected override double Damaged(double damage)
    {
        return base.Damaged(damage);
    }


    void SetAIState(Defines.MonsterActState monsterState)
    {
        if(ai_Ctr == null)
        {
            ai_Ctr = new Monster_AI_Controller(this);
        }
        ai_Ctr.SetMyState(monsterState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetAIState(Defines.MonsterActState.Move);
            state = Defines.MonsterActState.Move;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            float dist = Vector2.Distance(collision.transform.position, this.transform.position);
            Debug.Log($"Distance with Player Object{dist}");
            if (dist < attackRange)
            {
                SetAIState(Defines.MonsterActState.Attack);
                state = Defines.MonsterActState.Attack;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SetAIState(Defines.MonsterActState.Stay);
            state = Defines.MonsterActState.Stay;
        }
    }
}

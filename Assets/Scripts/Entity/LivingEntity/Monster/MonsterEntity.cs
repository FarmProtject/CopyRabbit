using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterEntity : LivingEntity,IDamageable
{
    Monster_AI_Controller ai_Ctr;





    public override void AttackAnamy(LivingEntity targetEntity)
    {
        base.AttackAnamy(targetEntity);
    }
    protected override double Damaged(double damage)
    {
        return base.Damaged(damage);
    }
}

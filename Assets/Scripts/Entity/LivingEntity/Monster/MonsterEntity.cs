using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterEntity : LivingEntity,IDamageable
{

    public override void AttackAnamy(LivingEntity targetEntity)
    {
        base.AttackAnamy(targetEntity);
    }
    protected override double Damaged(double damage)
    {
        return base.Damaged(damage);
    }
}

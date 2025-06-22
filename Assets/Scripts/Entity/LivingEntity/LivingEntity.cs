using UnityEngine;
using System;
using System.Collections.Generic;


public class LivingEntity : MonoBehaviour,IDamageable
{
    protected EntityStats myStats;

    public virtual void AttackAnamy(LivingEntity targetEntity)
    {
        
    }

    protected virtual double Damaged(double damage)
    {
        double hitedDamage = damage;
        return hitedDamage;
    }
}

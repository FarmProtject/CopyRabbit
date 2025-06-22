using UnityEngine;
using System;
using System.Collections.Generic;
public interface IDamageable 
{
    virtual void AttackAnamy(LivingEntity targetEntity)
    {
        
    }
    virtual double Damaged(double damage)
    {
        return damage;
    }
}

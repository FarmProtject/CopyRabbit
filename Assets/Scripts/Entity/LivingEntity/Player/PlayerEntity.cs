using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerEntity : LivingEntity,IDamageable
{
    Player_Upgrade player_Upgrade;






    public void Player_PosCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,0.5f);
        foreach(var hit in hits)
        {
            if(hit.transform.TryGetComponent(out StageField field)) 
            {
                field.Change_isPlayerOn(true);
            }
        }
    }

    protected override double Damaged(double damage)
    {
        return base.Damaged(damage);

    }
}

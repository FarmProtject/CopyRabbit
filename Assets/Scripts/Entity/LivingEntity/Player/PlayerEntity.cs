using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerEntity : LivingEntity,IDamageable
{
    Player_Upgrade player_Upgrade;
    PlayerDatas playerDatas = new PlayerDatas();

    private void Awake()
    {
        OnAwake();
    }
    protected override void OnAwake()
    {
        base.OnAwake();
        if(playerDatas.Get_LastChapter().Count ==0)
        {
            Debug.Log("need to Whrite PlayerEntity OnAWake");
        }
    }

    public void Init_LastChapter()
    {

    }

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

    public string Get_LastChapter(Defines.CombatSubPanels type)
    {
        return playerDatas.Get_LastChapter()[type];
    }
}

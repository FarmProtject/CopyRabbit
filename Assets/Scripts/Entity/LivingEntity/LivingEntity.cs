using UnityEngine;
using System;
using System.Collections.Generic;


public class LivingEntity : MonoBehaviour, IDamageable
{
    protected EntityStats myStats;
    public Vector2 moveDir;

    Rigidbody2D myRigid;

    private void Awake()
    {
        OnAwake();

    }

    protected virtual void OnAwake()
    {
        if (myRigid == null)
        {
            myRigid = transform.GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        MoveTo();
    }
    public virtual void AttackAnamy(LivingEntity targetEntity)
    {

    }

    protected virtual double Damaged(double damage)
    {
        double hitedDamage = damage;
        return hitedDamage;
    }

    public void SetMoveDir(Vector2 direction)
    {
        moveDir = direction;
    }

    public void MoveTo()
    {
        Vector2 pos = new Vector2(transform.position.x,transform.position.y) + moveDir;
        myRigid.MovePosition(pos);
    }


}

using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterEntity : LivingEntity,IDamageable
{
    Monster_AI_Controller ai_Ctr;
    int attackRange = 10;
    [SerializeField]Defines.MonsterActState state;
    MonsterStats myStat = new MonsterStats();

    double healthPoint;
    bool isDead;
    [SerializeField]string myId;
    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        //OnStart();
    }

    public void OnEnable()
    {

    }

    public void OnDisable()
    {
        GameManager._instance.Add_Inactive(myId, this.gameObject);
    }

    public void Set_MyData(MonsterStats stat)
    {
        myStat = new MonsterStats(stat);
        healthPoint = stat.healthPoint;
        myId = myStat.id;
    }
    public string Get_MyId()
    {
        return myStat.id;
    }
    public void Set_MyID(string id)
    {
        if(myStat == null)
        {
            myStat = new MonsterStats();
        }
        myStat.id = id;
    }
    protected override void OnAwake()
    {
        base.OnAwake();
        GameManager._instance.Add_OnMonsterList(this.gameObject);
        
    }
    
    public void Add_ToPoolList()
    {
        Debug.Log(myStat.id);
        GameManager._instance.Inactive_Monster(myStat.id, this.gameObject);
        this.gameObject.SetActive(false);
    }
    public override void AttackAnamy(LivingEntity targetEntity)
    {
        base.AttackAnamy(targetEntity);
    }
    protected override double Damaged(double damage)
    {

        healthPoint -= damage;
        if (IsDead())
        {
            this.gameObject.SetActive(false);
            
        }
        return healthPoint;
    }

    bool IsDead()
    {
        if(healthPoint <= 0)
        {
            isDead = true;
        }
        return isDead;
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
            //Debug.Log($"Distance with Player Object{dist}");
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

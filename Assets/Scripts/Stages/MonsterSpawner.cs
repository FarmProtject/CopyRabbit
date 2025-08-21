using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class MonsterSpawner : MonoBehaviour
{
    PoolManager poolManager;

    [SerializeField]int maxMonsterCount = 54;
    [SerializeField]int maxGenCount = 7;
    [SerializeField]bool canGen = false;
    [SerializeField] float genDelayTiem = 5f;
    [SerializeField] float genTime = 0;
    private void Start()
    {
        canGen = true;
        OnStart();
    }

    void OnStart()
    {
        if(poolManager == null)
        {
            poolManager = GameManager._instance.Get_PoolMamagaer();
        }

    }

    private void FixedUpdate()
    {
        Gen_Monster();
    }

    public void Set_CanGen(bool other)
    {
        canGen = other;
    }
    void Gen_Monster()
    {
        genTime+=Time.deltaTime;
        if (genTime>= genDelayTiem)
        {
            canGen = true;
        }
        while (canGen)
        {
            canGen = false;
            Debug.Log("Gen Monsters!");
            poolManager.Gen_Monster(poolManager.Get_Random_InactiveId());
            genTime = 0f;
        }
        Debug.Log($"몬스터 리스트 내부 몬스터 수 : {GameManager._instance.Get_MonsterList().Count}");
    }

    public void Gen_Reset()
    {
        genTime = 0f;
        canGen = true;
    }
    /*
    IEnumerator Gen_Monster()
    {
        Debug.Log("111");
        if (canGen)
        {
            poolManager.Gen_Monster(poolManager.Get_Random_Inactive());
            Debug.Log("Monster Gen!");
            yield return new WaitForSeconds(genTime);
        }
        
    }*/
    int Calc_GenCount()
    {
        int nowCount = poolManager.GetActiveCount();
        int leftCount = maxMonsterCount - nowCount;
        int genCount = leftCount / maxGenCount;
        int rest = leftCount % maxGenCount;
        if (rest > 0)
        {
            genCount++;
        }
        return genCount;
    }
    

}

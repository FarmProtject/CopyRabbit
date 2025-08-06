using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class MonsterSpawner : MonoBehaviour
{
    PoolManager poolManager;
    ObjectPool objPool;

    [SerializeField]int maxMonsterCount = 54;
    [SerializeField]int maxGenCount = 7;
    bool canGen = false;
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
        if(objPool == null)
        {
            objPool = poolManager.Get_ObjectPool();
        }
    }

    private void FixedUpdate()
    {
        //StartCoroutine("Gen_Monster");
    }

    public void Set_CanGen(bool other)
    {
        canGen = other;
    }
    IEnumerator Gen_Monster()
    {
        Debug.Log("111");
        if (canGen)
        {
            poolManager.Gen_Monster(poolManager.Get_Random_Inactive());
            Debug.Log("Monster Gen!");
            yield return new WaitForSeconds(30f);
        }
        
    }
    int Calc_GenCount()
    {
        int nowCount = objPool.GetActiveCount();
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

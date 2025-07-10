using UnityEngine;
using System;
using System.Collections.Generic;
public class PoolManager
{
    

    ObjectPool obj_Pool;

    [SerializeField] int maxMonsterCount = 63;
    [SerializeField] int nowCount;


    public PoolManager()
    {
        if(obj_Pool == null)
        {
            obj_Pool = new ObjectPool();
        }
    }


    public void Add_ToList(string key , GameObject go)
    {
        if(obj_Pool == null)
        {
            Debug.Log("obj_pool is null");
            obj_Pool = new ObjectPool();
            return;
        }
        obj_Pool.Add_To_Inactive(key, go);
    }


    public void Gen_Monster(string key)
    {
        int genCount = 0;
        nowCount = obj_Pool.GetActiveCount();
        genCount = maxMonsterCount - nowCount;
        List<StageField> fieldList = GameManager._instance.Get_StageList();

        while (genCount > 0)
        {
            int index = UnityEngine.Random.Range(0, fieldList.Count);
            genCount -= fieldList[index].Gen_Monster(genCount);
            fieldList.RemoveAt(index);
        }
    }

    public GameObject Get_Monster(string key)
    {
        return obj_Pool.Get(key);
    }

    public string Get_Random_Inactive()
    {
        return obj_Pool.Get_Random_Inactive();
    }
}

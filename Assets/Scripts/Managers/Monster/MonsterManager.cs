using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterManager
{
    List<GameObject> monsters = new List<GameObject>();

    PoolManager poolManager;


    public MonsterManager()
    {
        poolManager = new PoolManager();
    }

    public PoolManager Get_PoolManager()
    {
        return poolManager;
    }


    public void Inactive_All()
    {
        for(int i = 0; i < monsters.Count; i++)
        {
            monsters[i].SetActive(false);
        }
        Debug.Log($"MonsterCount : {monsters.Count}");
    }
    public void RenewInactiveIds()
    {
        poolManager.RenewInactive();
    }
    
    public void Add_OnMonsterList(GameObject monster)
    {
        if (!monsters.Contains(monster))
        {
            monsters.Add(monster);
        }
    }

    public void Init_Stage(List<string> monsterIds)
    {
        //GameManager._instance.inac
        Change_MonsterIDs(monsterIds);
        Add_MonsterPool();
    }

    public void Change_MonsterIDs(List<string> monsterIds)
    {//스테이지 변경시 몬스터 데이터 변경 몬스터 id리스트는 스테이지 컨트롤러에서 변경 필요
        Debug.Log("몬스터 아이디 변경!");
        List<string> ids = monsterIds;
        poolManager.Get_InactivePool().Clear();
        poolManager.Get_ActivePool().Clear();
        poolManager.Get_InactiveIds().Clear();
        for (int i = 0; i < monsters.Count; i++)
        {
            MonsterEntity monster = monsters[i].transform.GetComponent<MonsterEntity>();
            monster.Set_MyID(ids[i % ids.Count]);

            string id = monster.Get_MyId();
            Debug.Log($"몬스터 아이디 : {id}");
            MonsterStats stat = GameManager._instance.Get_MonsterStat(id);

            monster.Set_MyData(stat);
            poolManager.Add_Inactive(monster.Get_MyId(), monster.gameObject);
            //GameManager._instance.Inactive_Monster(monster.Get_MyId(), monsters[i].gameObject);
            //monsters[i].Add_ToPoolList();
        }
        foreach(string monsterid in poolManager.Get_InactivePool().Keys)
        {
            Debug.Log($" In Inactive Monster ID : {monsterid}, Count : {poolManager.Get_InactivePool()[monsterid].Count}");
        }
        foreach(string monsterID in poolManager.Get_ActivePool().Keys)
        {
            Debug.Log($" In active Monster ID : {monsterID}, Count : {poolManager.Get_ActivePool()[monsterID].Count}");
        }
    }
    
    public void Add_MonsterPool()
    {
        for(int i = 0; i < monsters.Count; i++)
        {
            MonsterEntity entity = monsters[i].transform.GetComponent<MonsterEntity>();
            string key = entity.Get_MyId();
            GameManager._instance.Inactive_Monster(key, monsters[i].gameObject);
        }
    }

    public void Set_MonsterId(string id)
    {
        
    }
    public List<GameObject> Get_MonsterList()
    {
        return monsters;
    }
}

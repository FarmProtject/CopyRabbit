using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterManager
{
    List<MonsterEntity> monsters = new List<MonsterEntity>();




    public void Add_OnMonsterList(MonsterEntity monster)
    {
        if (!monsters.Contains(monster))
        {
            monsters.Add(monster);
        }
    }

    public void Init_Stage(List<string> monsterIds)
    {
        Change_MonsterIDs(monsterIds);
        Add_MonsterPool();
    }

    public void Change_MonsterIDs(List<string> monsterIds)
    {//스테이지 변경시 몬스터 데이터 변경 몬스터 id리스트는 스테이지 컨트롤러에서 변경 필요
        List<string> ids = monsterIds;
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].Set_MyID(ids[i % ids.Count]);

            string id = monsters[i].Get_MyId();

            MonsterStats stat = GameManager._instance.Get_MonsterStat(id);

            monsters[i].Set_MyData(stat);
            GameManager._instance.Inactive_Monster(monsters[i].Get_MyId(), monsters[i].gameObject);
            //monsters[i].Add_ToPoolList();
        }

    }

    public void Add_MonsterPool()
    {
        for(int i = 0; i < monsters.Count; i++)
        {
            string key = monsters[i].Get_MyId();
            GameManager._instance.Inactive_Monster(key, monsters[i].gameObject);
        }
    }

    public void Set_MonsterId(string id)
    {
        
    }
    public List<MonsterEntity> Get_MonsterList()
    {
        return monsters;
    }
}

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
    }

    public void Change_MonsterIDs(List<string> monsterIds)
    {//�������� ����� ���� ������ ���� ���� id����Ʈ�� �������� ��Ʈ�ѷ����� ���� �ʿ�
        List<string> ids = monsterIds;
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].Set_MyID(ids[i % ids.Count]);

            string id = monsters[i].Get_MyId();

            MonsterStats stat = GameManager._instance.Get_MonsterStat(id);

            monsters[i].Set_MyData(stat);

            monsters[i].Add_ToPoolList();
        }

    }

    public void Add_MonsterPool()
    {
        for(int i = 0; i < monsters.Count; i++)
        {
            string key = monsters[i].Get_MyId();
            GameManager._instance.Add_ToPoolList(key, monsters[i].gameObject);
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

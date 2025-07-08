using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_DataManager 
{
    public Dictionary<string, MonsterStats> data_NorMalMonsters = new Dictionary<string, MonsterStats>();
    public Dictionary<string, MonsterStats> data_BossMonsters = new Dictionary<string, MonsterStats>();



    public void Set_NromalData(MonsterEntity target,string id)
    {
        MonsterStats newData = new MonsterStats(data_NorMalMonsters[id]);
        target.Set_MyData(newData);
    }

    public void Set_BossData(MonsterEntity target,string id)
    {
        MonsterStats newData = new MonsterStats(data_BossMonsters[id]);
        target.Set_MyData(newData);
    }
}

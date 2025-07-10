using UnityEngine;
using System;
using System.Collections.Generic;
public class Monster_DataManager 
{
    public Dictionary<string, MonsterStats> data_Monsters = new Dictionary<string, MonsterStats>();

    public void Set_MonsterData(Dictionary<string,Dictionary<string,string>> data)
    {
        foreach(string key in data.Keys)
        {
            MonsterStats stat = new MonsterStats();
            Utils.TrySetValue<string>(data[key], "id", ref stat.id);
            Utils.TrySetValue<string>(data[key], "name", ref stat.name);
            Utils.TryConvertEnum<Defines.MonsterType>(data[key], "monsterType", ref stat.monsterType);
            Utils.TrySetValue<string>(data[key], "assetbundle", ref stat.assetBundle);
            Utils.TrySetValue<double>(data[key], "attack", ref stat.attack);
            Utils.TrySetValue<double>(data[key], "defense", ref stat.defense);
            Utils.TrySetValue<double>(data[key], "healthPoint", ref stat.healthPoint);
            Utils.TrySetValue<int>(data[key], "moveSpeed", ref stat.moveSpeed);
            Utils.TrySetValue<int>(data[key], "attackRange", ref stat.attackRange);
            Utils.TrySetValue<int>(data[key], "attackSpeed", ref stat.attackSpeed);
            Utils.TrySetValue<int>(data[key], "aggroRange", ref stat.aggroRange);
            Utils.TrySetValue<bool>(data[key], "canStun", ref stat.canStun);
            Utils.TrySetValue<int>(data[key], "stunValue", ref stat.sturnValue);
            data_Monsters.Add(key, stat);
        }
    }



    public MonsterStats Get_MonsterStat(string id)
    {
        return data_Monsters[id];
    }
}

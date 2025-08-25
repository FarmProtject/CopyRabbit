using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerDatas 
{
    public Dictionary<Defines.DungeonType, int> clearChapter = new Dictionary<Defines.DungeonType, int>() 
    { 
        { Defines.DungeonType.Gold, 0 },
        {Defines.DungeonType.Skill,0 },
        {Defines.DungeonType.Tower,0 },
        {Defines.DungeonType.Portal,0 },
        {Defines.DungeonType.Boss,0 },
        {Defines.DungeonType.Gem,0 },
    };
    public Dictionary<Defines.DungeonType, List<string>> clearStage = new Dictionary<Defines.DungeonType, List<string>>();

    public Dictionary<Defines.DungeonType, int> Get_LastChapterDict()
    {
        return clearChapter;
    }

    public int Get_LastChapter(Defines.DungeonType type)
    {
        return clearChapter[type];
    }
    public Dictionary<Defines.DungeonType, List<string>> Get_ClearStage()
    {
        return clearStage;
    }

    public void Add_LastChapter(Defines.DungeonType type, int value)
    {
        if (!clearChapter.ContainsKey(type))
        {
            clearChapter.Add(type, value);
        }
        else if (clearChapter.ContainsKey(type))
        {
            clearChapter[type] = value;
        }
    }

    public void Add_ClearStage(Defines.DungeonType type, string value)
    {
        if (!clearStage.ContainsKey(type))
        {
            List<string> newList = new List<string>();
            newList.Add(value);
            clearStage.Add(type, newList);
        }
        if (clearStage.ContainsKey(type))
        {
            if (!clearStage[type].Contains(value))
            {
                clearStage[type].Add(value);
            }
        }
    }
    /*
    public int Get_BiggestStage(Defines.CombatSubPanels type)
    {
        int stage = 1;
        for(int i = 0; i< clearStage[type].Count; i++)
        {
            if (clearStage[type][i]>stage)
            {
                stage = clearStage[type][i];
            }
        }
        return stage;
    }*/
}

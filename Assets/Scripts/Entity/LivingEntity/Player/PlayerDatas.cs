using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerDatas 
{
    public Dictionary<Defines.CombatSubPanels, int> lastChapter = new Dictionary<Defines.CombatSubPanels, int>() 
    { 
        { Defines.CombatSubPanels.Gold, 1 },
        {Defines.CombatSubPanels.Skill,1 },
        {Defines.CombatSubPanels.Guardian,1 },
        {Defines.CombatSubPanels.Portal,1 },
        {Defines.CombatSubPanels.Boss,1 },
        {Defines.CombatSubPanels.Treasure,1 },
    };
    public Dictionary<Defines.CombatSubPanels,List<string>> clearStage = new Dictionary<Defines.CombatSubPanels, List<string>>();

    public Dictionary<Defines.CombatSubPanels,int> Get_LastChapterDict()
    {
        return lastChapter;
    }

    public int Get_LastChapter(Defines.CombatSubPanels type)
    {
        return lastChapter[type];
    }
    public Dictionary<Defines.CombatSubPanels, List<string>> Get_ClearStage()
    {
        return clearStage;
    }

    public void Add_LastChapter(Defines.CombatSubPanels type, int value)
    {
        if (!lastChapter.ContainsKey(type))
        {
            lastChapter.Add(type, value);
        }
        else if (lastChapter.ContainsKey(type))
        {
            lastChapter[type] = value;
        }
    }

    public void Add_ClearStage(Defines.CombatSubPanels type, string value)
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

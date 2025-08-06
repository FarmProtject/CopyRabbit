using UnityEngine;
using System;
using System.Collections.Generic;
public class PlayerDatas 
{
    Dictionary<Defines.CombatSubPanels, string> lastChapter = new Dictionary<Defines.CombatSubPanels, string>();
    Dictionary<Defines.CombatSubPanels,List<string>> clearStage = new Dictionary<Defines.CombatSubPanels, List<string>>();


    public Dictionary<Defines.CombatSubPanels,string> Get_LastChapter()
    {
        return lastChapter;
    }
    public Dictionary<Defines.CombatSubPanels, List<string>> Get_ClearStage()
    {
        return clearStage;
    }
}

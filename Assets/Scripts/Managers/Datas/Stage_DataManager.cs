using UnityEngine;
using System;
using System.Collections.Generic;
public class Stage_DataManager
{
    Dictionary<string, Dictionary<string,string>> data_NormalStage = new Dictionary<string, Dictionary<string,string>>();
    Dictionary<string, Dictionary<string, string>> data_Challenge = new Dictionary<string, Dictionary<string, string>>();

    Dictionary<string, Dictionary<string, string>> data_GemDungeon = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_SkillDungeon = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_GoldDungeon = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_TowerDungeon = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_BossDungeon = new Dictionary<string, Dictionary<string, string>>();
   
    Dictionary<string, List<StringKeyDatas>> rewards = new Dictionary<string, List<StringKeyDatas>>();
    
    //Dictionary<string, StageData> script_Stages = new Dictionary<string, StageData>();
    
    Dictionary<Defines.DungeonType, Dictionary<int, List<string>>> chapters = new Dictionary<Defines.DungeonType, Dictionary<int, List<string>>>();

    Dictionary<Defines.DungeonType, Dictionary<string, StageData>> script_Stages = new Dictionary<Defines.DungeonType, Dictionary<string, StageData>>();

    public void BindingChapters(StageData data)
    {
        int chapterNumber = Int32.Parse(data.chapter);
        if (chapters.ContainsKey(data.dungeonType))
        {
            if (chapters[data.dungeonType].ContainsKey(chapterNumber))
            {
                if (chapters[data.dungeonType][chapterNumber].Contains(data.id))
                {
                    Debug.Log($"챕터 이미 바인딩되어있음 ID : {data.id}");
                }
                else
                {
                    chapters[data.dungeonType][chapterNumber].Add(data.id);
                }
            }
            else
            {
                chapters[data.dungeonType].Add(chapterNumber, new List<string>());
                chapters[data.dungeonType][chapterNumber].Add(data.id);
            }

        }
        else
        {
            chapters.Add(data.dungeonType, new Dictionary<int, List<string>>());
            chapters[data.dungeonType].Add(chapterNumber, new List<string>());
            chapters[data.dungeonType][chapterNumber].Add(data.id);
        }

        /*
        Defines.DungeonType[] combatSub = (Defines.DungeonType[])(Enum.GetValues(typeof(Defines.DungeonType)));
        foreach(var key in combatSub)
        {
            if (!chapters.ContainsKey(key))
            {
                Dictionary<int, List<string>> newData = new Dictionary<int, List<string>>();
                chapters.Add(key, newData);
            }
        }

        foreach (var id in data_NormalStage.Keys)
        {
            
            int chapter = Int32.Parse(data_NormalStage[id]["chapter"]);
            string stageKey = data_NormalStage[id]["id"];
            if (chapters[Defines.DungeonType.Portal].ContainsKey(chapter))
            {
                chapters[Defines.DungeonType.Portal][chapter].Add(stageKey);
            }
            else
            {
                List<string> newList = new();
                newList.Add(stageKey);
                chapters[Defines.DungeonType.Portal].Add(chapter, newList);
            }
        }
        foreach(var type in script_Stages.Keys)
        {

        }*/
    }

    public void Set_StageData(string path)
    {
        GameManager._instance.Read_Data(path, data_NormalStage);
    }

    public Dictionary<string, List<StringKeyDatas>> Get_Rewards()
    {
        return rewards;
    }
    public void Set_Rewards(Dictionary<string,List<StringKeyDatas>> data)
    {
        rewards = data;
    }
    #region Datas
    public Dictionary<string, Dictionary<string, string>> Get_ChallengeData()
    {
        return data_Challenge;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Normal_StageData()
    {
        return data_NormalStage;
    }

    public Dictionary<string, Dictionary<string, string>> Get_Trasure_StageData()
    {
        return data_GemDungeon;
    }

    public Dictionary<string, Dictionary<string, string>> Get_Gold_StageData()
    {
        return data_GoldDungeon;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Skill_StageData()
    {
        return data_SkillDungeon;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Guardian_StageData()
    {
        return data_TowerDungeon;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Boss_StageData()
    {
        return data_BossDungeon;
    }

    #endregion
    public StageData Get_Stage_Script(Defines.DungeonType type,string id)
    {
        return script_Stages[type][id];
    }
    

    public void Init_StageScript()
    {
        Init_NormalStageData();
        Init_ChallengeStageData();
    }

    public void Init_NormalStageData()
    {

        foreach(string key in data_NormalStage.Keys)
        {
            NormalStageData newData = new NormalStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "killCount", ref newData.killCount);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "dropRewardGroup", ref newData.dropRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "nextStageId", ref newData.nextStageId);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "stageType", ref newData.stageClearType);
            Utils.TryConvertEnum<Defines.DungeonType>(data_NormalStage[key], "dungeonType",ref newData.dungeonType);

            Add_Stage_Script(newData);
            BindingChapters(newData);
        }
    }


    public void Init_ChallengeStageData()
    {
        foreach (string key in data_Challenge.Keys)
        {
            ChallengeStageData newData = new ChallengeStageData();

            Utils.TrySetValue(data_Challenge[key], "id", ref newData.id);
            Utils.TrySetValue(data_Challenge[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_Challenge[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_Challenge[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_Challenge[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_Challenge[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_Challenge[key], "recommendedPower", ref newData.recommendedPower);
            
            Utils.TryConvertEnum<Defines.StageClearType>(data_Challenge[key], "stageType", ref newData.stageClearType);
            Utils.TryConvertEnum<Defines.DungeonType>(data_Challenge[key], "dungeonType", ref newData.dungeonType);
            Utils.TrySetValue(data_Challenge[key], "bGradeParam", ref newData.bGradeParm);
            Utils.TrySetValue(data_Challenge[key], "aGradeParam", ref newData.aGradParm);
            Utils.TrySetValue(data_Challenge[key], "sGradeParam", ref newData.sGradParm);
            Utils.TrySetValue(data_Challenge[key], "bGradeReward", ref newData.bGradeReward);
            Utils.TrySetValue(data_Challenge[key], "aGradeReward", ref newData.aGradReward);
            Utils.TrySetValue(data_Challenge[key], "sGradeReward", ref newData.sGradReward);
            Defines.DungeonType type = newData.dungeonType;


            Add_Stage_Script(newData);
            BindingChapters(newData);
        }
    }

    public void Add_Stage_Script(StageData data)
    {
        if (script_Stages.ContainsKey(data.dungeonType))
        {
            if (script_Stages[data.dungeonType].ContainsKey(data.id))
            {
                Debug.Log($"스크립트 할당중 id {data.id}");
            }
            else
            {
                script_Stages[data.dungeonType].Add(data.id, data);
            }

        }
        else
        {
            script_Stages.Add(data.dungeonType, new Dictionary<string, StageData>());
            script_Stages[data.dungeonType].Add(data.id, data);
        }

    }
    public Dictionary<Defines.DungeonType, Dictionary<int, List<string>>> Get_Chapters()
    {
        return chapters;
    }
}

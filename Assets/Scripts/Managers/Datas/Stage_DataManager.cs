using UnityEngine;
using System;
using System.Collections.Generic;
public class Stage_DataManager
{
    Dictionary<string, Dictionary<string,string>> data_NormalStage = new Dictionary<string, Dictionary<string,string>>();
    Dictionary<string, Dictionary<string, string>> data_ChallengeStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, List<StringKeyDatas>> rewards = new Dictionary<string, List<StringKeyDatas>>();
    
    Dictionary<string, StageData> data_Stage = new Dictionary<string, StageData>();

    Dictionary<string, StageData> script_Stages = new Dictionary<string, StageData>();
    


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

    public Dictionary<string, Dictionary<string, string>> Get_Normal_StageData()
    {
        return data_NormalStage;
    }

    public Dictionary<string, Dictionary<string, string>> Get_Challenge_StageData()
    {
        return data_ChallengeStage;
    }

    public StageData Get_Stage_Script(string id)
    {
        return script_Stages[id];


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
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);
        }
    }
    public void Init_ChallengeStageData()
    {
        foreach (string key in data_NormalStage.Keys)
        {
            ChallengeStageData newData = new ChallengeStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);
        }
    }
}

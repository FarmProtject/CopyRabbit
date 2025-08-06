using UnityEngine;
using System;
using System.Collections.Generic;
public class Stage_DataManager
{
    Dictionary<string, Dictionary<string,string>> data_NormalStage = new Dictionary<string, Dictionary<string,string>>();
    Dictionary<string, Dictionary<string, string>> data_TrasureStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_SkillStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_GoldStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_GuardianStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, Dictionary<string, string>> data_BossStage = new Dictionary<string, Dictionary<string, string>>();
    Dictionary<string, List<StringKeyDatas>> rewards = new Dictionary<string, List<StringKeyDatas>>();
    
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
    #region Datas
    public Dictionary<string, Dictionary<string, string>> Get_Normal_StageData()
    {
        return data_NormalStage;
    }

    public Dictionary<string, Dictionary<string, string>> Get_Trasure_StageData()
    {
        return data_TrasureStage;
    }

    public Dictionary<string, Dictionary<string, string>> Get_Gold_StageData()
    {
        return data_GoldStage;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Skill_StageData()
    {
        return data_SkillStage;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Guardian_StageData()
    {
        return data_GuardianStage;
    }
    public Dictionary<string, Dictionary<string, string>> Get_Boss_StageData()
    {
        return data_BossStage;
    }

    #endregion
    public StageData Get_Stage_Script(string id)
    {
        return script_Stages[id];
    }
    

    public void Init_StageScript()
    {
        Init_BossStageData();
        Init_GoldStageData();
        Init_GuardianStageData();
        Init_NormalStageData();
        Init_SkillStageData();
        Init_TrasureStageData();
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

            script_Stages.Add(newData.id, newData);
        }
    }
    public void Init_TrasureStageData()
    {
        foreach (string key in data_TrasureStage.Keys)
        {
            TrasureStageData newData = new TrasureStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);

            script_Stages.Add(newData.id, newData);
        }
    }
    public void Init_SkillStageData()
    {
        foreach (string key in data_SkillStage.Keys)
        {
            SkillStageData newData = new SkillStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);

            script_Stages.Add(newData.id, newData);
        }
    }
    public void Init_GoldStageData()
    {
        foreach (string key in data_GoldStage.Keys)
        {
            GoldStageData newData = new GoldStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);

            script_Stages.Add(newData.id, newData);
        }
    }
    public void Init_GuardianStageData()
    {
        foreach (string key in data_GuardianStage.Keys)
        {
            GuardianStageData newData = new GuardianStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);

            script_Stages.Add(newData.id, newData);
        }
    }
    public void Init_BossStageData()
    {
        foreach (string key in data_BossStage.Keys)
        {
            BossStageData newData = new BossStageData();

            Utils.TrySetValue(data_NormalStage[key], "id", ref newData.id);
            Utils.TrySetValue(data_NormalStage[key], "chapter", ref newData.chapter);
            Utils.TrySetValue(data_NormalStage[key], "stage", ref newData.stage);
            Utils.TrySetValue(data_NormalStage[key], "spawnGroupId", ref newData.spawnGroup);
            Utils.TrySetValue(data_NormalStage[key], "timeLimit", ref newData.timeLimit);
            Utils.TrySetValue(data_NormalStage[key], "clearRewardGroup", ref newData.clearRewardGroup);
            Utils.TrySetValue(data_NormalStage[key], "recommendedPower", ref newData.recommendedPower);
            Utils.TryConvertEnum<Defines.StageClearType>(data_NormalStage[key], "type", ref newData.stageClearType);

            script_Stages.Add(newData.id, newData);
        }
    }
}

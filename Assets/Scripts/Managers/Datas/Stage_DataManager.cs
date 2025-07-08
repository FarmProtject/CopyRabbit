using UnityEngine;
using System;
using System.Collections.Generic;
public class Stage_DataManager
{
    Dictionary<string, Dictionary<string,string>> stageDatas = new Dictionary<string, Dictionary<string,string>>();
    Dictionary<string, StringKeyDatas> rewards = new Dictionary<string, StringKeyDatas>();
    Dictionary<string, StageData> data_Stage = new Dictionary<string, StageData>();
    public void Set_StageData(string path)
    {
        GameManager._instance.Read_Data(path, stageDatas);
    }

    public StageData Get_StageData(string id)
    {
        StageData newData = new StageData();
        string stageId = GameManager._instance.Get_Stage_ID();

        newData.id = stageDatas[id]["id"];
        newData.chapter = stageDatas[id]["chapter"];
        newData.stage = stageDatas[id]["stage"];
        Utils.TryConvertEnum<Defines.StageType>(stageDatas[id], "stageType",ref newData.stageType);
        newData.spawnGroup = stageDatas[id]["spawnGroup"];
        newData.clearRwardGroup = stageDatas[id]["clearRwardGroup"];
        newData.dropRewardGroup = stageDatas[id]["dropRewardGroup"];
        Utils.TrySetValue<int>(stageDatas[id], "killCount", ref newData.killCount);
        Utils.TrySetValue<float>(stageDatas[id], "timeLimit", ref newData.timeLimit);
        Utils.TrySetValue<string>(stageDatas[id], "nextStageId", ref newData.nextStageId);
        Utils.TrySetValue<int>(stageDatas[id], "recommendedPower", ref newData.recommendedPower);

        return newData;
    }


    public Dictionary<string, Dictionary<string, string>> Get_StageDatas()
    {
        return stageDatas;
    }

}

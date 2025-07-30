using UnityEngine;
using System;
using System.Collections.Generic;
public class NormalStageData : StageData
{
    public string nextStageId;
    public string dropRewardGroup;
    public int killCount;

    public NormalStageData(NormalStageData other )
    {
        this.stageType = Defines.StageType.Stage;
        this.id = other.id;
        this.chapter = other.chapter;
        this.stage = other.stage;
        this.stageType = other.stageType;
        this.spawnGroup = other.spawnGroup;
        this.clearRewardGroup = other.clearRewardGroup;
        this.dropRewardGroup = other.dropRewardGroup;
        this.killCount = other.killCount;
        this.timeLimit = other.timeLimit;
        this.rewards = other.rewards;
        
    }

    public NormalStageData()
    {

    }
}

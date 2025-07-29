using UnityEngine;
using System;
using System.Collections.Generic;
public class StageData 
{
    public string id;
    public string chapter;
    public string stage;
    
    public string spawnGroup;
    public string clearRwardGroup;
    //public string dropRewardGroup;
    public int requiredCount;
    public float timeLimit;
    public string rewardKey;
    //public string nextStageId;
    public int recommendedPower;
    public List<Stage_Reward> rewards = new List<Stage_Reward>();

    public Defines.StageType stageType;
    public Defines.StageClearType stageClearType;
    public StageData()
    {

    }
    public StageData(StageData other)
    {
        this.id = other.id;
        this.chapter = other.chapter;
        this.stage = other.stage;
        this.stageType = other.stageType;
        this.spawnGroup = other.spawnGroup;
        this.clearRwardGroup = other.clearRwardGroup;
        this.dropRewardGroup = other.dropRewardGroup;
        this.killCount = other.killCount;
        this.timeLimit = other.timeLimit;
        this.rewards = other.rewards;
    }
}

public class Stage_Reward
{
    public string id;
    public string itemId;
    public int quantity;
}

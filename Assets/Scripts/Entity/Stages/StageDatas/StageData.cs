using UnityEngine;
using System;
using System.Collections.Generic;
public class StageData 
{
    public string id;
    public string chapter;
    public string stage;
    
    public string spawnGroup;
    public string clearRewardGroup;
    //public string dropRewardGroup;
    public int requiredCount;
    public float timeLimit;
    public string rewardKey;
    //public string nextStageId;
    public int recommendedPower;
    public List<Stage_Reward> rewards = new List<Stage_Reward>();

    public Defines.StageType stageType;
    public Defines.StageClearType stageClearType;
    public Defines.DungeonType dungeonType;
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
        this.clearRewardGroup = other.clearRewardGroup;
        this.timeLimit = other.timeLimit;
        this.rewards = other.rewards;
        this.dungeonType = other.dungeonType;
    }
}

public class Stage_Reward
{
    public string id;
    public string itemId;
    public int quantity;
}
public class NormalStageData : StageData
{
    public string nextStageId;
    public string dropRewardGroup;
    public int killCount;

    public NormalStageData(NormalStageData other)
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
public class TrasureStageData:StageData
{

}
public class SkillStageData : StageData
{

}

public class GoldStageData : StageData
{

}
public class GuardianStageData : StageData
{

}
public class BossStageData : StageData
{

}

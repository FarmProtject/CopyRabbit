using UnityEngine;
using System;
using System.Collections.Generic;
public class ChallengeStageData : StageData
{
    public Defines.DungeonType dungeonType;

    public string bGradeParm;
    public string aGradParm;
    public string sGradParm;
    public string bGradeReward;
    public string aGradReward;
    public string sGradReward;
    public ChallengeStageData(ChallengeStageData other)
    {
        this.stageType = Defines.StageType.Challenge;
        dungeonType = other.dungeonType;
        bGradeParm = other.bGradeParm;
        aGradParm = other.aGradParm;
        sGradParm = other.sGradParm;
        bGradeReward = other.bGradeReward;
        aGradReward = other.aGradReward;
        sGradReward = other.sGradReward;
    }
    public ChallengeStageData()
    {

    }
}

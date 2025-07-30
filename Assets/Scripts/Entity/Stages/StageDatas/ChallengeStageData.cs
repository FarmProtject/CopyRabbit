using UnityEngine;
using System;
using System.Collections.Generic;
public class ChallengeStageData : StageData
{
    public ChallengeStageData(ChallengeStageData other)
    {
        this.stageType = Defines.StageType.Challenge;

    }
    public ChallengeStageData()
    {

    }
}

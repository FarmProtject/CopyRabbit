using UnityEngine;
using System;
using System.Collections.Generic;
public class StageManager 
{
    StageBase stage;
    Defines.StageType stageType;



    public void SetStage(Defines.StageType type)
    {
        SetStageType(type);
        ChangeStage();
    }

    void SetStageType(Defines.StageType type)
    {
        stageType = type;
    }

    public void ChangeStage()
    {
        switch (stageType)
        {
            case Defines.StageType.Infinity:
                stage = new Stage_Infinity();
                break;
            case Defines.StageType.Challenge:
                stage = new Stahge_Challenge();
                break;
            case Defines.StageType.Boss:
                stage = new Stage_Boss();
                break;
            default:
                Debug.Log("StageType Error");
                break;
        }
    }
}

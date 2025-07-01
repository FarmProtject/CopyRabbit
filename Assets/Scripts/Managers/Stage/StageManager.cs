using UnityEngine;
using System;
using System.Collections.Generic;
public class StageManager 
{
    StageBase stage;
    Defines.StageType stageType;
    [SerializeField]int monster_GenCount = 7; //한번에 젠 되는 최대 몬스터 수 


    public void SetStage(Defines.StageType type)
    {
        SetStageType(type);
        ChangeStage();
    }

    void SetStageType(Defines.StageType type)
    {
        stageType = type;
    }

    public int GetMonsterGenCount()
    {
        return monster_GenCount;
    }
    public void ChangeStage()
    {
        switch (stageType)
        {
            case Defines.StageType.Infinity:
                stage = new Stage_Infinity();
                break;
            case Defines.StageType.KillCount:
                stage = new Stage_KillCount();
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

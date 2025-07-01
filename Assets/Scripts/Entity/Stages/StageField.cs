using UnityEngine;
using System;
using System.Collections.Generic;
public class StageField : MonoBehaviour
{
    StageData myData;



    int Gen_Monster(int monsterCount)
    {
        int maxCount = GameManager._instance.Get_Stage_MaxGenCount();
        int genCount = Mathf.Clamp(monsterCount, 0, maxCount);
        int rest = monsterCount - genCount;

        for(int i = 0; i < genCount; i++)
        {

        }


        if (rest >= 1)
        {
            return rest;
        }
        else
        {
            return 0;
        }
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
public class StageField : MonoBehaviour
{

    bool isPlayerOn = false;



    private void Awake()
    {
        OnAwake();
    }

    void OnAwake()
    {
        isPlayerOn = false;
        Add_To_List();
    }
    private void Start()
    {
        
    }


    public void Add_To_List()
    {
        if(isPlayerOn == false)
        {
            GameManager._instance.Add_To_Stage_List(this);
        }
    }

    public void Change_isPlayerOn(bool isOn)
    {
        isPlayerOn = isOn;
    }

    public int Gen_Monster(int monsterCount)
    {
        int maxCount = GameManager._instance.Get_Once_Stage_MaxGenCount(); //요청 할 몬스터 수 
        int genCount = Mathf.Clamp(monsterCount, 0, maxCount); //생성할 몬스터 수
        int rest = monsterCount - genCount;
        
        for(int i = 0; i < genCount; i++)
        {
            string key = GameManager._instance.Get_Random_Inactive();
            GameManager._instance.Gen_Monster(key);
        }


        if (rest > 0)
        {
            return rest;
        }
        else
        {
            return 0;
        }
    }

    
}

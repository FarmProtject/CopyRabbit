using UnityEngine;
using System;
using System.Collections.Generic;
public class StageController : MonoBehaviour
{
    [SerializeField]string stageId = "1C1S";
    [SerializeField]string chapter;
    StageBase stage;
    [SerializeField]int monster_GenCount = 7; //한번에 젠 되는 최대 몬스터 수 
    List<string> monsterIDs = new List<string>();
    List<StageField> stageFields = new List<StageField>();

    StageData select_Stage;
    //StageData data_Stage;
    private void Start()
    {
        //Init_Stage(this.stageId);
    }


    void Init_Stage(string id)
    {
        if(select_Stage == null)
        {
            select_Stage = GameManager._instance.Get_StageData_Scriot(stageId);
        }
        Change_StageData(id);
        Change_MonsterIdList();
        GameManager._instance.InitMonster(monsterIDs);

    }
    private void FixedUpdate()
    {
        
    }

    
    public void Change_Stage(string id)
    {
        Change_StageData(id);
        
    }

    public void SetStage(StageData stage)
    {
        
    }

    public Defines.StageType Get_Select_StageType()
    {
        return select_Stage.stageType;
    }
    public StageData Get_SelectStage()
    {
        return select_Stage;
    }
    public void Set_SelectStage(StageData stage)
    {
        select_Stage = stage;
    }

    public void Change_StageData(string id)
    {
        this.stageId = id;
        select_Stage = GameManager._instance.Get_StageData_Scriot(id);
        chapter = select_Stage.chapter;
        GameManager._instance.Get_StagePanelScript().Set_StageKey(chapter);
    }
    void Change_MonsterIdList()
    {
        string spawnKey = select_Stage.spawnGroup;
        Debug.Log(select_Stage.spawnGroup);
        
        monsterIDs.Clear();
        List<StringKeyDatas> data = GameManager._instance.Get_SpawnData()[spawnKey];
        for(int i = 0; i < data.Count; i++)
        {
            monsterIDs.Add(data[i].datas["monsterId"]);
        }
        

    }

    public int Get_Once_MonsterGenCount()
    {
        return monster_GenCount;
    }
    public List<StageField> Get_StageList()
    {
        return stageFields;
    }

    public void Add_Stage_List(StageField stage)
    {
        if (!stageFields.Contains(stage))
        {
            stageFields.Add(stage);
        }
    }

    
    

}

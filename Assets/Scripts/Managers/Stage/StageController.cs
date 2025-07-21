using UnityEngine;
using System;
using System.Collections.Generic;
public class StageController : MonoBehaviour
{
    [SerializeField]string stageId = "1C1S";
    [SerializeField] string chapter;
    StageBase stage;
    [SerializeField]int monster_GenCount = 7; //한번에 젠 되는 최대 몬스터 수 
    List<string> monsterIDs = new List<string>();
    List<StageField> stageFields = new List<StageField>();
    StageData data_Stage;

    private void Start()
    {
        Init_Stage(this.stageId);
    }
    void Init_Stage(string id)
    {
        Change_StageData(id);
        Change_MonsterIdList();
        SetStage();
        GameManager._instance.InitMonster(monsterIDs);

    }
    private void FixedUpdate()
    {
        
    }

    
    public void Change_Stage(string id)
    {
        Change_StageData(id);
        SetStage();
    }

    public void SetStage()
    {
        ChangeStage();
    }

    public void Change_StageData(string id)
    {
        this.stageId = id;
        data_Stage = GameManager._instance.Get_StageData_Scriot(id);
        chapter = data_Stage.chapter;
        GameManager._instance.Get_StagePanelScript().Set_StageKey(chapter);
    }
    void Change_MonsterIdList()
    {
        string spawnKey = data_Stage.spawnGroup;
        Debug.Log(data_Stage.spawnGroup);
        
        monsterIDs.Clear();
        List<StringKeyDatas> data = GameManager._instance.Get_SpawnData()[spawnKey];
        for(int i = 0; i < data.Count; i++)
        {
            monsterIDs.Add(data[i].datas["monsterId"]);
        }
        

    }

    public string Get_StageID()
    {
        return stageId;
    }
    public int Get_Once_MonsterGenCount()
    {
        return monster_GenCount;
    }
    public List<StageField> Get_StageList()
    {
        return stageFields;
    }
    public List<string> Get_MonsterIds()
    {
        return monsterIDs;
    }
    public void Add_Stage_List(StageField stage)
    {
        if (!stageFields.Contains(stage))
        {
            stageFields.Add(stage);
        }
    }

    void Set_StageData(StageData stageData)
    {
        for(int i = 0; i < stageFields.Count; i++)
        {
            //stageFields[i] = 
        }
    }
    public void ChangeStage()
    {
        switch (data_Stage.stageType)
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

using UnityEngine;
using System;
using System.Collections.Generic;
public class StageController : MonoBehaviour
{
    [SerializeField]string id = "1C1S";
    StageBase stage;
    Defines.StageType stageType;
    [SerializeField]int monster_GenCount = 7; //한번에 젠 되는 최대 몬스터 수 
    List<string> monsterIDs = new List<string>();
    List<StageField> stageFields = new List<StageField>();
    StageData data_Stage;

    private void Start()
    {
        Init_Stage(this.id);
    }
    void Init_Stage(string id)
    {
        Cahnge_StageData(id);
        Change_MonsterIdList();
        SetStage(data_Stage.stageType);
        GameManager._instance.InitMonster(monsterIDs);

    }
    private void FixedUpdate()
    {
        
    }

    public void SetStage(Defines.StageType type)
    {
        SetStageType(type);
        ChangeStage();
    }

    void Cahnge_StageData(string id)
    {
        this.id = id;
        data_Stage = GameManager._instance.Get_StageData_Scriot(id);
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
    void SetStageType(Defines.StageType type)
    {
        stageType = type;
    }
    public string Get_StageID()
    {
        return id;
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

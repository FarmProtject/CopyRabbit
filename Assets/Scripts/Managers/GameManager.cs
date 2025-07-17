using UnityEngine;
using System;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public InputManager inputManager;
    GameObject playerObj;
    public UI_Manager _ui_Manager;
    public UpgradeManager _UpgradeManager;
    public StageController stage_Controller;
    PlayerEntity playerEntity;
    Player_Comtroller player_Controller;
    MonsterManager _MonsterManager;
    PoolManager _PoolManager;
    DataManager _DataManager;

    private void Awake()
    {
        OnAwake();
        //Test();


    }

    void Test()
    {
        GameObject go = GameObject.Find("TestPopUp");
        _ui_Manager.AddButtonBind("TestButton", go.name);
        _ui_Manager.AddPopUpObj(go.name, go);
    }

    void Init()
    {
        if (_instance == null)
        {
            _instance = this;
            
        }
        if(_ui_Manager == null)
        {
            _ui_Manager = new UI_Manager();
        }
        if(_UpgradeManager == null)
        {
            _UpgradeManager = new UpgradeManager();
        }
        if(stage_Controller == null)
        {
            stage_Controller = GameObject.Find("StageController").transform.GetComponent<StageController>();
        }
        if(player_Controller == null)
        {
            player_Controller = GameObject.Find("Player").transform.GetComponent<Player_Comtroller>();
        }
        if(_MonsterManager == null)
        {
            _MonsterManager = new MonsterManager();
        }
        if(_PoolManager == null)
        {
            _PoolManager = new PoolManager();
        }
        if(_DataManager == null)
        {
            _DataManager = Utils.GetOrAddComponent<DataManager>(this.gameObject);
            
        }

        Debug.Log(_instance);
    }

    void OnAwake()
    {
        Init();
        playerObj = GameObject.Find("Player");
        inputManager = new InputManager(playerObj);
    }
    #region UIs
    public void Bind_UI_PopUp(UI_PopUpObj bindTarget)
    {
        _ui_Manager.BindPopUp(bindTarget);
    }

    public void PopUpUI(string name)
    {
        _ui_Manager.Pop_Up_UI(name);
    }

    #endregion
    #region GetManagers
    public PoolManager Get_PoolMamagaer()
    {
        return _PoolManager;
    }
    #endregion
    #region Upgrage
    public void Upgrade(Defines.StatType type, double count)
    {
        _UpgradeManager.UpGreadEvent(type,count);
    }

    public double GetUpCount(Defines.StatType type)
    {
        return _UpgradeManager.GetUpData(type);
    }
    #endregion
    #region Stages


    public void Change_Stage(string id)
    {
        stage_Controller.Change_Stage(id);
    }
    public int Get_Once_Stage_MaxGenCount()
    {
        return stage_Controller.Get_Once_MonsterGenCount();
    }
    public void Add_To_Stage_List(StageField stage)
    {
        stage_Controller.Add_Stage_List(stage);
    }
    public List<StageField> Get_StageList()
    {
        return stage_Controller.Get_StageList();
    }
    
    
    
    public string Get_Stage_ID()
    {
        return stage_Controller.Get_StageID();
    }
    public StageData Get_StageData_Scriot(string id)
    {
        return _DataManager.Get_StageData_Script(id);
    }
    public void Add_OnMonsterList(MonsterEntity monster)
    {
        _MonsterManager.Add_OnMonsterList(monster);
    }
    public List<MonsterEntity> Get_MonsterList()
    {
        return _MonsterManager.Get_MonsterList();
    }
    #endregion
    #region Player
    public PlayerEntity GetPlayerEntity()
    {
        return playerEntity;
    }
    public Player_Comtroller GetPlayer_Controller()
    {
        return player_Controller;
    }
    
    public Vector2 GetPlayerPos()
    {
        return playerObj.transform.position;
    }
    public void Set_Player_MoveDir(Vector2 dir)
    {
        player_Controller.SetPlayerDir(dir);
    }
    #endregion
    #region Monsters

    public void InitMonster(List<string> monsterIds)
    {
        _MonsterManager.Init_Stage(monsterIds);
    }
    #region MonsterPooling
    public string Get_Random_Inactive()
    {
        return _PoolManager.Get_Random_Inactive();
    }
    public void Inactive_Monster(string key, GameObject go)
    {
        _PoolManager.Inactive_Obj(key, go);
    }
    public GameObject Gen_Monster(string key)
    {
        return _PoolManager.Get_Monster(key);
    }
    #endregion
    #endregion
    #region Lever
    public Lever_Controller Get_LeverCtr()
    {
        return inputManager.Get_LeverController();
    }
    public Lever_Base Get_Lever_Base()
    {
        return Get_LeverCtr().Get_Lever_Base();
    }
    public Defines.LeverType GetLeverType()
    {
        return inputManager.Get_LeverType();
    }
    #endregion
    #region Datas

    public void Read_Data(string path,Dictionary<string,Dictionary<string,string>>target)
    {
       _DataManager.ReadData(path, target);
    }
    public MonsterStats Get_MonsterStat(string id)
    {
        return _DataManager.Get_MonsterStat(id);
    }
    public Dictionary<string, Dictionary<string, string>> Get_StageDatas()
    {
        return _DataManager.Get_StageDatas();
    }

    public Dictionary<string,List<StringKeyDatas>> Get_SpawnData()
    {
        return _DataManager.Get_SpawnDatas();
    }
    #endregion
}

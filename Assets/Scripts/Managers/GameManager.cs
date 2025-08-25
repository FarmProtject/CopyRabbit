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
    [SerializeField]MonsterSpawner _MonsterSpawner;
    PoolManager _PoolManager;
    DataManager _DataManager;
    UI_Pooler _uiPooler;

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

    void OnAwake()
    {
        Init();
        
        


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
        if (_MonsterSpawner == null)
        {
            _MonsterSpawner = GameObject.Find("MonsterPooler").transform.GetComponent<MonsterSpawner>();
        }
        if (_DataManager == null)
        {
            _DataManager = Utils.GetOrAddComponent<DataManager>(this.gameObject);
            
            
        }
        
        if(_ui_Manager.Get_StagePanel_Script() == null)
        {
            UI_StagePanel stagePanel = Utils.GetOrAddComponent<UI_StagePanel>(GameObject.Find("StagePanel"));
            _ui_Manager.Set_StagePanel_Script(stagePanel);
            stagePanel.Init();
            //stagePanel.gameObject.SetActive(false);
        }
        if(_uiPooler == null)
        {
            _uiPooler = Utils.GetOrAddComponent<UI_Pooler>(this.gameObject);

        }
        if(playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
        if(playerEntity == null)
        {
            playerEntity = playerObj.GetComponent<PlayerEntity>();
        }
        if(inputManager == null)
        {
            inputManager = new InputManager(playerObj);
        }
        
        if (_PoolManager == null)
        {
            _PoolManager = _MonsterManager.Get_PoolManager();
        }
        Debug.Log(_instance);
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
    public Dictionary<Defines.UI_PrefabType, Queue<IPoolUI>> Get_UI_Pool()
    {
        return _uiPooler.Get_Pool();
    }
    public GameObject Get_PoolUI(Defines.UI_PrefabType type,GameObject parents)
    {
        return _uiPooler.Get(type,parents);
    }
    public void Return_PoolUI(Defines.UI_PrefabType type, IPoolUI ui)
    {
        _uiPooler.Return(type,ui);
    }
    public void Set_MenuType(Defines.MenuType type)
    {
        _ui_Manager.Set_MenuType(type);
    }
    public void Set_PopUpBind(Dictionary<string,Dictionary<string,string>>data)
    {
        _ui_Manager.Set_PopUpBind(data);
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
    #region StagesController
    public void Set_SelectStage_Type(Defines.DungeonType type)
    {
        _ui_Manager.Set_SelcectStageType(type);
    }
    public StageData Get_SelectStage()
    {
        return stage_Controller.Get_SelectStage();
    }
    
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
    
    public StageData Get_StageData_Scriot(string id)
    {
        return _DataManager.Get_StageData_Script(id);
    }
    public void Set_StageID(string id)
    {
        stage_Controller.Set_StageId(id);
    }
    public void Set_StageData_Script(StageData stage)
    {
        stage_Controller.Set_SelectStage(stage);
    }
    public void Add_OnMonsterList(GameObject monster)
    {
        _MonsterManager.Add_OnMonsterList(monster);
    }
    public List<GameObject> Get_MonsterList()
    {
        return _MonsterManager.Get_MonsterList();
    }

    public UI_StagePanel Get_StagePanelScript()
    {
        return _ui_Manager.Get_StagePanel_Script();
    }

    public void Init_Stage()
    {
        stage_Controller.Init_Stage();
    }
    #endregion
    #region StagePanel
    public Defines.DungeonType Get_SetlectStage_Type()
    {
        return _ui_Manager.Get_StagePanel_Script().Get_CombatSubType();
    }
    public void Add_StageButtons(Cell_StageRightCell button)
    {
        _ui_Manager.Add_RightCells(button);
    }
    public Dictionary<Defines.DungeonType, Dictionary<int, List<string>>> Get_Chapters()
    {
        return _DataManager.Get_Chapters();
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
    public GameObject Get_MonsterSpawner()
    {
        return _MonsterSpawner.Get_MonsterSpawner();
    }
    public void Inactive_All()
    {
        _MonsterManager.Inactive_All();
    }
    public void InitMonster(List<string> monsterIds)
    {
        _MonsterManager.Init_Stage(monsterIds);
    }
    public GameObject Get_MonsterPrefab()
    {
        
        return _MonsterSpawner.Get_MonsterPrefab();
    }
    #region MonsterPooling
    public string Get_Random_Inactive()
    {
        return _PoolManager.Get_Random_InactiveId();
    }
    public void Inactive_Monster(string key, GameObject go)
    {
        _PoolManager.Inactive_Obj(key, go);
    }
    public GameObject Gen_Monster(string key)
    {
        return _PoolManager.Get_Monster(key);
    }
   
    public void Change_Monsters(List<string> monsterIds)
    {
        _MonsterManager.Change_MonsterIDs(monsterIds);
    }
    public void Add_Inactive(string key, GameObject go)
    {
        _PoolManager.Add_Inactive(key, go);
    }
    public void Gen_Reset()
    {
        _MonsterSpawner.Gen_Reset();
    }
    public void RenewInactiveIds()
    {
        _MonsterManager.RenewInactiveIds();
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
        return _DataManager.Get_Normal_StageDatas();
    }
    public Dictionary<string,List<StringKeyDatas>> Get_ChapterDatas()
    {
        return _DataManager.Get_ChapterDatas();
    }
    public Dictionary<string,List<StringKeyDatas>> Get_SpawnData()
    {
        return _DataManager.Get_SpawnDatas();
    }
    #endregion
}

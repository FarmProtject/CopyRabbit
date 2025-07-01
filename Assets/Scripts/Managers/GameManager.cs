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
    public StageManager _StageManager;
    PlayerEntity playerEntity;
    Player_Comtroller player_Controller;
    
    private void Awake()
    {
        OnAwake();
        Test();


    }

    void Test()
    {
        GameObject go = GameObject.Find("TestPopUp");
        _ui_Manager.AddButtonBind("TestButton", go.name);
        _ui_Manager.AddPopUpObj(go.name, go);
    }

    void Init()
    {
        Debug.Log(_instance);
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
        if(_StageManager == null)
        {
            _StageManager = new StageManager();
        }
        if(player_Controller == null)
        {
            player_Controller = GameObject.Find("Player").transform.GetComponent<Player_Comtroller>();
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
    public void Set_StageType(Defines.StageType type)
    {
        _StageManager.SetStage(type);
    }
    public int Get_Stage_MaxGenCount()
    {
        return _StageManager.GetMonsterGenCount();
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
    
}

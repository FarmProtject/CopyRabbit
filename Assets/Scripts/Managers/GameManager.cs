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
        Debug.Log(_instance);
    }

    void OnAwake()
    {
        Init();
        playerObj = GameObject.Find("Player");
        inputManager = new InputManager(playerObj);
    }

    public void Bind_UI_PopUp(UI_PopUpObj bindTarget)
    {
        _ui_Manager.BindPopUp(bindTarget);
    }

    public void PopUpUI(string name)
    {
        _ui_Manager.Pop_Up_UI(name);
    }


    public void Upgrade(Defines.StatType type, double count)
    {
        _UpgradeManager.UpGreadEvent(type,count);
    }

    public double GetUpCount(Defines.StatType type)
    {
        return _UpgradeManager.GetUpData(type);
    }

    public void SetStage(Defines.StageType type)
    {
        _StageManager.SetStage(type);
    }
    
    public PlayerEntity GetPlayerEntity()
    {
        return playerEntity;
    }
    public void SetMoveDir(Vector2 moveDir)
    {
        inputManager.SetMoveDir(moveDir);
    }
    public Vector2 GetPlayerPos()
    {
        return playerObj.transform.position;
    }

    public Defines.LeverType GetLeverType()
    {
        return inputManager.Get_LeverType();
    }
}

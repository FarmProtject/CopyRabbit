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
}

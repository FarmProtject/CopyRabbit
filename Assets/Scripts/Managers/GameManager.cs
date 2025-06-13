using UnityEngine;
using System;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public InputManager inputManager;
    GameObject playerObj;
    private void Awake()
    {
        OnAwake();
    }
    void Init()
    {
        Debug.Log(_instance);
        if (_instance == null)
        {
            _instance = this;
            
        }
        Debug.Log(_instance);
    }

    void OnAwake()
    {
        Init();
        playerObj = GameObject.Find("Player");
        inputManager = new InputManager(playerObj);
    }


}

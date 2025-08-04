using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
public class Cell_RewardPanel : MonoBehaviour,IPoolUI
{
    [SerializeField]Defines.UI_PrefabType type;
    TextMeshProUGUI rewardText;

    public void DisableFunction()
    {
        GameManager._instance.Return_PoolUI(type, this);
    }

    public void EnableFunction()
    {
        
    }

    public GameObject Get()
    {
        //this.gameObject.SetActive(true);

        return this.gameObject;
    }

    public void Init()
    {
        throw new NotImplementedException();
    }

    public void OnDisable()
    {
        DisableFunction();
    }
    public void OnEnable()
    {
        EnableFunction();
    }

    public void Return()
    {
        throw new NotImplementedException();
    }
}

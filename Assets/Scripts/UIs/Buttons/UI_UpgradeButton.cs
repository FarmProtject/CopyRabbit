using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
public class UI_UpgradeButton : UI_Buttons
{
    Defines.StatType myButtonStat;
    double upgrade_Count;
    private void Start()
    {
        //Bind<TextMeshProUGUI>(typeof(TextMeshProUGUI));
        SetMyData();
        AddUIEvent(this.gameObject, OnclickEvent, Defines.UIEvents.Click);
        Bind<TextMeshProUGUI>();
    }

    void SetMyData()
    {
        myButtonStat = Defines.StatType.Attack;
        upgrade_Count = 1;
    }
    void OnclickEvent(PointerEventData evt)
    {
        GameManager._instance.Upgrade(myButtonStat, upgrade_Count);
        Get<TextMeshProUGUI>("UpText").text = GameManager._instance._UpgradeManager.GetAtkCount().ToString();
        //upgrade_Count = GameManager._instance._UpgradeManager.GetAtkCount();

    }
}

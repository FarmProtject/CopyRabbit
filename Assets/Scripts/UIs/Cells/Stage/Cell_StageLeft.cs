using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class Cell_StageLeft : MonoBehaviour
{
    string iconId;
    [SerializeField]Image myIcon;
    private void Awake()
    {
        GameManager._instance._ui_Manager.Add_LeftCells(this);
        myIcon = Utils.FindChild<Image>(this.gameObject);
    }

}

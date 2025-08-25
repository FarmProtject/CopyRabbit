using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class Cell_StageLeft : MonoBehaviour
{
    [SerializeField]string typeId;
    [SerializeField]string dataId;
    
    List<Cell_Icon> myIcons = new List<Cell_Icon>();

    

    public void Set_MyID(string id)
    {
        dataId = id;
        UpdateDatas();
    }


    void UpdateDatas()
    {

    }

}

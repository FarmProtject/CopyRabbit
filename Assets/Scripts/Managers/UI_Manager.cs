using UnityEngine;
using System;
using System.Collections.Generic;
public class UI_Manager 
{
    Dictionary<string, GameObject> popUpObjs = new Dictionary<string, GameObject>();
    Dictionary<string, string> buttonBind = new Dictionary<string, string>();//버튼이름 키 , 열릴 오브젝트 밸류 , 이부분 CSV로 매핑처리 필요

    List<GameObject> opened_UIs = new List<GameObject>();

    UI_StagePanel stagePanel;

    UI_MenuPanel menuPanel;

    public void Init()
    {
        /*
        if(menuPanel == null)
        {
            menuPanel = GameObject.Find("MenuPanel").GetComponent<UI_MenuPanel>();
        }*/
        if(menuPanel == null)
        {
            menuPanel = GameObject.Find("Menues").transform.GetChild(3).gameObject.transform.GetComponent<UI_MenuPanel>();
        }
        Debug_Buttons();

        
    }
    #region PopUp
    void Debug_Buttons()
    {
        Debug.Log("buttonBind");
        foreach(var key in buttonBind.Keys)
        {
            Debug.Log($"key : {key} value : {buttonBind[key]}");
        }
        Debug.Log("popUpObjs");
        foreach(var key in popUpObjs.Keys)
        {
            Debug.Log($"Key : {key} value name : {popUpObjs[key].name}");
        }
    }
    public void BindPopUp(UI_PopUpObj uiObj)
    {
        string name = uiObj.gameObject.name;
        if (!popUpObjs.ContainsKey(name))
        {
            popUpObjs.Add(name, uiObj.gameObject);
        }
    }
    public void Set_StagePanel_Script(UI_StagePanel script)
    {
        stagePanel = script;
    }
    public UI_StagePanel Get_StagePanel_Script()
    {
        return stagePanel;
    }
    public void Set_PopUpBind(Dictionary<string, Dictionary<string,string>> data)
    {
        
        foreach (string key in data.Keys)
        {
            string ky = data[key]["key"];
            string value = data[key]["target"];
            buttonBind.Add(ky, value);
        }
        
    }
    public void AddButtonBind(string key, string value)
    {
        if (!buttonBind.ContainsKey(key))
        {
            buttonBind.Add(key, value);
        }
    }

    public void AddPopUpObj(string name, GameObject go)
    {
        if (!popUpObjs.ContainsKey(name))
        {
            popUpObjs.Add(name, go);
            Debug.Log($" Pop Up Added{name}");
        }
    }

    public void Pop_Up_UI(string button_Name)
    {
        Debug.Log($"Button Name {button_Name}, OpenUI Name {buttonBind[button_Name]}");
        
        if (buttonBind.ContainsKey(button_Name))
        {
            string targetName = buttonBind[button_Name];
            if (!popUpObjs.ContainsKey(targetName))
            {
                Debug.Log("name Didn't Contain");
                return;
            }
            GameObject target = popUpObjs[targetName];
            if (target.activeSelf)
            {
                target.SetActive(false);
                Debug.Log("Setactive False");
                
            }
            else
            {
                target.SetActive(true);
                Debug.Log("SetActive True");
                
            }
            AddorRemoveAtList(target);
        }
    }

    void AddorRemoveAtList(GameObject go)
    {
        if (opened_UIs.Contains(go))
        {
            opened_UIs.Remove(go);
        }
        else
        {
            opened_UIs.Add(go);
        }
    }

    public void Add_RightCells(Cell_StageRightCell button)
    {
        stagePanel.Add_Buttons(button);
    }
    public void Add_LeftCells(Cell_StageLeft cell)
    {
        stagePanel.Add_LeftCells(cell);
    }

    #endregion

    #region Menus
    public void Set_MenuType(Defines.MenuType type)
    {
        if(menuPanel == null)
        {
            Init();
        }
        menuPanel.Set_MyType(type);
    }
    #endregion

    #region subPanel
     

    void Cell_CombatSubPanel()
    {
        
    }

    void Cell_ShopSubPanel()
    {

    }

    void Cell_MenuSubPanel()
    {

    }

    #endregion
    #region StagePanel
   public void Set_SelcectStageType(Defines.CombatSubPanels type)
    {
        stagePanel.Set_CombatSubType(type);
    }
    #endregion
}

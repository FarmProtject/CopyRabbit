using UnityEngine;
using System;
using System.Collections.Generic;
public class UI_Manager 
{
    Dictionary<string, GameObject> popUpObjs = new Dictionary<string, GameObject>();
    Dictionary<string, string> buttonBind = new Dictionary<string, string>();//��ư�̸� Ű , ���� ������Ʈ ��� , �̺κ� CSV�� ����ó�� �ʿ�

    List<GameObject> opened_UIs = new List<GameObject>();

    UI_StagePanel stagePanel;

    UI_MenuPanel menuPanel;

    public void Init()
    {
        if(menuPanel == null)
        {
            menuPanel = GameObject.Find("MenuPanel").GetComponent<UI_MenuPanel>();
        }
    }
    #region PopUp
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
        }
    }

    public void Pop_Up_UI(string button_Name)
    {
        Debug.Log($"{button_Name}");
        if (buttonBind.ContainsKey(button_Name))
        {
            Debug.Log("Key COntained ");
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
        menuPanel.Set_myType(type);
    }
    #endregion
}

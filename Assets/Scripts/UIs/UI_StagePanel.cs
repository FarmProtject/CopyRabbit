using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class UI_StagePanel : MonoBehaviour
{
    public Defines.RightPanelType panelType = Defines.RightPanelType.Stage;

    string cahpterKey;
    string next;
    string before;

    List<string> stageKeys = new List<string>();
    List<Cell_PortalRightCell> uI_StageButtons = new List<Cell_PortalRightCell>();
    List<Cell_StageLeft> ui_StageLeftCells = new List<Cell_StageLeft>();

    List<GameObject> leftPanelCells = new List<GameObject>();

    [SerializeField] string selectStage;
    [SerializeField]GameObject rightPanel;
    [SerializeField]GameObject prefab_RightCell;
    [SerializeField] GameObject leftPanel;
    [SerializeField] GameObject prefab_LeftContents;
    [SerializeField] GameObject prefab_LeftPanelCell;
    private void OnEnable()
    {
        OnRightPanelEnable();
    }

    public void OnRightPanelEnable()
    {
        switch (panelType)
        {
            case Defines.RightPanelType.Stage:
                break;
            case Defines.RightPanelType.Challenge:
                break;
            default:
                break;
        }
    }

    public string Get_StageKey()
    {
        return cahpterKey;
    }
    public void Set_StageKey(string key)
    {
        cahpterKey = key;
        stageKeys.Clear();
        Dictionary<string, List<StringKeyDatas>> chapterDatas = GameManager._instance.Get_ChapterDatas();

        Debug.Log($" Cahpter Data Count{chapterDatas[cahpterKey].Count}");
        
        for(int i = 0; i<chapterDatas[cahpterKey].Count; i++)
        {
            stageKeys.Add(chapterDatas[cahpterKey][i].datas["id"]);
        }
        Set_RightCells();
        Set_Stage_LeftCells();
        for(int i = 0; i<chapterDatas[cahpterKey].Count; i++)
        {
            string id = chapterDatas[cahpterKey][i].datas["id"];
            uI_StageButtons[i].Init(id);
        }
    }

    public void Add_Buttons(Cell_PortalRightCell button)
    {
        if (!uI_StageButtons.Contains(button))
        {
            uI_StageButtons.Add(button);
        }
    }
    public void Add_LeftCells(Cell_StageLeft cell)
    {
        if (!ui_StageLeftCells.Contains(cell))
        {
            ui_StageLeftCells.Add(cell);
        }
    }
    public void Init_Buttons()
    {
        Set_RightCells();
        for(int i = 0; i< stageKeys.Count; i++)
        {
            string id = stageKeys[i];
            uI_StageButtons[i].Init(id);
        }
    }

    void Set_RightCells()
    {
        int count = stageKeys.Count - uI_StageButtons.Count;
        if(rightPanel == null)
        {
            rightPanel = GameObject.Find("RightCellContents");
        }
        for(int i = 0; i<uI_StageButtons.Count; i++)
        {
            uI_StageButtons[i].gameObject.SetActive(true);
        }
        if (count>=1)
        {
            for (int i = 0; i<count; i++)
            {
                GameObject go = Instantiate(prefab_RightCell);
                go.transform.SetParent(rightPanel.transform);
            }
        }
        
        else if (count<0)
        {
            count *=-1;

            for(int i = 0; i<count; i++)
            {
                uI_StageButtons[i].gameObject.SetActive(false);
            }
        }

        rightPanel.transform.localPosition = new Vector2(0, 0);

    }
    void Set_Stage_LeftCells()
    {
        switch (panelType)
        {
            case Defines.RightPanelType.Stage:
                break;
            case Defines.RightPanelType.Challenge:
                break;
            default:
                break;
        }
    }
}

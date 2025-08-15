using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class UI_StagePanel : UI_PopUpObj
{
    string cahpterKey;
    string next;
    string before;

    List<string> stageKeys = new List<string>();

    List<Cell_StageRightCell> uI_StageRightCells = new List<Cell_StageRightCell>();
    List<Cell_StageLeft> ui_StageLeftCells = new List<Cell_StageLeft>();

    List<GameObject> leftPanelCells = new List<GameObject>();

    [SerializeField] int selectChapter;
    [SerializeField] string selectStage;

    [SerializeField]GameObject rightPanelContents;
    [SerializeField]GameObject rightPanel;
    [SerializeField]GameObject prefab_RightCell;
    [SerializeField]ScrollRect rightScroll;
    [SerializeField]GameObject leftPanel;
    [SerializeField]ScrollRect leftScroll;
    [SerializeField]GameObject prefab_LeftContents;
    [SerializeField]GameObject prefab_LeftPanelCell;
    [SerializeField]GameObject tailPanel;

    [SerializeField]Defines.CombatSubPanels select_Type;

    protected override void Awake()
    {
        Init();
        base.Awake();
    }
    private void OnEnable()
    {
        //Init();
        Set_SelectChapter();
        InitStageList();
        OnRightPanelEnable();
        OnLeftPanelEnable();
        OnLeftPanelEnable();
        OnTailPanelEnable();
        Set_ScrollPos();
    }
    public override void Init()
    {
        base.Init();
        
        if(rightPanelContents == null)
        {
            rightPanelContents = GameObject.Find("RightCellContents");
        }
        if(leftPanel == null)
        {
            leftPanel = GameObject.Find("LeftPanel");
        }
        if(tailPanel == null)
        {
            tailPanel = GameObject.Find("TailPanel");
        }
        if(rightScroll = null)
        {
            rightScroll = rightPanel.transform.GetComponent<ScrollRect>();
        }
        if(leftScroll == null)
        {
            //leftScroll = leftPanel.transform.GetComponent<ScrollRect>();
        }
        //this.gameObject.SetActive(false);
    }
    public void Set_SelectChapter()
    {
        selectChapter = GameManager._instance.GetPlayerEntity().Get_LastChapter(select_Type);
    }
    public void OnRightPanelEnable()
    {
        
        switch (select_Type)
        {
            case Defines.CombatSubPanels.Portal:
                Init_Buttons();
                break;
            case Defines.CombatSubPanels.Treasure:
                break;
            case Defines.CombatSubPanels.Skill:
                break;
            case Defines.CombatSubPanels.Gold:
                break;
            case Defines.CombatSubPanels.Guardian:
                break;
            case Defines.CombatSubPanels.Boss:
                break;
            default:
                break;
        }
    }
    public void OnLeftPanelEnable()
    {

        switch (select_Type)
        {
            case Defines.CombatSubPanels.Portal:
                break;
            case Defines.CombatSubPanels.Treasure:
                break;
            case Defines.CombatSubPanels.Skill:
                break;
            case Defines.CombatSubPanels.Gold:
                break;
            case Defines.CombatSubPanels.Guardian:
                break;
            case Defines.CombatSubPanels.Boss:
                break;
            default:
                break;
        }
    }
    public void OnTailPanelEnable()
    {
        switch (select_Type)
        {
            case Defines.CombatSubPanels.Portal:
                break;
            case Defines.CombatSubPanels.Treasure:
                break;
            case Defines.CombatSubPanels.Skill:
                break;
            case Defines.CombatSubPanels.Gold:
                break;
            case Defines.CombatSubPanels.Guardian:
                break;
            case Defines.CombatSubPanels.Boss:
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
        //Set_Stage_LeftCells();
        for(int i = 0; i<chapterDatas[cahpterKey].Count; i++)
        {
            string id = chapterDatas[cahpterKey][i].datas["id"];
            uI_StageRightCells[i].Init(id);
        }
    }

    public void Add_Buttons(Cell_StageRightCell button)
    {
        if (!uI_StageRightCells.Contains(button))
        {
            uI_StageRightCells.Add(button);
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
            uI_StageRightCells[i].Init(id);
        }
    }

    void Set_RightCells()
    {
        int count = stageKeys.Count - uI_StageRightCells.Count;
        if(rightPanelContents == null)
        {
            rightPanelContents = GameObject.Find("RightCellContents");
        }
        for(int i = 0; i< uI_StageRightCells.Count; i++)
        {
            uI_StageRightCells[i].gameObject.SetActive(true);
        }
        if (count>=1)
        {
            for (int i = 0; i<count; i++)
            {
                GameObject go = Instantiate(prefab_RightCell);
                go.transform.SetParent(rightPanelContents.transform);
            }
        }
        
        else if (count<0)
        {
            count *=-1;

            for(int i = 0; i<count; i++)
            {
                uI_StageRightCells[i].gameObject.SetActive(false);
            }
        }

        rightPanelContents.transform.localPosition = new Vector2(0, 0);

    }
    public void Set_CombatSubType(Defines.CombatSubPanels type)
    {
        select_Type = type;
    }

    public Defines.CombatSubPanels Get_CombatSubType()
    {
        return select_Type;
    }
    #region SetCells
    void InitStageList()
    {
        PlayerEntity entity = GameManager._instance.GetPlayerEntity();
        int lastChapter = entity.Get_LastChapter(select_Type);
        stageKeys = GameManager._instance.Get_Chapters()[select_Type][lastChapter];
        for(int i = 0; i < stageKeys.Count; i++)
        {
            Debug.Log($"Stage Key :  {stageKeys[i]}");
        }
    }
    void Set_RightCells(int count)
    {
        
        for(int i = 0; i<stageKeys.Count; i++)
        {
            GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageRight, rightPanelContents);
        }
    }
    #endregion

    void Set_ScrollPos()
    {
        rightScroll.verticalNormalizedPosition = 0;
        leftScroll.verticalNormalizedPosition = 0;
    }
}

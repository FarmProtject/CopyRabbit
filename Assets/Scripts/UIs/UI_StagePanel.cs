using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] float rightCellSizeY=100f;

    [SerializeField] GameObject bodyPanel;
    [SerializeField]GameObject rightPanelContents;
    [SerializeField]GameObject rightPanel;
    [SerializeField]GameObject prefab_RightCell;
    [SerializeField]ScrollRect rightScroll;
    [SerializeField]GameObject leftPanel;
    [SerializeField]ScrollRect leftScroll;
    [SerializeField]GameObject prefab_LeftContents;
    [SerializeField]GameObject prefab_LeftPanelCell;
    [SerializeField]GameObject tailPanel;

    [SerializeField] GameObject normalButtons;
    [SerializeField] GameObject challengeButtons;

    [SerializeField]Defines.DungeonType select_Type;

    [SerializeField] StringKey_UI dungeonText;

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
        Set_DungeonText_Key();
    }
    private void OnDisable()
    {
        
    }
    public override void Init()
    {
        base.Init();
        if(bodyPanel == null)
        {
            bodyPanel = transform.GetChild(1).gameObject;
        }
        if(rightPanelContents == null)
        {
            rightPanelContents = GameObject.Find("RightCellContents");
        }
        if(rightPanel == null)
        {
            rightPanel = bodyPanel.transform.GetChild(1).gameObject;
        }
        if(leftPanel == null)
        {
            leftPanel = bodyPanel.transform.GetChild(0).gameObject;
        }
        if(tailPanel == null)
        {
            tailPanel = GameObject.Find("TailPanel");
        }
        if(rightScroll == null)
        {
            rightScroll = rightPanel.transform.GetComponent<ScrollRect>();
        }
        if(leftScroll == null)
        {
            //leftScroll = leftPanel.transform.GetComponent<ScrollRect>();
        }
        //this.gameObject.SetActive(false);
        if(rightPanelContents ==null)
        {
            rightPanelContents = rightPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        }
        if(normalButtons == null)
        {
            normalButtons = tailPanel.transform.GetChild(0).gameObject;
        }
        if(challengeButtons == null)
        {
            challengeButtons = tailPanel.transform.GetChild(1).gameObject;
        }
        if(dungeonText == null)
        {
            this.gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<StringKey_UI>();
        }
    }
    public void Set_SelectChapter()
    {
        selectChapter = GameManager._instance.GetPlayerEntity().Get_LastChapter(select_Type);
    }
    public void OnRightPanelEnable()
    {
        Init_RightButtons();
        /*
        switch (select_Type)
        {
            case Defines.DungeonType.Portal:
                Init_RightButtons();
                break;
            case Defines.DungeonType.Gem:

                break;
            case Defines.DungeonType.Skill:
                break;
            case Defines.DungeonType.Gold:
                break;
            case Defines.DungeonType.Tower:
                break;
            case Defines.DungeonType.Boss:
                break;
            default:
                break;
        }*/
    }
    public void OnLeftPanelEnable()
    {
        for(int i = 0; i<ui_StageLeftCells.Count; i++)
        {
            ui_StageLeftCells[i].gameObject.SetActive(false);
        }
        switch (select_Type)
        {
            case Defines.DungeonType.Portal:
                
                break;
            case Defines.DungeonType.Gem:
                break;
            case Defines.DungeonType.Skill:
                break;
            case Defines.DungeonType.Gold:
                break;
            case Defines.DungeonType.Tower:
                break;
            case Defines.DungeonType.Boss:
                break;
            default:
                break;
        }
    }
    public void OnTailPanelEnable()
    {
        switch (select_Type)
        {
            case Defines.DungeonType.Portal:
                normalButtons.SetActive(true);
                break;
            case Defines.DungeonType.Gem:
                challengeButtons.SetActive(true);
                break;
            case Defines.DungeonType.Skill:
                challengeButtons.SetActive(true);
                break;
            case Defines.DungeonType.Gold:
                challengeButtons.SetActive(true);
                break;
            case Defines.DungeonType.Tower:
                challengeButtons.SetActive(true);
                break;
            case Defines.DungeonType.Boss:
                challengeButtons.SetActive(true);
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
    public void Init_RightButtons()
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
        if (rightPanelContents == null)
        {
            rightPanelContents = GameObject.Find("RightCellContents");
        }
        int count = stageKeys.Count;
        GameManager._instance.Return_All_PoolUI(Defines.UI_PrefabType.Cell_StageRight);
        uI_StageRightCells.Clear();
        for(int i = 0; i<count; i++)
        {
            GameObject go = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageRight, rightPanelContents);
        }

        for(int i = 0; i<rightPanelContents.transform.childCount; i++)
        {
            GameObject go = rightPanelContents.transform.GetChild(i).gameObject;
            if (go.activeSelf)
            {
                Cell_StageRightCell script = go.transform.GetComponent<Cell_StageRightCell>();
                uI_StageRightCells.Add(script);
            }

        }
        rightPanelContents.transform.localPosition = new Vector2(0, 0);
        /*
        for (int i = 0; i< uI_StageRightCells.Count; i++)
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
        */
        

    }
    public void Set_PortalLeft()
    {
        GameObject monstersUI = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageLeft, leftPanel);
        Cell_StageLeft monsterLeft = monstersUI.transform.GetComponent<Cell_StageLeft>();
        GameObject rewardsUI = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageLeft, leftPanel);
        Cell_StageLeft rewardsLeft = rewardsUI.transform.GetComponent<Cell_StageLeft>();
    }
    public void Set_ChallengeLeft()
    {
        StageData data = GameManager._instance.Get_StageData_Scriot(select_Type,selectStage);
        GameObject rewardSUI = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageLeft, leftPanel);
        GameObject rewardAUI = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageLeft, leftPanel);
        GameObject rewardBUI = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.Cell_StageLeft, leftPanel);

        if(data is ChallengeStageData challenge)
        {
            Cell_StageLeft rewardS = rewardSUI.transform.GetComponent<Cell_StageLeft>();
            Cell_StageLeft rewardA = rewardAUI.transform.GetComponent<Cell_StageLeft>();
            Cell_StageLeft rewardB = rewardBUI.transform.GetComponent<Cell_StageLeft>();
        }

        

    }
    public void Set_CombatSubType(Defines.DungeonType type)
    {
        select_Type = type;
        Debug.Log($"select Type : {type}");
    }

    public Defines.DungeonType Get_CombatSubType()
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
        if(rightScroll == null)
        {
            rightPanel.transform.GetComponent<ScrollRect>();
        }   
        if(rightScroll == null)
        {
            rightScroll = rightPanel.transform.GetComponent<ScrollRect>();
        }
        if(leftScroll == null)
        {
            leftScroll = leftPanel.transform.GetComponent<ScrollRect>();
        }
        int count = stageKeys.Count;
        count = count/2;
        Vector2 pos = new Vector2(0, -count*rightCellSizeY);
        rightPanelContents.transform.localPosition = pos;;
    }


    void Set_DungeonText_Key()
    {
        dungeonText.Set_AdditionalKey(select_Type.ToString());
    }
}

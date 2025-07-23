using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class UI_StagePanel : MonoBehaviour
{
    string cahpterKey;
    string next;
    string before;
    List<UI_PortalRightCell> uI_StageButtons = new List<UI_PortalRightCell>();
    List<string> stageKeys = new List<string>();
    [SerializeField]GameObject rightPanel;
    [SerializeField]GameObject prefab_RightCell;
    [SerializeField] GameObject leftPanel;
    [SerializeField] GameObject prefab_LeftCell;
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
        for(int i = 0; i<chapterDatas[cahpterKey].Count; i++)
        {
            string id = chapterDatas[cahpterKey][i].datas["id"];
            uI_StageButtons[i].Init(id);
        }
    }

    public void Add_Buttons(UI_PortalRightCell button)
    {
        if (!uI_StageButtons.Contains(button))
        {
            uI_StageButtons.Add(button);
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
}

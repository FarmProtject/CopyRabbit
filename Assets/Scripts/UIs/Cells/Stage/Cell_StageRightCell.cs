using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Cell_StageRightCell : UI_Buttons , IPoolUI
{
    [SerializeField] string stageId;
    TextMeshProUGUI stageText;
    TextMeshProUGUI combatText;
    private void Awake()
    {
        GameManager._instance.Add_StageButtons(this);

    }
    private void Start()
    {

    }

    public virtual void Init(string id)
    {
        AddUIEvent(this.gameObject, OnClickEvent, Defines.UIEvents.Click);
        Set_MyData(id);
    }
    public void Set_MyData(string idData)
    {
        stageId = idData;
    }

    void OnClickEvent(PointerEventData evt)
    {
        if (stageId == null)
        {
            Debug.Log("Stage Id is Null In StageButton");
            return;
        }
        GameManager._instance.Set_StageID(stageId);
        Debug.Log("RightCell Clicked");
        //GameManager._instance.Change_Stage(stageId);
    }

    public void Init()
    {
        //throw new System.NotImplementedException();
    }

    public void OnDisable()
    {
        //throw new System.NotImplementedException();
    }

    public GameObject Get()
    {
        return this.gameObject;
        //throw new System.NotImplementedException();
    }

    public void EnableFunction()
    {
        //throw new System.NotImplementedException();
    }

    public void DisableFunction()
    {
        //throw new System.NotImplementedException();
    }

    public void Return()
    {
        //throw new System.NotImplementedException();
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_MenuPanel : UI_PopUpObj,IPoolUI
{
    List<GameObject> myButtons = new List<GameObject>();

    [SerializeField]Defines.MenuType myType;

    RectTransform myRectTransform;

    int buttonSize;
    private static readonly Dictionary<Type, Type> _enumToComponentMap = new()
{
    { typeof(Defines.CombatSubPanels), typeof(Cell_CombatSubCell) },
    { typeof(Defines.MenuSubPanels), typeof(Cell_MenuSubCell) },
    { typeof(Defines.ShopSubPanels), typeof(Cell_ShopSubCell) },
};

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        myButtons.Clear();
        Adjust_LayOut();
    }
    private void OnDisable()
    {
        ReturnAll();
        myButtons.Clear();
    }
    void Init_Menu()
    {
        
    }
    #region OnEnable
    void Adjust_LayOut()
    {
        if(myRectTransform == null)
        {
            myRectTransform = transform.GetComponent<RectTransform>();
        }
        ResetButtons();
        Init_Buttons();
        Resize();
        RePositioning();
    }
    void ResetButtons()
    {
        foreach(var button in myButtons)
        {
            IPoolUI ui = button.transform.GetComponent<IPoolUI>();
            GameManager._instance.Return_PoolUI(Defines.UI_PrefabType.MenuButton, ui);
        }
        myButtons.Clear();
    }
    void Init_Buttons()
    {
        switch (myType)
        {
            case Defines.MenuType.Menu:
                Defines.MenuSubPanels[] menus = (Defines.MenuSubPanels[])Enum.GetValues(typeof(Defines.MenuSubPanels));
                ButtonMake(menus);
                break;
            case Defines.MenuType.Combat:
                Defines.CombatSubPanels[] combatMenus = (Defines.CombatSubPanels[])Enum.GetValues(typeof(Defines.CombatSubPanels));

                foreach(var value in combatMenus)
                {
                    Debug.Log($"Value Name : {value}");
                }
                for(int i = 0; i<combatMenus.Length; i++)
                {
                    Debug.Log( combatMenus[i]);
                }
                ButtonMake(combatMenus);
                Debug.Log($" my Buttons : {myButtons.Count}");
                break;
            case Defines.MenuType.Shop:
                Defines.ShopSubPanels[] shopMenus = (Defines.ShopSubPanels[])Enum.GetValues(typeof(Defines.ShopSubPanels));
                ButtonMake(shopMenus);
                break;
            default:
                break;
        }
    }
    void ButtonMake<T>(T[] types) where T : Enum
    {
        Debug.Log("ButtonMake");
        foreach (var value in types)
        {
            GameObject go = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.MenuButton, this.gameObject);
            go.name = value.ToString();
            myButtons.Add(go);
            Debug.Log($"Button Name : {go.name}");
            var builder = Set_Cell_Script(value, go);
            if(builder is Cell_MenuCell cell)
            {
                cell.Set_MyType(value);
            }
        }
    }
    void Resize()
    {
        int buttonCount = myButtons.Count;
        float myHeight = myRectTransform.rect.height;
        buttonSize = (int)this.transform.GetComponent<GridLayoutGroup>().cellSize.y;
        float culculated = buttonCount*buttonSize;
        myRectTransform.sizeDelta = new Vector2(myRectTransform.rect.width, culculated);
    }
    void RePositioning()
    {
        if (myRectTransform == null)
        {
            myRectTransform = GetComponent<RectTransform>();
        }
        Vector2 mySize = myRectTransform.rect.size;
        myRectTransform.anchoredPosition = new Vector2(0, -mySize.y);

        Debug.Log($" Pos : {mySize}");
        Debug.Log("RePositioning");
    }
    public void Set_MyType(Defines.MenuType menuType)
    {
        myType = menuType;
    }
    ISubPanelBuilder Set_Cell_Script<T>(T type, GameObject go) where T : Enum
    {
        var enumType = typeof(T);
        var scriptType = _enumToComponentMap[enumType];
        var script = go.transform.GetComponent(scriptType);
        if(script is ISubPanelBuilder subBuilder)
        {

        }
        if (script != null && script is Behaviour behavior)
        {
            behavior.enabled = true;
            return script as ISubPanelBuilder;
        }
        else if (_enumToComponentMap.TryGetValue(enumType, out var componentType))
        {
            //Utils.GetOrAddComponent<typeof(componentType)>(go)
            go.AddComponent(componentType);
            return go.GetComponent<ISubPanelBuilder>();
        }
        else
        {
            Debug.LogWarning($"정의되지 않은 Enum 타입: {enumType}");
            return null;
        }
    }
    #endregion
    #region OnDisable

    void ReturnAll()
    {
        for(int i = 0; i<myButtons.Count; i++)
        {
            IPoolUI ui = myButtons[i].transform.GetComponent<IPoolUI>();
            GameManager._instance.Return_PoolUI(Defines.UI_PrefabType.MenuButton, ui);
        }
    }


    #endregion
    #region interface
    public void EnableFunction()
    {

    }

    public void DisableFunction()
    {

    }

    public GameObject Get()
    {
        return this.gameObject;
    }

    public void Return()
    {
        this.gameObject.SetActive(false);
    }
    #endregion
}

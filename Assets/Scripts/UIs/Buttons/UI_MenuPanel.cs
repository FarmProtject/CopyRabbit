using UnityEngine;
using System;
using System.Collections.Generic;
public class UI_MenuPanel : UI_PopUpObj
{
    List<GameObject> myButtons = new List<GameObject>();

    [SerializeField]Defines.MenuType myType;

    RectTransform myRectTransform;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        Adjust_LayOut();
    }
    void Init_Menu()
    {
        
    }

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
        }
    }
    void Resize()
    {
        int buttonCount = myButtons.Count;
        float myHeight = myRectTransform.rect.height;
        float culculated = buttonCount*myHeight;
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
    public void Set_myType(Defines.MenuType menuType)
    {
        myType = menuType;
    }
    
}

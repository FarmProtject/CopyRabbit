using UnityEngine;
using System;
using System.Collections.Generic;
public class UI_MenuPanel : MonoBehaviour
{
    List<GameObject> myButtons = new List<GameObject>();

    Defines.MenuType myType;

    RectTransform myRectTransform;
    

    void Init_Menu()
    {
        
    }

    void Adjust_LayOut()
    {
        Init_Buttons();
        Resize();
        RePositioning();
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
        foreach(var value in types)
        {
            GameObject go = GameManager._instance.Get_PoolUI(Defines.UI_PrefabType.MenuButton, this.gameObject);
            go.name = value.ToString();
        }
    }
    void Resize()
    {

    }
    void RePositioning()
    {
        if (myRectTransform == null)
        {
            myRectTransform = GetComponent<RectTransform>();
        }
        Vector2 mySize = myRectTransform.rect.size;

        myRectTransform.localPosition = new Vector3(0, -mySize.y);
    }
    public void Set_myType(Defines.MenuType menuType)
    {
        myType = menuType;
    }
    
}

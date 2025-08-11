using UnityEngine;

public class Cell_ShopSubCell : Cell_MenuCell
{
    Defines.ShopSubPanels myType;
    public override void Set_MyType<T>(T type)
    {
        base.Set_MyType(type);
        if (type is Defines.ShopSubPanels subType)
        {
            myType = subType;
            Debug.Log(myType);
        }
    }
    public override void Set_PanelType()
    {
        base.Set_PanelType();
    }
}

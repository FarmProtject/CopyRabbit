using UnityEngine;

public class Cell_MenuSubCell : Cell_MenuCell
{
    Defines.MenuSubPanels myType;
    public override void Set_MyType<T>(T type)
    {
        base.Set_MyType(type);
        if (type is Defines.MenuSubPanels subType)
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

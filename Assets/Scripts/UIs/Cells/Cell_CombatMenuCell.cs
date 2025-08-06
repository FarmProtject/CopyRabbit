using UnityEngine;

public class Cell_CombatSubCell : Cell_MenuCell
{
    Defines.CombatSubPanels myType;
    public override void Set_MyType<T>(T type)
    {
        base.Set_MyType(type);
        if (type is Defines.CombatSubPanels subType)
        {
            myType = subType;
            Debug.Log(myType);
        }
    }
    public override void Set_PanelType()
    {
        base.Set_PanelType();
        GameManager._instance.Set_SelectStage_Type(myType);
    }
}

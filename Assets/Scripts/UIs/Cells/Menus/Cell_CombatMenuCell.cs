using UnityEngine;
using UnityEngine.EventSystems;
public class Cell_CombatSubCell : Cell_MenuCell
{
    [SerializeField]Defines.DungeonType myType;


    protected override void OnClickEvent(PointerEventData evt)
    {
        base.OnClickEvent(evt);
        Set_PanelType();
    }

    public override void Set_MyType<T>(T type)
    {
        base.Set_MyType(type);
        if (type is Defines.DungeonType subType)
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

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_PortalRightCell : UI_StageButton
{
    TextMeshProUGUI titleText;
    TextMeshProUGUI combatText;

    public override void Init(string id)
    {
        base.Init(id);
        if(titleText == null)
        {
            titleText = transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        }
        if(combatText == null)
        {
            combatText = transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>();
        }


        //titleText.text =
        //combatText.text = 
    }
}

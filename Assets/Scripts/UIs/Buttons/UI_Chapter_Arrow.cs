using UnityEngine;
using UnityEngine.EventSystems;
public class UI_Chapter_Arrow : MonoBehaviour
{

    string chapterKey;

    GameObject rightButton;
    GameObject leftButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightButton.AddUIEvent(OnClick_RightButton, Defines.UIEvents.Click);
        leftButton.AddUIEvent(OnClick_LeftButton, Defines.UIEvents.Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick_RightButton(PointerEventData evt)
    {

        if(chapterKey !=null || chapterKey != "null")
        {

        }
    
    }

    void OnClick_LeftButton(PointerEventData evt)
    {

    }
}

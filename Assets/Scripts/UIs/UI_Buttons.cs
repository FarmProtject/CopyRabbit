using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;
public class UI_Buttons : UI_Base
{
    enum Buttons
    {
        TestButton
    }

    enum Texts
    {
        TestText
    }

    enum GameObjects
    {
        TextObj
    }

    enum Images
    {
        TestImage
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
    }


    public void OnButtonClick()
    {
        
    }
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UI_StringManager:MonoBehaviour
{
    Dictionary<string, StringKeyDatas> stringKeyData = new Dictionary<string, StringKeyDatas>();
    [SerializeField] Defines.Language language;

    List<UI_StringController> uI_StringControllers = new List<UI_StringController>();

}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UI_StringManager:MonoBehaviour
{
    Dictionary<string, StringKey> stringKeyData = new Dictionary<string, StringKey>();
    Dictionary<Defines.Language, Dictionary<string, string>> stringDatas = new Dictionary<Defines.Language, Dictionary<string, string>>();
    [SerializeField] Defines.Language language = Defines.Language.Kr;
    List<StringKey> stringKeys = new List<StringKey>();
    

    public void All_Update()
    {

    }

    public void Add_StringKey(StringKey target)
    {
        if (!stringKeys.Contains(target))
        {
            stringKeys.Add(target);
        }
    }

    public string Get_StringData(string key)
    {

        if (!stringDatas.ContainsKey(language))
        {
            Debug.Log($"Didn't Contain language Key");
            return key;
        }
        if (!stringDatas[language].ContainsKey(key))
        {
            Debug.Log("Didn't Contain Key");
            return key;
        }

        return stringDatas[language][key];

    }
}

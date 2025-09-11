using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UI_StringManager : MonoBehaviour
{

    Dictionary<string, Dictionary<string, string>> stringDatas;
    [SerializeField] Defines.Language language = Defines.Language.Kr;
    List<StringKey> stringKeys = new List<StringKey>();

    private void Start()
    {
        InitDatas();
    }
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

        if (!stringDatas.ContainsKey(key))
        {
            Debug.Log($"Didn't Contain  Key");
            return key;
        }
        if (!stringDatas[key].ContainsKey(language.ToString()))
        {
            Debug.Log("Didn't Contain LanguageKey");
            return key;
        }

        return stringDatas[key][language.ToString()];

    }

    void InitDatas()
    {

        stringDatas = GameManager._instance.Get_StringDatas();

        Debug.Log(11);
        foreach (var key in stringDatas.Keys)
        {
            foreach (var type in stringDatas)
            {
                Debug.Log($"Å° : {key} Å¸ÀÔ :{type} ¹ë·ù :");
            }
        }
    }

}

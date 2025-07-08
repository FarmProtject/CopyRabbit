using UnityEngine;
using System;
using System.Collections.Generic;

public class StringKeyDatas
{
    public Dictionary<string, string> datas = new Dictionary<string, string>();
}
public class DataManager:MonoBehaviour
{

    string dataPath;

    CSVReader csvReader = new CSVReader();

    Monster_DataManager data_Monster = new Monster_DataManager();

    Stage_DataManager data_Stage = new Stage_DataManager();

    Item_DataManager data_Item = new Item_DataManager();

    Dictionary<string, Dictionary<string, string>> monsterData = new Dictionary<string, Dictionary<string, string>>();

    private void Awake()
    {
        OnAwake();
        
    }

    private void OnAwake()
    {
        ReadData("Stage", data_Stage.Get_StageDatas());
        DebugDictionary(data_Stage.Get_StageDatas());
    }
    void DebugDictionary(Dictionary<string,Dictionary<string,string>>data )
    {
        foreach(string id in data.Keys)
        {
            foreach(string key in data[id].Keys)
            {
                Debug.Log($"id : {id} key : {key} value {data[id][key]}");

            }



        }

    }
    public Dictionary<string, Dictionary<string, string>> Get_StageDatas()
    {
        return data_Stage.Get_StageDatas();
    }
    public bool TrySetValue<T>(Dictionary<string, object> data, string key, ref T target)
    {
        if (data.ContainsKey(key) && data[key] != null)
        {
            try
            {
                target = (T)Convert.ChangeType(data[key], typeof(T));
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to convert{key}: {ex.Message}");
                return false;
            }
        }
        return false;
    }
    public void ReadData(string path, Dictionary<string,Dictionary<string,string>> target)
    {
         List<Dictionary<string, object>> temp = csvReader.Read(path);
        for(int i = 0; i < temp.Count; i++)
        {
            string id = temp[i]["id"].ToString();

            foreach (var key in temp[i].Keys)
            {
                if (!target.ContainsKey(id))
                {
                    Dictionary<string, string> newData = new Dictionary<string, string>();
                    newData.Add(key, temp[i][key].ToString());
                    target.Add(id, newData);
                }
                else
                {
                    target[id].Add(key,temp[i][key].ToString());

                }
            }
        }
    }

    void LoadMulti(string path, Dictionary<string, List<StringKeyDatas>> newData)
    {
        List<Dictionary<string, string>> tempList = csvReader.ReadToString(path);

        // 그룹ID를 인덱스로 가지는 데이터 리스트
        for (int i = 0; i < tempList.Count; i++)
        {
            List<StringKeyDatas> datas = new List<StringKeyDatas>();

            Dictionary<string, string> temp = tempList[i];

            string index = null;

            
            if (temp.ContainsKey("groupId"))
            {
                index = temp["groupId"].ToString();
                StringKeyDatas keyData = new StringKeyDatas();
                keyData.datas = temp;
                if(index == null)
                {
                    Debug.Log("Index is Null");
                }
                if (newData.ContainsKey(index))
                {
                    newData[index].Add(keyData);
                }
                else
                {
                    List<StringKeyDatas> dataList = new List<StringKeyDatas>();
                    dataList.Add(keyData);
                    newData.Add(index, dataList);
                }
            }
            else if (temp.ContainsKey("id"))
            {
                index = temp["groupId"].ToString();
                if (index == null)
                {
                    Debug.Log("Index is Null");
                }
                StringKeyDatas keyData = new StringKeyDatas();
                keyData.datas = temp;
                if (newData.ContainsKey(index))
                {
                    newData[index].Add(keyData);
                }
                else
                {
                    List<StringKeyDatas> dataList = new List<StringKeyDatas>();
                    dataList.Add(keyData);
                    newData.Add(index, dataList);
                }

            }
        }
    }

}

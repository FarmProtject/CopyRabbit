using UnityEngine;
using System;
using System.Collections.Generic;
public class ObjectPool
{

    Dictionary<string, Queue<GameObject>> inactivePool = new Dictionary<string, Queue<GameObject>>();
    Dictionary<string, List<GameObject>> activePool = new Dictionary<string, List<GameObject>>();

    List<string> id_List = new List<string>();
    List<string> inactiveIds = new List<string>();

    public ObjectPool()
    {
        if (inactiveIds == null)
        {
            inactivePool = new Dictionary<string, Queue<GameObject>>();
        }
        if (activePool == null)
        {
            activePool = new Dictionary<string, List<GameObject>>();
        }
    }
    
    public void Add_To_Inactive(string key, GameObject go)
    {
        

        if (inactivePool.ContainsKey(key))
        {
            if (!inactivePool[key].Contains(go))
            {
                inactivePool[key].Enqueue(go);
                go.SetActive(false);
            }
            

        }
        else
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            queue.Enqueue(go);
            inactivePool.Add(key, queue);
            go.SetActive(false);
        }
        if (!inactiveIds.Contains(key))
        {
            inactiveIds.Add(key);
        }
        if (activePool.ContainsKey(key))
        {
            if (activePool[key].Contains(go))
            {
                activePool[key].Remove(go);
            }
        }
        //Debug.Log($" Monster Key : {key } MonsterName {go.name} Pool Count {inactivePool[key].Count}");
    }

    public void Init()
    {
        List<MonsterEntity> list = GameManager._instance.Get_MonsterList();
        for (int i = 0; i < list.Count; i++)
        {
            string id = list[i].Get_MyId();
            if (!inactivePool[id].Contains(list[i].gameObject))
            {

            }
        }
    }
    public GameObject Get(string key)
    {
        GameObject go;
        if(key == null)
        {
            Debug.Log(null);
        }
        
        if (inactivePool.Count > 0)
        {
            go = inactivePool[key].Dequeue();
        }
        else
        {
            go = CreatNewObj(key);
        }
        if (activePool.ContainsKey(key))
        {
            if (!activePool[key].Contains(go))
            {
                activePool[key].Add(go);
            }
            
        }
        else
        {
            List<GameObject> newList = new();
            newList.Add(go);
            activePool.Add(key, newList);
        }
        go.SetActive(true);
        //activePool[key].Add(go);
        Change_ActiveIDList(key);
        return go;
    }

    public int GetActiveCount()
    {
        int count = 0;

        foreach (string key in activePool.Keys)
        {
            count += activePool[key].Count;
            
        }
        Debug.Log($"ActiveCount : {count}");
        return count;
    }

    public void Set_IDList(List<string> newId)
    {
        id_List = newId;
    }

    void Set_NewID(List<string> newids)
    {
        id_List = newids;

        List<GameObject> goList = new List<GameObject>();

        Inactive_All();

        foreach (var queue in inactivePool.Values)
        {
            goList.AddRange(queue);
        }
        activePool.Clear();
        inactivePool.Clear();

        foreach (string key in id_List)
        {
            inactivePool[key] = new Queue<GameObject>();
            activePool[key] = new List<GameObject>();
        }
        
        for (int i = 0; i < goList.Count; i++)
        {
            string key = id_List[i % id_List.Count];
            inactivePool[key].Enqueue(goList[i]);
        }
    }


    public void Return(string key, GameObject go)
    {
        go.SetActive(false);
        activePool[key].Remove(go);
        inactivePool[key].Enqueue(go);
        Change_ActiveIDList(key);
    }

    public void Inactive_All()
    {
        foreach (string key in activePool.Keys)
        {
            foreach (GameObject go in activePool[key])
            {
                Return(key, go);
            }
        }
        inactiveIds.Clear();
    }

    void Change_ActiveIDList(string id)
    {
        if (inactivePool[id].Count == 0)
        {
            inactiveIds.Remove(id);
        }
        else if (!inactiveIds.Contains(id))
        {
            inactiveIds.Add(id);
        }
    }
    GameObject CreatNewObj(string key)
    {
        Debug.Log("Need to Write CreateNewObj Massod in ObjectPool Script ");
        GameObject go = new GameObject();
        return go;
    }
    public string Get_Random_Gen()
    {
        string id = Get_Random_InactiveId();
        if(id == null)
        {
            Debug.Log("No Inactive Objs Can't Get inactiveId in 'ObjectPool' Script 'Get_Random_Gen' Messod");
            return null;
        }
        if (inactivePool.ContainsKey(id))
        {
            return id;
        }
        else
        {
            Debug.Log("Inactive Pool Didn't Got Inactive Id, ID Error! In 'ObjectPool' Script 'Get_Random_Gen' Messod");
            return null;
        }
    }
    
    public string Get_Random_InactiveId()
    {

        if (inactiveIds.Count > 1)
        {
            int index = UnityEngine.Random.Range(0, inactiveIds.Count);
            Debug.Log($"index : {index}");
            string id = inactiveIds[index];
            return id;
        }
        else
        {
            Debug.Log("Inactive null!!");
            return null;
        }
    }
}

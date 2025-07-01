using UnityEngine;
using System;
using System.Collections.Generic;
public class ObjectPool 
{
    Dictionary<string, Queue<GameObject>> inactivePool = new Dictionary<string, Queue<GameObject>>();
    Dictionary<string, List<GameObject>> activePool = new Dictionary<string, List<GameObject>>();
    List<string> id_List = new List<string>();

    public GameObject Get(string key)
    {
        GameObject go;

        if (inactivePool.Count > 0)
        {
            go = inactivePool[key].Dequeue();
        }
        else
        {
            go = CreatNewObj(key);
        }
        go.SetActive(true);
        activePool[key].Add(go);

        return go;
    }

    public int GetActiveCount()
    {
        int count = 0;

        foreach(string key in activePool.Keys)
        {
            count += activePool[key].Count;
        }

        return count;
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
    }

    public void Inactive_All()
    {
        foreach(string key in activePool.Keys)
        {
            foreach(GameObject go in activePool[key])
            {
                Return(key,go);
            }
        }
    }
    GameObject CreatNewObj(string key)
    {
        Debug.Log("Need to Write CreateNewObj Massod in ObjectPool Script ");
        GameObject go = new GameObject();
        return go;
    }
}

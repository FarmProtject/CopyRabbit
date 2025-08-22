using UnityEngine;
using System;
using System.Collections.Generic;
public class PoolManager
{
    [SerializeField] int maxMonsterCount = 63;
    [SerializeField] int nowCount;

    GameObject monsterPrefab;

    Dictionary<string, Queue<GameObject>> inactivePool = new Dictionary<string, Queue<GameObject>>(); // key : id
    Dictionary<string, List<GameObject>> activePool = new Dictionary<string, List<GameObject>>();

    List<string> id_List = new List<string>();
    List<string> inactiveIds = new List<string>();

    public PoolManager()
    {
        if (inactiveIds == null)
        {
            inactivePool = new Dictionary<string, Queue<GameObject>>();
        }
        if (activePool == null)
        {
            activePool = new Dictionary<string, List<GameObject>>();
        }
        /*
        if(monsterPrefab == null)
        {
            monsterPrefab = GameManager._instance.Get_MonsterPrefab();
        }*/
    }

    public void InitPool()
    {

    }
    public Dictionary<string, Queue<GameObject>> Get_InactivePool()
    {
        return inactivePool;
    }
    public Dictionary<string, List<GameObject>> Get_ActivePool()
    {
        return activePool;
    }
    public List<string> Get_InactiveIds()
    {
        return inactiveIds;
    }
    public void Add_Inactive(string key, GameObject go)
    {
        if (activePool.ContainsKey(key))
        {
            activePool[key].Remove(go);
        }
        if (inactivePool.ContainsKey(key))
        {
            inactivePool[key].Enqueue(go);
        }
        else
        {
            inactivePool.Add(key, new Queue<GameObject>());
            inactivePool[key].Enqueue(go);
        }
        if (!inactiveIds.Contains(key))
        {
            inactiveIds.Add(key);
        }
    }
    public void Add_Active(string key, GameObject go)
    {
        if (inactivePool.ContainsKey(key))
        {
            if (inactivePool[key].Contains(go))
            {
                if (activePool.ContainsKey(key))
                {
                    activePool[key].Add(go);
                }
                else
                {
                    activePool.Add(key, new List<GameObject>());
                    activePool[key].Add(go);
                }
            }
        }
        else
        {
            Debug.Log($"Don't Contain Key {key}");
        }
    }


    public void Gen_Monster(string key)
    {
        int genCount = 0;
        nowCount = GetActiveCount();
        genCount = maxMonsterCount - nowCount;
        if (genCount<0)
        {
            genCount = 0;
        }
        //Debug.Log($"genCount : {genCount}");
        List<StageField> fieldList = GameManager._instance.Get_StageList();
        Debug.Log($"field List Count :   {fieldList.Count}");

        while (genCount > 0)
        {
            int index = UnityEngine.Random.Range(0, fieldList.Count);
            Debug.Log($"index : {index}");
            genCount    = fieldList[index].Gen_Monster(genCount);
            Debug.Log($"genCount : {genCount}");
            fieldList.RemoveAt(index);
        }
    }


    public void Change_NewIds(List<string> ids)
    {
        Set_NewID(ids);
    }

    public GameObject Get_Monster(string key)
    {
        return Get(key);
    }


    #region objectPooling

    public void Inactive_Obj(string key, GameObject go)
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
        /*
        List<MonsterEntity> list = new List<MonsterEntity>();
        for (int i = 0; i < GameManager._instance.Get_MonsterList().Count; i++)
        {
            MonsterEntity entity = GameManager._instance.Get_MonsterList()[i].transform.GetComponent<MonsterEntity>();
            list.Add(entity);
        }
        // = GameManager._instance.Get_MonsterList();
        for (int i = 0; i < list.Count; i++)
        {
            string id = list[i].Get_MyId();
            if (!inactivePool[id].Contains(list[i].gameObject))
            {

            }
        }*/
    }
    public GameObject Get(string key)
    {
        GameObject go;
        if (key == null)
        {
            Debug.Log(null);
        }

        if (inactivePool[key].Count > 0)
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

    public void Set_NewID(List<string> newids)
    {
        id_List = newids;
        Debug.Log("Set_NewID");
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
        Debug.Log("Inactive All");
        foreach (string key in activePool.Keys)
        {
            Debug.Log($"Key : {key}, ActivePool : {activePool[key]}");
            foreach (GameObject go in activePool[key])
            {
                Return(key, go);
                Debug.Log($"inactive {key}, name {go.name}");
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

    public void RenewInactive()
    {
        foreach (var key in inactivePool.Keys)
        {
            if (inactivePool[key].Count>0)
            {
                inactiveIds.Add(key);
            }
        }
    }
    GameObject CreatNewObj(string key)
    {
        //GameObject go = new GameObject();
        if(monsterPrefab == null)
        {
            monsterPrefab = GameManager._instance.Get_MonsterPrefab();
        }
        Debug.Log("Need to Write CreateNewObj Massod in ObjectPool Script ");
        GameObject go = UnityEngine.Object.Instantiate(monsterPrefab);
        go.transform.SetParent(GameManager._instance.Get_MonsterSpawner().transform);
        MonsterEntity entity = go.transform.GetComponent<MonsterEntity>();
        MonsterStats stat = GameManager._instance.Get_MonsterStat(key);
        entity.Set_MyID(key);
        entity.Set_MyData(stat);
        return go;
    }
    void Set_MonsterRigid()
    {

    }

    public string Get_Random_InactiveId()
    {
        if (inactiveIds.Count > 1)
        {
            int index = UnityEngine.Random.Range(0, inactiveIds.Count);
            Debug.Log($"index : {index}");
            string id = inactiveIds[index];
            Debug.Log($"id : {inactiveIds[index]}");
            return id;
        }
        else
        {
            Debug.Log("Inactive null!!");
            return null;
        }
    }
    #endregion
}

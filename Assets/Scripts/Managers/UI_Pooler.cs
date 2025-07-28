using UnityEngine;
using System;
using System.Collections.Generic;

public class UI_Pooler : MonoBehaviour
{
    [SerializeField] GameObject cell_IconPrefab;
    [SerializeField] GameObject rewardPanels;
    [SerializeField] GameObject cell_StageButton;
    Dictionary<Defines.UI_PrefabType, GameObject> ui_Prefabs = new Dictionary<Defines.UI_PrefabType, GameObject>();
    Dictionary<Defines.UI_PrefabType, Queue<IPoolUI>> ui_pool = new Dictionary<Defines.UI_PrefabType, Queue<IPoolUI>>();


    private void Awake()
    {
        
    }

    void OnAwake()
    {
        ui_Prefabs.Add(Defines.UI_PrefabType.CellIcon, cell_IconPrefab);
        ui_Prefabs.Add(Defines.UI_PrefabType.RewardPanel, rewardPanels);
        ui_Prefabs.Add(Defines.UI_PrefabType.CellStageButton, cell_StageButton);
    }
    private void Start()
    {
        
    }
    public Dictionary<Defines.UI_PrefabType,Queue<IPoolUI>> Get_Pool()
    {
        return ui_pool;
    }
    public GameObject Get(Defines.UI_PrefabType type)
    {
        if (ui_pool[type].Count > 1)
        {
            IPoolUI poolUI = ui_pool[type].Dequeue();
            GameObject go = poolUI.Get();
            go.SetActive(true);
            return go;
        }
        else
        {
            return CreateNew(type);
        }

    }

    public void Return(Defines.UI_PrefabType type, IPoolUI ui)
    {
        if (!ui_pool[type].Contains(ui))
        {
            ui_pool[type].Enqueue(ui);
        }
    }

    public GameObject CreateNew(Defines.UI_PrefabType type)
    {
        GameObject go = null;
        switch (type)
        {
            case Defines.UI_PrefabType.CellIcon:
                go = Instantiate(cell_IconPrefab);
                break;
                
            default:
                break;
        }
        if(go == null)
        {
            Debug.Log("go is Null in ui_Pooler CreateNew");
            return new GameObject();
        }
        IPoolUI poolUI = go.transform.GetComponent<IPoolUI>();
        
        ui_pool[type].Enqueue(poolUI);
        return go;
    }

}

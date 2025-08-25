using UnityEngine;

public class UI_PoolUI : UI_Base, IPoolUI
{
    protected Defines.UI_PrefabType _prefabType;


    private void OnDisable()
    {
        DisableFunction();
    }
    public virtual void DisableFunction()
    {
        GameManager._instance.Return_PoolUI(_prefabType, this);
    }

    public virtual void EnableFunction()
    {
        throw new System.NotImplementedException();
    }

    public virtual GameObject Get()
    {
        return this.gameObject;
    }

    public virtual void Init()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Return()
    {
        this.gameObject.SetActive(false);
    }
}

using UnityEngine;

public class UI_PoolUI : UI_Base, IPoolUI
{
    public virtual void DisableFunction()
    {
        throw new System.NotImplementedException();
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

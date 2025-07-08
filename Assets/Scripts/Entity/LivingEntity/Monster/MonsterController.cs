using UnityEngine;
using System;
using System.Collections.Generic;
public class MonsterController : MonoBehaviour
{
    MonsterEntity myEntity;
    CircleCollider2D myColl;
    private void Start()
    {
        OnStart();

    }

    void OnStart()
    {
        myEntity = transform.GetComponent<MonsterEntity>();
        myColl = transform.GetComponent<CircleCollider2D>();
    }
}

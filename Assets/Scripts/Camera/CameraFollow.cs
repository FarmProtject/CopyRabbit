using UnityEngine;
using System;
using System.Collections.Generic;
public class CameraFollow : MonoBehaviour
{
    GameObject cameraObject;
    Transform playerTr;

    void OnAwake() 
    {
        playerTr = GameObject.Find("Player").transform;
        cameraObject = transform.gameObject;
    
    }

    private void Awake()
    {
        OnAwake();
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        cameraObject.transform.position = playerTr.position;
    }
}

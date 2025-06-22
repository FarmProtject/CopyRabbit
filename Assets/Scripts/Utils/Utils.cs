using UnityEngine;
using System;
using System.Collections.Generic;
public static class Utils

{

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T compoent = go.GetComponent<T>();
        if (compoent == null)
        {
            compoent = go.AddComponent<T>();
        }
        return compoent;
    }

    public static GameObject FindChild(GameObject go, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, recursive);
        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                T component = transform.GetComponent<T>();
                if (component != null)
                {
                    return component;
                }

            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {

                return component;

            }

        }
        return null;
    }



}

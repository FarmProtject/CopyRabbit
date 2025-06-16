using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UI_Base:MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    

    private void Start()
    {

    }
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
            }
            if (objects[i] == null)
            {
                Debug.Log($"Failed to Bind {names[i]}");
            }
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        return objects[idx] as T;
    }

    protected TextMeshProUGUI GetTMP(int idx) { return Get<TextMeshProUGUI>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }


    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Defines.UIEvents type)
    {
        
        UI_EventController evt = Utils.GetOrAddComponent<UI_EventController>(go);

        switch (type)
        {
            case Defines.UIEvents.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Defines.UIEvents.DragStart:
                evt.OnBegineDragHandler -= action;
                evt.OnBegineDragHandler += action;
                break;
            case Defines.UIEvents.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
            case Defines.UIEvents.DragEnd:
                evt.OnDragEndHanlder -= action;
                evt.OnDragEndHanlder += action;
                break;
            default:
                break;
        }


    }
}

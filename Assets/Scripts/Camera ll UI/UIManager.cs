using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Extensions;

public class UIManager : MonoBehaviour {

	private List<UIItem> _uiItems = new List<UIItem>();

    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponentInChildren<Canvas>();

        foreach (var uiItem in GetComponentsInChildren<UIItem>(true))
        {
            AddExistingUIItem(uiItem);
        }
    }

    public T AddNewUiItem<T>() where T : UIItem
    {
        GameObject newGameObject = new GameObject(typeof(UIItem).Name);
        UIItem spawnedUiItem = AddExistingUIItem(newGameObject.AddComponent<T>());
        Instantiate(newGameObject);
        return (T)spawnedUiItem;
    }

    public UIItem AddExistingUIItem(UIItem uiItem)
    {
        _uiItems.Add(uiItem);
        return uiItem;
    }

    public void RemoveUiItem(UIItem uiItem)
    {
        _uiItems.Remove(uiItem);
        Destroy(uiItem);
    }

    public void ActivateItemWithTypeAndId<T>(int id)
    {
        UIItem itemWithType = GetItemWithTypeAndId<T>(id);

        if (itemWithType != null)
        {
            itemWithType.Activate();
        }
    }

    private UIItem GetItemWithTypeAndId<T>(int id)
    {
        return _uiItems.GetBasesNInterfacesOfType(typeof(T))[id];
    }

    public void DeactivateItemWithTypeAndId<T>(int id)
    {
        UIItem itemWithType = GetItemWithTypeAndId<T>(id);

        if (itemWithType != null)
        {
            itemWithType.Deactivate();
        }
    }

    public void DeactivateItemWithType<T>()
    {
        foreach (var uiItem in _uiItems.GetBasesNInterfacesOfType(typeof(T)))
        {
            uiItem.Deactivate();
        }
    }

    public void DeactivateItemWithType(UIItem uiItem)
    {
        foreach (var item in _uiItems.FindAll(uiItemInList => uiItemInList.GetType() == uiItem.GetType()))
        {
            item.Deactivate();
        }
    }

    public void SendPropertiesToItemWithType<T>(params object[] properties)
    {
        foreach (var uiItem in _uiItems.GetBasesNInterfacesOfType(typeof (T)))
        {
            uiItem.SetProperties(properties);
        }
    }

    public void SendPropertiesToItemWithTypeAndId<T>(int id, params object[] properties)
    {
        GetItemWithTypeAndId<T>(id).SetProperties(properties);
    }
}

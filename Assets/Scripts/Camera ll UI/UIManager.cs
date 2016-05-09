using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Extensions;
using Assets.Scripts.Shop.Merchant;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

	private List<UiItem> _uiItems = new List<UiItem>();

    void Awake()
    {
        foreach (var uiItem in GetComponentsInChildren<UiItem>(true))
        {
            AddExistingUiItem(uiItem);
        }
    }

    public T AddNewUiItem<T>() where T : UiItem
    {
        GameObject newGameObject = new GameObject(typeof(UiItem).Name);
        UiItem spawnedUiItem = AddExistingUiItem(newGameObject.AddComponent<T>());
        Instantiate(newGameObject);
        return (T)spawnedUiItem;
    }

    public UiItem AddExistingUiItem(UiItem uiItem)
    {
        _uiItems.Add(uiItem);
        return uiItem;
    }

    public void RemoveUiItem(UiItem uiItem)
    {
        _uiItems.Remove(uiItem);
        Destroy(uiItem);
    }

    public UiItem ActivateItemWithTypeAndId<T>(int id) where T : UiItem
    {
        UiItem itemWithType = GetItemWithTypeAndId<T>(id);

        if (itemWithType != null)
        {
            itemWithType.Activate();
        }

        return itemWithType;
    }

    public UiItem GetItemWithTypeAndId<T>(int id) where T : UiItem
    {
        return _uiItems.GetBasesNInterfacesOfType(typeof (T)).Find(item => item.UiId == id);
    }

    public List<UiItem> GetItemsWithTypeAndId<T>(int id) where T : UiItem
    {
        return _uiItems.GetBasesNInterfacesOfType(typeof(T)).FindAll(item => item.UiId == id);
    }

    public void DeactivateItemWithTypeAndId<T>(int id) where T : UiItem
    {
        UiItem itemWithType = GetItemWithTypeAndId<T>(id);

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

    public void SelectUiItem(UiItem uiItem)
    {
        EventSystem.current.SetSelectedGameObject(uiItem.gameObject);
    }

    public void SelectUiItemWithTypeAndId<T>(int id) where T : UiItem
    {
        SelectUiItem(GetItemWithTypeAndId<T>(id));
    }

    public List<UiItem> DeactivateItemWithType(UiItem uiItem)
    {
        List<UiItem> deactivatedItems = new List<UiItem>();

        foreach (var item in _uiItems.FindAll(uiItemInList => uiItemInList.GetType() == uiItem.GetType()))
        {
            deactivatedItems.Add(item);
            item.Deactivate();
        }

        return deactivatedItems;
    }

    public void SendPropertiesToItemWithType<T>(params object[] properties)
    {
        foreach (var uiItem in _uiItems.GetBasesNInterfacesOfType(typeof (T)))
        {
            uiItem.SetProperties(properties);
        }
    }

    public void SendPropertiesToItemWithTypeAndId<T>(int id, params object[] properties) where T : UiItem
    {
        GetItemWithTypeAndId<T>(id).SetProperties(properties);
    }
}

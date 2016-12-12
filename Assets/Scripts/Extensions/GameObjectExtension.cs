using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public static class GameObjectExtension
{
    public static GameObject[] FindGameObjectsWithLayer(this GameObject gameObject,string payerName)
    {
         GameObject[] tGameObjectsInScene = Object.FindObjectsOfType<GameObject>();
         List<GameObject> tGameObjectsWithLayer = new List<GameObject>();

         foreach(GameObject tGameObjectInScene in tGameObjectsInScene)
         {

             if (tGameObjectInScene.layer == LayerMask.NameToLayer(payerName))
             {
                 tGameObjectsWithLayer.Add(tGameObjectInScene);
             }
         }       

         return tGameObjectsWithLayer.ToArray();
     }

    public static T AddComponentIfNotExist<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        T component = gameObject.GetComponent<T>();

        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }

        return component;
    }

    // Also sets rect transforms position.
    public static void SetPosition(this GameObject gameObject, Vector3 position)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        if (rectTransform)
        {
            rectTransform.anchoredPosition = position;
        }
        else
        {
            gameObject.transform.position = position;
        }
    }
    
    // Also gets rect transforms position.
    public static Vector3 GetPosition(this GameObject gameObject)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        if (rectTransform)
        {
            return rectTransform.anchoredPosition;
        }

        return gameObject.transform.position;
    }
}

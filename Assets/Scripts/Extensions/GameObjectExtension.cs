using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class GameObjectExtension {



     public static GameObject[] FindGameObjectsWithLayer(this GameObject pGameObject,string pLayerName)
    {
         GameObject[] tGameObjectsInScene = MonoBehaviour.FindObjectsOfType<GameObject>();
         List<GameObject> tGameObjectsWithLayer = new List<GameObject>();

         foreach(GameObject tGameObjectInScene in tGameObjectsInScene)
         {

             if (tGameObjectInScene.layer == LayerMask.NameToLayer(pLayerName))
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
}

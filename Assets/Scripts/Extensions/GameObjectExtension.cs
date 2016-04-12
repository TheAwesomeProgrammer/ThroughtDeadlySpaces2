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

     
   
}

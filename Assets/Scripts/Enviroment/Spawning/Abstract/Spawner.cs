using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Spawner : MonoBehaviour, Spawnerable
{
    public abstract GameObject Spawn(Vector3 spawnPosition);

    protected Vector3 GetObjectsExtens(GameObject spawnObject)
    {
        Collider collider = spawnObject.GetComponent<Collider>();
        Vector3 sizeOfSpawnObject = collider.transform.lossyScale;
        return sizeOfSpawnObject / 2;
    }
}



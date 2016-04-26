using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnTester : MonoBehaviour
{
    public ObjectSpawner ObjectSpawnerToCall;
    public bool SpawnOnStart;
    public bool SpawnOnUpdate;
    public float SpawnDelay = 0;
    public Transform SpawnTransform;

    void Start()
    {
        if (SpawnOnStart)
        {
            Timer.Start(SpawnDelay, gameObject, "Spawn");
        }
    }

    void Spawn()
    {
        ObjectSpawnerToCall.Spawn(SpawnTransform.position);
    }

    void Update()
    {
        if (SpawnOnUpdate)
        {
            Timer.Start(SpawnDelay, gameObject, "Spawn");
        }
    }
}



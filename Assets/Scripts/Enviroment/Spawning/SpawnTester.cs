using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnTester : MonoBehaviour
{
    public Spawner SpawnerToCall;
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
        SpawnerToCall.Spawn(SpawnTransform.position);
    }

    void Update()
    {
        if (SpawnOnUpdate)
        {
            Timer.Start(SpawnDelay, gameObject, "Spawn");
        }
    }
}



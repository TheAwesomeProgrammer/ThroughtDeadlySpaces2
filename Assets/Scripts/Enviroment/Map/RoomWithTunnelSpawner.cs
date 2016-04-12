using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomWithTunnelSpawner : Spawner
{
    private RoomSpawner _roomSpawner;
    private TunnelSpawner _tunnelSpawner;

    void Start()
    {
        _roomSpawner = GetComponent<RoomSpawner>();
        _tunnelSpawner = GetComponent<TunnelSpawner>();
    }

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        GameObject spawnedTunnel = _tunnelSpawner.Spawn(spawnPosition);
        Vector3 roomSpawnPosition = spawnedTunnel.transform.position + new Vector3(GetObjectsExtens(spawnedTunnel).x, 0, 0);
        GameObject spawnedRoom = _roomSpawner.Spawn(roomSpawnPosition);
        return spawnedRoom;
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomWithTunnelObjectSpawner : ObjectSpawner
{
    private RoomObjectSpawner _roomObjectSpawner;
    private TunnelObjectSpawner _tunnelObjectSpawner;

    void Start()
    {
        _roomObjectSpawner = GetComponent<RoomObjectSpawner>();
        _tunnelObjectSpawner = GetComponent<TunnelObjectSpawner>();
    }

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        GameObject spawnedTunnel = _tunnelObjectSpawner.Spawn(spawnPosition);
        Vector3 roomSpawnPosition = spawnedTunnel.transform.position + new Vector3(GetObjectsExtens(spawnedTunnel).x, 0, 0);
        GameObject spawnedRoom = _roomObjectSpawner.Spawn(roomSpawnPosition);
        return spawnedRoom;
    }
}



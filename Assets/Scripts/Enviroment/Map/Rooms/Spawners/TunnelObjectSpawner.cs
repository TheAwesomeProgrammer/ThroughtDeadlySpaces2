using UnityEngine;

public class TunnelObjectSpawner : ObjectSpawner
{
    public GameObject Tunnel;

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        return Instantiate(Tunnel, spawnPosition + GetObjectsExtens(Tunnel), Tunnel.transform.rotation) as GameObject;
    }
}

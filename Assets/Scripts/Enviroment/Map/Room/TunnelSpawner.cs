using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    public GameObject Tunnel;

    public void Spawn(Vector2 spawnPosition)
    {
        Collider tunnelCollider = Tunnel.GetComponent<Collider>();
        Vector2 offset = tunnelCollider.bounds.size / 2;

        Instantiate(Tunnel, spawnPosition + offset, Tunnel.transform.rotation);
    }
}

using System;
using UnityEngine;
public class Room : MonoBehaviour
{
    public event Action MoveToNextRoom;

    public Transform TunnelSpawnPosition;

    private RoomWithTunnelSpawner _roomWithTunnelSpawnerChild;

    void Start()
    {
        _roomWithTunnelSpawnerChild = GetComponentInChildren<RoomWithTunnelSpawner>();
    }

    public void OnMoveToNextRoom()
    {
        if (MoveToNextRoom != null)
        {
            MoveToNextRoom();
        }

        _roomWithTunnelSpawnerChild.Spawn(TunnelSpawnPosition.position);
    }

}

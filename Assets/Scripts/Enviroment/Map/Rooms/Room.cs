using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    public event Action MoveToNextRoom;
    public bool IsPlayerInRoom;

    public Transform TunnelSpawnTransform;
    public Transform RewardSpawnTransform;

    private RoomWithTunnelObjectSpawner _roomWithTunnelObjectSpawnerChild;

    void Start()
    {
        _roomWithTunnelObjectSpawnerChild = GetComponentInChildren<RoomWithTunnelObjectSpawner>();
    }

    public void OnMoveToNextRoom()
    {
        if (MoveToNextRoom != null)
        {
            MoveToNextRoom();
        }

        _roomWithTunnelObjectSpawnerChild.Spawn(TunnelSpawnTransform.position);
    }
}

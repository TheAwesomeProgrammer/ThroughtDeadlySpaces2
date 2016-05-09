using System;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public event Action MoveToNextRoom;
    public bool IsPlayerInRoom;

    public Transform RoomSpawnTransform;

    private RoomObjectSpawner _roomObjectSpawner;

    void Start()
    {
        _roomObjectSpawner = GetComponentInChildren<RoomObjectSpawner>();
    }

    public void OnMoveToNextRoom()
    {
        if (MoveToNextRoom != null)
        {
            MoveToNextRoom();
        }

        _roomObjectSpawner.Spawn(RoomSpawnTransform.position);
    }

    public virtual void OnPlayerJustEnteredRoom()
    {
        
    }

    public virtual void OnJustSpawned()
    {
        
    }
}

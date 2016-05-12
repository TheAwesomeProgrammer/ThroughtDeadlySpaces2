using System;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public event Action MoveToNextRoom;
    public bool IsPlayerInRoom;

    public Transform RoomSpawnTransform;

    private RoomObjectSpawner _roomObjectSpawner;
    private bool _hasSpawnedNextRoom;

    void Start()
    {
        _roomObjectSpawner = GetComponentInChildren<RoomObjectSpawner>();
    }

    public void OnMoveToNextRoom()
    {
        if (!_hasSpawnedNextRoom)
        {
            if (MoveToNextRoom != null)
            {
                MoveToNextRoom();
            }

            _hasSpawnedNextRoom = true;
            _roomObjectSpawner.Spawn(RoomSpawnTransform.position);
        }
        
    }

    public virtual void OnPlayerJustEnteredRoom()
    {
        
    }

    public virtual void OnJustSpawned()
    {
        
    }
}

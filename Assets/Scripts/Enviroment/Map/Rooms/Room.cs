using System;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public event Action<GameObject> MoveToNextRoom;
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
            _hasSpawnedNextRoom = true;
            GameObject roomSpawned = _roomObjectSpawner.Spawn(RoomSpawnTransform.position);

            if (MoveToNextRoom != null)
            {
                MoveToNextRoom(roomSpawned);
            }
        }
    }

    public virtual void OnPlayerJustEnteredRoom()
    {
        
    }

    public virtual void OnJustSpawned()
    {
        
    }
}

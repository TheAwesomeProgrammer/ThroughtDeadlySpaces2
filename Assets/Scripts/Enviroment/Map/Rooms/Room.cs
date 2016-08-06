using System;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public event Action<GameObject> MoveToNextRoom;
    public bool IsPlayerInRoom;

    public Transform RoomSpawnTransform;
    
    public GameObject SpawnedRoomObject { get; set; }

    private RoomObjectSpawner _roomObjectSpawner;
    private bool _hasSpawnedNextRoom;

    protected virtual void Start()
    {
        _roomObjectSpawner = GetComponentInChildren<RoomObjectSpawner>();
    }

    public void OnMoveToNextRoom()
    {
        if (!_hasSpawnedNextRoom)
        {
            _hasSpawnedNextRoom = true;
            SpawnedRoomObject = _roomObjectSpawner.Spawn(RoomSpawnTransform.position);

            if (MoveToNextRoom != null)
            {
                MoveToNextRoom(SpawnedRoomObject);
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

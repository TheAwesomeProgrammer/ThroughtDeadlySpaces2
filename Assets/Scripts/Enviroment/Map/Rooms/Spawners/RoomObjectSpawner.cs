using Assets.Scripts.Enviroment.Map.Rooms;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;
public class RoomObjectSpawner : ObjectSpawner
{
    public GameObject Room;

    private Map _map;

    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Tag.Map).GetComponent<Map>();
    }

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        GameObject roomSpawned =
            Instantiate(Room, spawnPosition, Room.transform.rotation) as GameObject;
        roomSpawned.transform.parent = Room.transform.parent;
        CallSpawnEventOnRoom(roomSpawned);
        return roomSpawned;
    }

    private void CallSpawnEventOnRoom(GameObject roomSpawned)
    {
        Room room = roomSpawned.GetComponent<Room>();
        room.transform.parent = _map.transform;
        room.OnJustSpawned();
    }
}

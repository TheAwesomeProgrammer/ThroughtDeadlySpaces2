using UnityEngine;
public class RoomObjectSpawner : ObjectSpawner
{
    public GameObject Room;

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
        room.OnJustSpawned();
    }
}

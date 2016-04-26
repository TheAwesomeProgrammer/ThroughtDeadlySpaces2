using UnityEngine;
public class RoomObjectSpawner : ObjectSpawner
{
    public GameObject Room;

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        Vector3 roomExtens = GetObjectsExtens(Room);
        GameObject roomSpawned =
            Instantiate(Room, spawnPosition + new Vector3(roomExtens.x, -roomExtens.y*2, 0), Room.transform.rotation) as GameObject;
        roomSpawned.transform.parent = Room.transform.parent;
        return roomSpawned;
    }
}

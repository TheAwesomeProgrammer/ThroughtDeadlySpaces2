using UnityEngine;
public class RoomSpawner : Spawner
{
    public GameObject Room;

    public override GameObject Spawn(Vector3 spawnPosition)
    {
        Vector3 roomExtens = GetObjectsExtens(Room);
        return Instantiate(Room, spawnPosition + new Vector3(roomExtens.x, -roomExtens.y * 2, 0), Room.transform.rotation) as GameObject;
    }
}

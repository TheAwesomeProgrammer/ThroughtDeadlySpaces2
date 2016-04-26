using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class Map : MonoBehaviour
    {
        public Room GetActiveRoom()
        {
            foreach (var room in GetComponentsInChildren<Room>())
            {
                if (room.IsPlayerInRoom)
                {
                    return room;
                }
            }
            return null;
        }
    }
}
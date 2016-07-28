using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class Map : MonoBehaviour
    {
        public Room LastActiveRoom;

        private const float UpdateRate = 10;

        public void Start()
        {
            InvokeRepeating("UpdateLastActiveRoom", 0.1f, 1f / UpdateRate);
        }

        private void UpdateLastActiveRoom()
        {
            LastActiveRoom =  GetActiveRoom() ?? LastActiveRoom;
        }

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
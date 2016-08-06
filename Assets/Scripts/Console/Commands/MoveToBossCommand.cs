using System;
using Assets.Scripts.Enviroment.Map.Rooms;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;
using Wenzil.Console;

namespace Assets.Scripts.Console.Commands
{
    public class MoveToBossCommand : MonoBehaviour
    {
        private Map _map;

        public void Start()
        {
            _map = GameObject.FindGameObjectWithTag(Tag.Map).GetComponent<Map>();
            ConsoleCommandsDatabase.RegisterCommand("MoveToBoss", MovePlayerToBoss, "Moves player to boss",
                "Move player to boss");
        }

        private string MovePlayerToBoss(params string[] args)
        {
            GameObject player = GameObject.FindGameObjectWithTag(Tag.Player);
            GameObject bossRoom = GetBossRoom();
            player.transform.position = bossRoom.transform.FindChild("PlayerSpawnPoint").position;
            return "Moved player to boss";
        }

        private GameObject GetBossRoom()
        {
            return SpawnBossRoom(_map.GetActiveRoom(), _map.LastActiveRoom);
        }

        private GameObject SpawnBossRoom(Room activeRoom, Room lastActiveRoom)
        {
            if ((IsRoom(activeRoom, typeof(BaseRoom)) || IsRoom(lastActiveRoom, typeof(BaseRoom))) && activeRoom.SpawnedRoomObject != null)
            {
                return activeRoom.SpawnedRoomObject;
            }
            if (IsRoom(activeRoom, typeof(BossRoom)))
            {
                return activeRoom.gameObject;
            }
            if (IsRoom(lastActiveRoom, typeof(BossRoom)))
            {
                BaseRoom baseRoom = lastActiveRoom.SpawnedRoomObject.GetComponent<BaseRoom>();
                baseRoom.OnMoveToNextRoom();
                return baseRoom.SpawnedRoomObject;
            }
            if (IsRoom(activeRoom, typeof(BaseRoom)) && activeRoom.SpawnedRoomObject == null)
            {
                activeRoom.OnMoveToNextRoom();
                return activeRoom.SpawnedRoomObject;
            }
            return null;
        }

        private bool IsRoom(Room room, Type type)
        {
            return room != null && room.GetType() == type;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

public class MoveToNextRoomEventTrigger : EventTrigger
{
    public Room Room;

    protected override void Start()
    {
        base.Start();
        TriggerOnEnter = true;
        Tags.Add(Tag.PlayerCollision);
    }

    protected override void DoEvent()
    {
        Room.OnMoveToNextRoom();
    }
}



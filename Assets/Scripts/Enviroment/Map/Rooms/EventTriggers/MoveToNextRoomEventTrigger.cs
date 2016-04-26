﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveToNextRoomEventTrigger : EventTrigger
{
    public Room Room;

    protected override void Start()
    {
        base.Start();
        TriggerOnEnter = true;
        Tags.Add("Player");
    }

    protected override void DoEvent()
    {
        Room.OnMoveToNextRoom();
    }
}


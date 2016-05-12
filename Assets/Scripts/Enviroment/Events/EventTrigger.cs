using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;

public abstract class EventTrigger : Trigger
{
    public bool TriggerOnEnter { get; set; }
    public bool TriggerOnStay { get; set; }
    public bool TriggerOnExit { get; set; }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        if (TriggerOnEnter)
        {
            DoEvent();
            Debug.Log("Doing event on trigger enter");
        }
    }

    public override void OnStayWithTag()
    {
        base.OnStayWithTag();
        if (TriggerOnStay)
        {
            DoEvent();
            Debug.Log("Doing event on trigger stay");
        }
    }

    public override void OnExitWithTag()
    {
        base.OnExitWithTag();
        if (TriggerOnExit)
        {
            DoEvent();
            Debug.Log("Doing event on trigger exit");
        }
    }

    protected abstract void DoEvent();
}



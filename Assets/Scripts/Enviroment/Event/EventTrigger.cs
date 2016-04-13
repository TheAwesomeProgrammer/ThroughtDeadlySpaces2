using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EventTrigger : TriggerInteractable
{
    public bool TriggerOnEnter;
    public bool TriggerOnStay;
    public bool TriggerOnExit;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Player");
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (TriggerOnEnter)
        {
            DoEvent();
            Debug.Log("Doing event on trigger enter");
        }
    }

    public override void OnStay()
    {
        base.OnStay();
        if (TriggerOnStay)
        {
            DoEvent();
            Debug.Log("Doing event on trigger stay");
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        if (TriggerOnExit)
        {
            DoEvent();
            Debug.Log("Doing event on trigger exit");
        }
    }

    protected abstract void DoEvent();
}



using System;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

public abstract class Door : Trigger
{
    public event Action EnteredDoor;
    public event Action ExitedDoor;
    public bool LockOnStart = true;

    protected bool _locked;
    protected Collider _collisionCollider;

    protected override void Start()
    {
        base.Start();
        _collisionCollider = transform.parent.GetComponent<Collider>();
        if (LockOnStart)
        {
            Lock();
        }
        Tags.Add(Tag.PlayerCollision);
    }

    public void Lock()
    {
        _locked = true;
        _collisionCollider.isTrigger = false;
    }

    public void UnLock()
    {
        _locked = false;
        _collisionCollider.isTrigger = true;
    }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        OnEnteredDoor();
    }

    public override void OnExitWithTag()
    {
        base.OnExitWithTag();
        OnExitedDoor();
    }

    public virtual void OnEnteredDoor()
    {
        if (EnteredDoor != null)
        {
            EnteredDoor();
        }
    }

    public virtual void OnExitedDoor()
    {
        if (ExitedDoor != null)
        {
            ExitedDoor();
        }
    }
}

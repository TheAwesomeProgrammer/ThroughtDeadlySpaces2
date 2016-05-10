using System;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

public abstract class Door : Trigger
{
    public event Action EnteredDoor;
    public event Action ExitedDoor;
    public bool LockOnStart = true;

    protected bool _locked;
    protected GameObject _lockedChild;
    protected GameObject _unLockedChild;

    protected override void Start()
    {
        base.Start();
        _lockedChild = transform.parent.FindChild("Lock").gameObject;
        _unLockedChild = transform.parent.FindChild("UnLock").gameObject;
        if (LockOnStart)
        {
            Lock();
        }
        Tags.Add(Tag.PlayerCollision);
    }

    public void Lock()
    {
        _locked = true;
        _lockedChild.SetActive(true);
        _unLockedChild.SetActive(false);
    }

    public void UnLock()
    {
        _locked = false;
        _lockedChild.SetActive(false);
        _unLockedChild.SetActive(true);
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

using System;
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class CollisionChecking : MonoBehaviour, Collisionable
{
    public List<string> Tags { get; set; }
    public CollisionType CollisionType { get; set; }
    public bool CollisionCheckingWhenDisabled;

    protected UnityEngine.Collision _collisionObject;
    protected Collider _otherCollider;
    protected Collider _myCollider;

    private bool _hasInited;

    protected virtual void Start()
    {
        CollisionType = CollisionType.NoCollision;
        Tags = new List<string>();
        _myCollider = GetComponent<Collider>();
        if (_myCollider.isTrigger)
        {
            _myCollider.isTrigger = false;
            Debug.LogWarning("Setting isTrigger to false, because has CollisionInteractable on it. \n Make sure this is on the right object.");
        }
        _hasInited = true;
    }

    private void ShouldInit()
    {
        if (!_hasInited)
        {
            Start();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ShouldCheck())
        {
            ShouldInit();
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.Enter;
            if (ContainsTag(collision))
            {
                OnEnterWithTag();
            }
            OnEnter();
        }
    }

    private bool ShouldCheck()
    {
        return !enabled && CollisionCheckingWhenDisabled || enabled;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (ShouldCheck())
        {
            ShouldInit();
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.Stay;
            if (ContainsTag(collision))
            {
                OnStayWithTag();
            }
            OnStay();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (ShouldCheck())
        {
            ShouldInit();
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.NoCollision;
            if (ContainsTag(collision))
            {
                OnExitWithTag();
            }
            OnExit();
        }
    }

    private bool ContainsTag(Collision collision)
    {
        return collision != null && collision.collider != null  && Tags.Contains(collision.collider.tag);
    }

    public virtual void OnEnterWithTag(){}

    public virtual void OnStayWithTag(){}

    public virtual void OnExitWithTag(){}

    public virtual void OnEnter() { }

    public virtual void OnStay() { }

    public virtual void OnExit() { }
}

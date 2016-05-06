using System;
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class CollisionChecking : MonoBehaviour, Collisionable
{
    public List<string> Tags { get; set; }
    public CollisionType CollisionType { get; set; }

    protected UnityEngine.Collision _collisionObject;
    protected Collider _otherCollider;
    protected Collider _myCollider;

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
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.Enter;
            OnEnterWithTag();
        }
    }

    void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.Stay;
            OnStayWithTag();
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            _otherCollider = _collisionObject.collider;
            CollisionType = CollisionType.NoCollision;
            OnExitWithTag();
        }
    }

    public virtual void OnEnterWithTag(){}

    public virtual void OnStayWithTag(){}

    public virtual void OnExitWithTag(){}
}

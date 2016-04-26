using System;
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class Collision : MonoBehaviour, Collisionable
{
    public List<string> Tags { get; set; }
    public CollisionType CollisionType { get; set; }

    protected UnityEngine.Collision _collisionObject;
    protected Collider _collider;
    

    protected virtual void Start()
    {
        CollisionType = CollisionType.NoCollision;
        Tags = new List<string>();
        _collider = GetComponent<Collider>();
        if (_collider.isTrigger)
        {
            _collider.isTrigger = false;
            Debug.LogWarning("Setting isTrigger to false, because has CollisionInteractable on it. \n Make sure this is on the right object.");
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            CollisionType = CollisionType.Enter;
            OnEnter();
        }
    }

    void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            CollisionType = CollisionType.Stay;
            OnStay();
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            CollisionType = CollisionType.NoCollision;
            OnExit();
        }
    }

    public virtual void OnEnter(){}

    public virtual void OnStay(){}

    public virtual void OnExit(){}
}

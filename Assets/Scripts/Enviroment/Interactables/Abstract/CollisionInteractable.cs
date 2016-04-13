using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class CollisionInteractable : MonoBehaviour, Interactable
{
    public List<string> Tags { get; set; }

    protected Collision _collisionObject;
    protected Collider _collider;

    protected virtual void Start()
    {
        Tags = new List<string>();
        _collider = GetComponent<Collider>();
        if (_collider.isTrigger)
        {
            _collider.isTrigger = false;
            Debug.LogWarning("Setting isTrigger to false, because has CollisionInteractable on it. \n Make sure this is on the right object.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            OnEnter();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            OnStay();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            _collisionObject = collision;
            OnExit();
        }
    }

    public virtual void OnEnter(){}

    public virtual void OnStay(){}

    public virtual void OnExit(){}
}

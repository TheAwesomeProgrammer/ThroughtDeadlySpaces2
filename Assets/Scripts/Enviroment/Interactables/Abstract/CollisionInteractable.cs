using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public abstract class CollisionInteractable : MonoBehaviour, Interactable
{
    public List<string> Tags { get; set; }

    protected Collision _otherCollision;

    protected virtual void Start()
    {
        Tags = new List<string>();
        if (GetComponent<Collider>().isTrigger)
        {
            GetComponent<Collider>().isTrigger = false;
            Debug.LogWarning("Setting isTrigger to false, because has CollisionInteractable on it. \n Make sure this is on the right object.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            OnEnter(collision);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            OnStay(collision);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (Tags.Contains(collision.collider.tag))
        {
            OnExit(collision);
        }
    }

    public virtual void OnEnter(object otherCollisionObject)
    {
        _otherCollision = otherCollisionObject as Collision;
    }

    public virtual void OnStay(object otherCollisionObject)
    {
        _otherCollision = otherCollisionObject as Collision;
    }

    public virtual void OnExit(object otherCollisionObject)
    {
        _otherCollision = otherCollisionObject as Collision;
    }
}

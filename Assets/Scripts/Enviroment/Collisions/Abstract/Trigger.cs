
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public abstract class Trigger : MonoBehaviour, Collisionable
{
    public List<string> Tags { get; set; }
    public CollisionType CollisionType { get; set; }

    protected Collider _triggerCollider;
    protected Collider _collider;

    protected virtual void Start()
    {
        Tags = new List<string>();
        CollisionType = CollisionType.NoCollision;
        _collider = GetComponent<Collider>();
        if (!_collider.isTrigger)
        {
            _collider.isTrigger = true;
            Debug.LogWarning("Setting isTrigger to true, because has TriggerInteractable on it. \n Make sure this is on the right object.");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        CollisionType = CollisionType.Enter;
        _triggerCollider = collider;
        if (Tags.Contains(collider.tag))
        {
            OnEnterWithTag();
        }
        OnEnter();
    }

    void OnTriggerStay(Collider collider)
    {
        _triggerCollider = collider;
        CollisionType = CollisionType.Stay;
        if (Tags.Contains(collider.tag))
        {
            OnStayWithTag();
        }
        OnStay();
    }

    void OnTriggerExit(Collider collider)
    {
        CollisionType = CollisionType.NoCollision;
        _triggerCollider = collider;
        if (Tags.Contains(collider.tag))
        {
            OnExitWithTag();
        }
        OnExit();
    }

    public virtual void OnEnterWithTag(){}

    public virtual void OnStayWithTag(){}

    public virtual void OnExitWithTag(){}

    public virtual void OnEnter() { }

    public virtual void OnStay() { }

    public virtual void OnExit() { }
}

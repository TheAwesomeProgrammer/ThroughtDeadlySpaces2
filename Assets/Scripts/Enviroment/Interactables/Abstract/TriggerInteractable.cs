
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public abstract class TriggerInteractable : MonoBehaviour, Interactable
{
    public List<string> Tags { get; set; }

    protected Collider _otherCollider;

    protected virtual void Start()
    {
        Tags = new List<string>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            OnEnter(collider);
        }
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            OnStay(collider);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            OnExit(collider);
        }
    }

    public virtual void OnEnter(object otherCollisionObject)
    {
        _otherCollider = otherCollisionObject as Collider;
    }

    public virtual void OnStay(object otherCollisionObject)
    {
        _otherCollider = otherCollisionObject as Collider;
    }

    public virtual void OnExit(object otherCollisionObject)
    {
        _otherCollider = otherCollisionObject as Collider;
    }
}

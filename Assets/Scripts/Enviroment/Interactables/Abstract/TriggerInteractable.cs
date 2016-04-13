
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public abstract class TriggerInteractable : MonoBehaviour, Interactable
{
    public List<string> Tags { get; set; }

    protected Collider _triggerCollider;
    protected Collider _collider;

    protected virtual void Start()
    {
        Tags = new List<string>();
        _collider = GetComponent<Collider>();
        if (!_collider.isTrigger)
        {
            _collider.isTrigger = true;
            Debug.LogWarning("Setting isTrigger to true, because has TriggerInteractable on it. \n Make sure this is on the right object.");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            _triggerCollider = collider;
            OnEnter();
        }
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            _triggerCollider = collider;
            OnStay();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (Tags.Contains(collider.tag))
        {
            _triggerCollider = collider;
            OnExit();
        }
    }

    public virtual void OnEnter(){}

    public virtual void OnStay(){}

    public virtual void OnExit(){}
}

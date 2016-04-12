using UnityEngine;

public class TriggerDebugObject : TriggerInteractable
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnter(object otherCollisionObject)
    {
        base.OnEnter(otherCollisionObject);
        Debug.Log("Entering trigger. Object : "+_otherCollider);
    }

    public override void OnStay(object otherCollisionObject)
    {
        base.OnStay(otherCollisionObject);
        Debug.Log("Staying in trigger. Object : " + _otherCollider);
    }

    public override void OnExit(object otherCollisionObject)
    {
        base.OnExit(otherCollisionObject);
        Debug.Log("Exiting trigger. Object : " + _otherCollider);
    }
}

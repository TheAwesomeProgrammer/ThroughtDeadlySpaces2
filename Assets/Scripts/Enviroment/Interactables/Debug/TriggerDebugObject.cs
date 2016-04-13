using UnityEngine;

public class TriggerDebugObject : TriggerInteractable
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entering trigger. Object : "+_triggerCollider);
    }

    public override void OnStay()
    {
        base.OnStay();
        Debug.Log("Staying in trigger. Object : " + _triggerCollider);
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exiting trigger. Object : " + _triggerCollider);
    }
}

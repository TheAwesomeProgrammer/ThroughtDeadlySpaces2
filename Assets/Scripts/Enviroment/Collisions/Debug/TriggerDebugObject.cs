using UnityEngine;

public class TriggerDebugObject : Trigger
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        Debug.Log("Entering trigger. Object : "+_triggerCollider);
    }

    public override void OnStayWithTag()
    {
        base.OnStayWithTag();
        Debug.Log("Staying in trigger. Object : " + _triggerCollider);
    }

    public override void OnExitWithTag()
    {
        base.OnExitWithTag();
        Debug.Log("Exiting trigger. Object : " + _triggerCollider);
    }
}

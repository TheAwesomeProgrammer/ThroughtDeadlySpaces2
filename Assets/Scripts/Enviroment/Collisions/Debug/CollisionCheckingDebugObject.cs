using UnityEngine;

public class CollisionCheckingDebugObject : CollisionChecking
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        Debug.Log("Entering collision. Collision : "+ _collisionObject);
    }

    public override void OnStayWithTag()
    {
        base.OnStayWithTag();
        Debug.Log("Staying in collision. Collision : " + _collisionObject);
    }

    public override void OnExitWithTag()
    {
        base.OnExitWithTag();
        Debug.Log("Exiting collision. Collision : " + _collisionObject);
    }
}

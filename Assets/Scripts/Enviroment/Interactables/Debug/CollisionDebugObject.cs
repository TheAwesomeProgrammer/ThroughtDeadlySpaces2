using UnityEngine;

public class CollisionDebugObject : CollisionInteractable
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entering collision. Collision : "+ _collisionObject);
    }

    public override void OnStay()
    {
        base.OnStay();
        Debug.Log("Staying in collision. Collision : " + _collisionObject);
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exiting collision. Collision : " + _collisionObject);
    }
}

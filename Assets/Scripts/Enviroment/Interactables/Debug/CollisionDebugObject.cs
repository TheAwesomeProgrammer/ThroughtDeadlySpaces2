using UnityEngine;

public class CollisionDebugObject : CollisionInteractable
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnter(object otherCollisionObject)
    {
        base.OnEnter(otherCollisionObject);
        Debug.Log("Entering collision. Collision : "+otherCollisionObject);
    }

    public override void OnStay(object otherCollisionObject)
    {
        base.OnStay(otherCollisionObject);
        Debug.Log("Staying in collision. Collision : " + otherCollisionObject);
    }

    public override void OnExit(object otherCollisionObject)
    {
        base.OnExit(otherCollisionObject);
        Debug.Log("Exiting collision. Collision : " + otherCollisionObject);
    }
}

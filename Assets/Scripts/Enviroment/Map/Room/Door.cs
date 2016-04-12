public class Door : TriggerInteractable
{
    protected override void Start()
    {
        base.Start();
        Tags.Add("Player");
    }

    public override void OnEnter(object otherCollisionObject)
    {
        base.OnEnter(otherCollisionObject);

    }
}

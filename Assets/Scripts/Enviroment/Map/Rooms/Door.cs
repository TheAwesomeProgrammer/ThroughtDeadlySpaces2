using System;

public class Door : Trigger
{
    public event Action EnteredDoor;
    public event Action ExitedDoor;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Player");
    }

    public void OnEnteredDoor()
    {
        if (EnteredDoor != null)
        {
            EnteredDoor();
        }
    }

    public void OnExitedDoor()
    {
        if (ExitedDoor != null)
        {
            ExitedDoor();
        }
    }
}

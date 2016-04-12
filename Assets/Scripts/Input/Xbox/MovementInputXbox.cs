
using System.Collections.Generic;
using UnityEngine;

public class MovementInputXbox : MovementInput
{
    public XboxControl ThumpStick;

    private XboxControls _instance;

    void Start()
    {
        _instance = XboxControls.instance;
    }

    public override void UpdateInput()
    {
        Vector2 moveDirection = _instance.ThumbStick(ThumpStick, 0);

        if (moveDirection != Vector2.zero)
        {
            OnInputPressed(new Vector3(moveDirection.x, 0, moveDirection.y));
        }
        }
}

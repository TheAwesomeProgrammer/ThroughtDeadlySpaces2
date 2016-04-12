using System;
using UnityEngine;

public abstract class MovementInput : MonoBehaviour
{
    public event Action<Vector3> InputPressed;
    public event Action<Vector3> InputPressedDown;

    protected virtual void OnInputPressed(Vector3 direction)
    {
        if (InputPressed != null)
        {
            InputPressed(direction);
        }
    }

    protected virtual void OnInputPressedDown(Vector3 direction)
    {
        if (InputPressedDown != null)
        {
            InputPressedDown(direction);
        }
    }

    public virtual void Update()
    {
        UpdateInput();
    }

    public abstract void UpdateInput();

}

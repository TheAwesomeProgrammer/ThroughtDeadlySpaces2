using System;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputPc : MovementInput
{
    public List<InputInfoPc> InputInfos;

    public override void UpdateInput()
    {
        foreach (var inputInfo in InputInfos)
        {
            if (Input.GetButtonDown(inputInfo.ButtonName))
            {
                OnInputPressedDown(inputInfo.Direction);
            }
            if (Input.GetButton(inputInfo.ButtonName))
            {
                OnInputPressed(inputInfo.Direction);
            }
        }
    }
}

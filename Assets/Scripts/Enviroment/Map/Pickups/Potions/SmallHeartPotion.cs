using System;
using UnityEngine;
using UnityTest;

public class SmallHeartPotion : TriggerInteractable
{
    public int HealthToGive = 2;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Life life = _triggerCollider.GetComponent<Life>();
        life.Health += HealthToGive;
        Destroy(gameObject);
    }
}
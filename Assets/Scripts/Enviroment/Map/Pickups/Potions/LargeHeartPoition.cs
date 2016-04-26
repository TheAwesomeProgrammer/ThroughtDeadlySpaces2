using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class LargeHeartPoition : Trigger
    {
        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Life life = _triggerCollider.GetComponent<Life>();
            life.Health = life.MaxHealth;
        }
    }
}
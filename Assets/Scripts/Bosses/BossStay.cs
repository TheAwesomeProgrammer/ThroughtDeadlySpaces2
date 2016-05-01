using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses
{
    public class BossStay : CollisionChecking
    {
        private Rigidbody _rigidbody;

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody>();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _rigidbody.isKinematic = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            _rigidbody.isKinematic = false;
        }
    }
}
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
            Tags.Add(Tag.PlayerCollision);
        }

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            _rigidbody.isKinematic = true;
        }

        public override void OnExitWithTag()
        {
            base.OnExitWithTag();
            _rigidbody.isKinematic = false;
        }
    }
}
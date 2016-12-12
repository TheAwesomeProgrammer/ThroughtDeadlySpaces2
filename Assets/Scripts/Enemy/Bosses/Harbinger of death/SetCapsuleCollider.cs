using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class SetCapsuleCollider : MonoBehaviour
    {
        private CapsuleCollider _capsuleCollider;
        private Transform _player;

        public void Start()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _player = GameObject.FindWithTag(Tag.PlayerCollision).transform;
        }

        public void TargetPlayer()
        {
            transform.LookAt(_player);
            transform.Rotate(new Vector3(0, 0, -90));
            SetHeight();
            SetCenter();
        }

        void SetHeight()
        {
            _capsuleCollider.height = DirectionToPlayer().magnitude;
        }

        void SetCenter()
        {
            _capsuleCollider.center = new Vector3(0, 0, _capsuleCollider.height / 2);
        }

        private Vector3 DirectionToPlayer()
        {
            return (_player.position - transform.position);
        }
    }
}
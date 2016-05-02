using Assets.Scripts.Player.Swords;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        private Life _life;
        private AnimatorTrigger _animatorTrigger;
        private PlayerMovement _playerMovement;
        private Rigidbody _collisionRigidbody;

        void Start()
        {
            _life = GetComponentInParent<Life>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _playerMovement = GetComponentInParent<PlayerMovement>();
            _collisionRigidbody = GetComponentInParent<Rigidbody>();
            _life.Death += OnDeath;
            _animatorTrigger.AnimationEnded += OnDeathAnimationEnd;
        }

        void OnDeath()
        {
            _animatorTrigger.StartAnimation();
            _playerMovement.CanMove = false;
            _collisionRigidbody.isKinematic = false;
            _collisionRigidbody.useGravity = false;
            _collisionRigidbody.velocity = Vector3.zero;
        }

        void OnDeathAnimationEnd()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
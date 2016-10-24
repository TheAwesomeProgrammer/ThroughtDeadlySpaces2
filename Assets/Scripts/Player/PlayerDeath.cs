using Assets.Scripts.Player.Swords;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        private Life _life;
        private AnimatorTrigger _animatorTrigger;
        private PlayerMovementController _playerMovementController;
        private Rigidbody _collisionRigidbody;

        void Start()
        {
            _life = transform.root.GetComponentInChildren<Life>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _playerMovementController = GetComponentInParent<PlayerMovementController>();
            _collisionRigidbody = GetComponentInParent<Rigidbody>();
            _life.Death += OnDeath;
            _animatorTrigger.AnimationEnded += OnDeathAnimationEnd;
        }

        void OnDeath()
        {
            _animatorTrigger.StartAnimation(AnimatorRunMode.AlwaysRun);
            _playerMovementController.CanMove = false;
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
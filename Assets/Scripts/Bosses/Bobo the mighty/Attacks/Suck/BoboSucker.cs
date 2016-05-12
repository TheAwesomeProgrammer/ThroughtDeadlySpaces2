using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.Suck
{
    public class BoboSucker : Trigger
    {
        public Transform SuckTransform;
        public Rigidbody OwnerRigidbody;

        private const float SuckForce = 20000;

        public override void OnStay()
        {
            base.OnStay();
            Rigidbody rigidbodyToSuck = _triggerCollider.attachedRigidbody;
            if (rigidbodyToSuck != null && SuckTransform != null && OwnerRigidbody != rigidbodyToSuck)
            {
                Suck(rigidbodyToSuck);
            }
        }

        private void Suck(Rigidbody rigidbodyToSuck)
        {
            rigidbodyToSuck.AddForce(DirectionToSuckPositionXz(rigidbodyToSuck.position) * SuckForce);
        }

        private Vector3 DirectionToSuckPositionXz(Vector3 otherPosition)
        {
            Vector3 directionToSuckPosition = (SuckTransform.position - otherPosition).normalized;
            directionToSuckPosition.y = 0;
            return directionToSuckPosition;
        }
    }
}
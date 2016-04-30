using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class PlayerMovementChanger
    {
        public void StopMovement(GameObject gameObject)
        {
            gameObject.GetComponent<PlayerMovement>().CanMove = false;
        }

        public void StartMovement(GameObject gameObject)
        {
            gameObject.GetComponent<PlayerMovement>().CanMove = true;
        }
    }
}
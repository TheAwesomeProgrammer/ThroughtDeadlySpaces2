using Assets.Scripts.Enviroment.Map.Statues;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class StatueInteractable : InteractableWithButtons
    {
        private StatuePick _statuePick;

        protected override void Start()
        {
            base.Start();
            _statuePick = GetComponent<StatuePick>();
        }

        protected override void OnInteractableButtonDownAndCollidingWithPlayer()
        {
            base.OnInteractableButtonDownAndCollidingWithPlayer();
            _statuePick.Pick();
            Destroy(this);
        }
    }
}
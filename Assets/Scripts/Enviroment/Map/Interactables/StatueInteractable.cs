using Assets.Scripts.Enviroment.Map.Statues;

namespace Assets.Scripts.Enviroment.Map.InputInteractables
{
    public class StatueInteractable : InteractableWithButtons
    {
        public bool DisableAfterUse;

        private StatuePick _statuePick;
        private bool _enabled;

        protected override void Start()
        {
            base.Start();
            _enabled = true;
            _statuePick = GetComponent<StatuePick>();
        }

        protected override void OnInteractableButtonDownAndCollidingWithPlayer()
        {
            base.OnInteractableButtonDownAndCollidingWithPlayer();
            if (_enabled)
            {
                _statuePick.Pick();
                if (DisableAfterUse)
                {
                    _enabled = false;
                }
            }
        }
    }
}
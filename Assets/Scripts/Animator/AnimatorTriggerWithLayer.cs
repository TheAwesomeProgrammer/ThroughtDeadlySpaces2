using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimatorTriggerWithLayer : AnimatorTrigger
    {
        public int LayerNumber;

        protected override void Start()
        {
            base.Start();
            _layerNumber = LayerNumber;
        }
    }
}
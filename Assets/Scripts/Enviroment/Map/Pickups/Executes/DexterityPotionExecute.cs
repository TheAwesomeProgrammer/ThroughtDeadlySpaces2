using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class DexterityPotionExecute : Executeable
    {
        private float _dexterity;

        public DexterityPotionExecute(float dexterity)
        {
            _dexterity = dexterity;
        }

        public void Execute(GameObject gameObject)
        {
            DexterityFiller dexterityFiller = gameObject.GetComponentInParent<DexterityFiller>();
            dexterityFiller.MaxDexterity += _dexterity;
        }
    }
}
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class StrengthPotionExecute : Executeable
    {
        private int _strength;

        public StrengthPotionExecute(int strength)
        {
            _strength = strength;
        }

        public void Execute(GameObject gameObject)
        {
            SwordAttack swordAttack = gameObject.GetComponentInChildren<SwordAttack>();
            swordAttack.AddDamageData(new StrengthDamageData(_strength));
        }
    }
}
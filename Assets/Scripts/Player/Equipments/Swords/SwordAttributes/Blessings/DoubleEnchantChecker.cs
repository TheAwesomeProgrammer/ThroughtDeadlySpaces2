using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class DoubleEnchantChecker
    {
        private MonoBehaviour _script;

        public DoubleEnchantChecker(MonoBehaviour script)
        {
            _script = script;
        }

        public void Check()
        {
            ShouldSetOtherEnchantTo100Procent();
        }

        private void ShouldSetOtherEnchantTo100Procent()
        {
            EnchantedBlessing enchantedBlessing = ExistSameEnchant();
            if (enchantedBlessing)
            {
                SetOtherEnchantTo100Procent(enchantedBlessing);
            }
        }

        private EnchantedBlessing ExistSameEnchant()
        {
            return _script.GetComponent<EnchantedBlessing>();
        }

        private void SetOtherEnchantTo100Procent(EnchantedBlessing enchantedBlessing)
        {
            enchantedBlessing.ProcentChangeToEnchant = 100;
            //Object.Destroy(_script);
        }
    }
}
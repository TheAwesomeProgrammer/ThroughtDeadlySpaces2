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
            EnchantedSwordBlessing enchantedSwordBlessing = ExistSameEnchant();
            if (enchantedSwordBlessing)
            {
                SetOtherEnchantTo100Procent(enchantedSwordBlessing);
            }
        }

        private EnchantedSwordBlessing ExistSameEnchant()
        {
            return _script.GetComponent<EnchantedSwordBlessing>();
        }

        private void SetOtherEnchantTo100Procent(EnchantedSwordBlessing enchantedSwordBlessing)
        {
            enchantedSwordBlessing.ProcentChangeToEnchant = 100;
            Object.Destroy(_script);
        }
    }
}
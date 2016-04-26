using Assets.Scripts.Player.Swords.Curses;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordAttributeAdder
    {
        private Sword _sword;

        public SwordAttributeAdder(Sword sword)
        {
            _sword = sword;
        }

        public SwordComponent AddAttribute(SwordAttribute swordAttribute)
        {
            switch (swordAttribute)
            {
                case SwordAttribute.Broken:
                    return _sword.AddNewComponent<BrokenSwordCurse>();
                case SwordAttribute.Enchant:
                    return _sword.AddNewComponent<EnchantedSwordBlessing>();
                case SwordAttribute.Heavy:
                    return _sword.AddNewComponent<HeavySwordCurse>();
                case SwordAttribute.LifeDrain:
                    return _sword.AddNewComponent<LifeDrainSwordBlessing>();
                case SwordAttribute.Rusty:
                    return _sword.AddNewComponent<RustySwordCurse>();
                case SwordAttribute.Vsteel:
                    return _sword.AddNewComponent<VsteelSwordBaseBlessing>();
                case SwordAttribute.Worn:
                    return _sword.AddNewComponent<WornSwordCurse>();
                default:
                    return new EmptySwordComponent();
            }
        }
    }
}
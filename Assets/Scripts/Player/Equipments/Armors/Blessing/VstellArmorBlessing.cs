using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Armors.Blessing
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Blessing)]
    public class VstellArmorBlessing : ArmorReduceModifier, XmlAttributeLoadable
    {
        private const int BlessingId = 4;

        private EquipmentAttributeLoader _equipmentAttributeLoader;
        private int _changeOfPreventingAllDamage;
        private Resistance _resistance;
        private bool _preventAllDamage;

        void Start()
        {
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_changeOfPreventingAllDamage))
            {
                _preventAllDamage = true;
            }
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(BlessingId, level, XmlName.Blessing);
            _changeOfPreventingAllDamage = specs[0];
        }

        public override DefenseData ReduceDefenseData(DefenseData defenseData)
        {
            if (_preventAllDamage)
            {
                defenseData.Defense = int.MaxValue;
            }
            return defenseData;
        }
    }
}
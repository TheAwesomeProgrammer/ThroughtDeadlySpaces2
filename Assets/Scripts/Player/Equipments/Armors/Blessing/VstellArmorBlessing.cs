using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Armors.Blessing
{
    public class VstellArmorBlessing : ArmorReduceModifier, XmlLoadable
    {
        private const int BlessingId = 4;

        private XmlSearcher _xmlSearcher;
        private int _changeOfPreventingAllDamage;
        private Resistance _resistance;
        private bool _preventAllDamage;

        void Start()
        {
            _xmlSearcher = new XmlSearcher(Location.Blessing);
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
            LoadXml();
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_changeOfPreventingAllDamage))
            {
                _preventAllDamage = true;
            }
        }

        public void LoadXml()
        {
            _changeOfPreventingAllDamage = _xmlSearcher.GetSpecsInChildrenWithId(BlessingId, "Blessings")[0];
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
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class LifeDrainSwordBlessing : SwordComponent
    {
        public int ProcentChanceOfGainingLifeOnHit = 5;
        public int LifeOnHit = 1;
        public const int BlessingId = 1;

        private SwordAttack _swordAttack;
        private Life _life;
        private XmlSearcher _xmlSearcher;

        void Awake()
        {
            _swordAttack = GetComponent<SwordAttack>();
            _swordAttack.Attacking += OnAttacking;
            _life = GetComponentInParent<Life>();
            LoadSpecs();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(BlessingId, "Blessings");
            ProcentChanceOfGainingLifeOnHit = specs[0];
            LifeOnHit = specs[1];
        }

        void OnAttacking()
        {
            if (IsLifeOnHit())
            {
                _life.Health += LifeOnHit;
            }
        }

        private bool IsLifeOnHit()
        {
            return Random.Range(0, 100f) <= ProcentChanceOfGainingLifeOnHit;
        }
    }
}
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class LifeDrainBlessing : SwordComponent, XmlAttributeLoadable
    {
        public int ProcentChanceOfGainingLifeOnHit = 5;
        public int LifeOnHit = 1;
        public const int BlessingId = 1;

        private SwordAttack _swordAttack;
        private Life _life;
        private EquipmentAttributeLoader _equipmentAttributeLoader;

        void Awake()
        {
            _swordAttack = transform.root.GetComponentInChildren<SwordAttack>();
            _swordAttack.Attacking += OnAttacking;
            _life = GetComponentInParent<Life>();
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Blessing));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(BlessingId, level, XmlName.Blessing);
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
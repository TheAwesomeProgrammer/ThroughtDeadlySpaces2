﻿using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class LifeDrainBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        public int ProcentChanceOfGainingLifeOnHit = 5;
        public int LifeOnHit = 1;
        public const int BlessingId = 1;

        private SwordAttack _swordAttack;
        private Life _life;

        public override void Init()
        {
            base.Init();
            _swordAttack = transform.root.GetComponentInChildren<SwordAttack>();
            _swordAttack.Attacking += OnAttacking;
            _life = GetComponentInParent<Life>();
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Blessing), BlessingId, level, XmlName.Blessing);
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
﻿using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)]
    public class MarkLifeBlessing : MarkBlessing
    {
        public override void Start()
        {
            base.Start();
            CombatType = CombatType.Life;
        }
    }
}
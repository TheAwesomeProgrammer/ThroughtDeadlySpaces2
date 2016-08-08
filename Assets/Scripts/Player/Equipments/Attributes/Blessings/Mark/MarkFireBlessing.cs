﻿using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Blessing)] 
    public class MarkFireBlessing : MarkBlessing
    {
        public override void Init()
        {
            base.Init();
            CombatType = CombatType.Fire;
        }
    }
}
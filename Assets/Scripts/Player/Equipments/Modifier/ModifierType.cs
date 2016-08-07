using System;

namespace Assets.Scripts.Player.Equipments
{
    [Flags]
    public enum ModifierType
    {
        None = 0x0,
        Base = 0x1,
        Strength = 0x2,
        All = 0x4,
        AllButBase = 0x8
    }
}
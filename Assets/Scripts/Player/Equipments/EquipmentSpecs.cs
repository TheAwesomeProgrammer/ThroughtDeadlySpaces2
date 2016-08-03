namespace Assets.Scripts.Player.Equipments
{
    [System.Serializable]
    public class EquipmentSpecs
    {
        public int BaseDamage { get; set; }
        public int FireDamage { get; set; }
        public int NatureDamage { get; set; }
        public int LifeDamage { get; set; }
        public int DeathDamage { get; set; }
        public EquipmentRarity EquipmentRarity { get; set; }


        public EquipmentSpecs(int baseDamage, int fireDamage, int natureDamage, int lifeDamage,
            int deathDamage, EquipmentRarity equipmentRarity)
        {
            BaseDamage = baseDamage;
            FireDamage = fireDamage;
            NatureDamage = natureDamage;
            LifeDamage = lifeDamage;
            DeathDamage = deathDamage;
            EquipmentRarity = equipmentRarity;
        }
    }
}
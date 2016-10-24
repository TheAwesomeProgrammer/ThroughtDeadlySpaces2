using Assets.Scripts.Player.Equipments;

namespace Assets.Scripts.Shop.BlackSmith.MoneyLoaders
{
    public interface MoneyLoadable
    {
        int GetMoney(EquipmentRarity equipmentRarity);
    }
}
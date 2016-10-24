using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class EquipmentPropertyStat : PropertyStat
    {
        public EquipmentType EquipmentType;

        private EquipmentFinder _equipmentFinder;

        public override void Start()
        {
            _equipmentFinder = new EquipmentFinder();
            base.Start();
        }

        protected override void SetType()
        {
            _typeToLoad = typeof(Equipment);
        }

        protected override void LoadPropertyObject()
        {
            StartCoroutine(_equipmentFinder.LoadEquipment((equipment) => _propertyObject = equipment, EquipmentType));
        }
    }
}
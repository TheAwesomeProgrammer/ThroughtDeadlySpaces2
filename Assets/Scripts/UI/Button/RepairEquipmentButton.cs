using Assets.Scripts.Quest;
using Assets.Scripts.Shop.BlackSmith;

namespace Assets.Scripts.Camera_ll_UI.Button
{
    public class RepairEquipmentButton : UiButton
    {
        private EquipmentRepairer _equipmentRepairer;

        protected override void Start()
        {
            base.Start();
            _equipmentRepairer = new EquipmentRepairer();
        }

        protected override void OnClick()
        {
            base.OnClick();
            _equipmentRepairer.ShouldRepair(GetComponent<RepairItem>());
        }
    }
}
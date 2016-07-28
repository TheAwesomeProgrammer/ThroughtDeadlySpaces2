using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract;

namespace Assets.Scripts.Player.Swords
{
    public class SwordManager : ComponentManager<Sword>
    {
        private const int NumberOfSlots = 2;
        private const int PrimarySword = 0;
        private const int SecoundarySword = 1;

        private SwordAttack _swordAttack;

        protected override void Start()
        {
            base.Start();
            Sword sword = AddNewComponent<DefaultSword>();
            sword.Load(1);
            sword = AddNewComponent<DefaultSword>();
            sword.Load(2);
        }

        public override Sword AddExistingComponent(Sword component)
        {
            return AddNewSword(component);
        }

        public Sword Get(int index)
        {
            return _components[index];
        }

        private Sword AddNewSword(Sword newSword)
        {
            TypeSwitch.Do(_components.Count,
                TypeSwitch.Case(new object[] {0, 1}, () => AddSword(newSword)),
                TypeSwitch.Case(NumberOfSlots, () => SwitchForNewSword(_components[PrimarySword], newSword)));

            return newSword;
        }

        private void AddSword(Sword sword)
        {
            _components.Add(sword);

            if (_components.Count > 1)
            {
                sword.DeactivateAfterLoad = true;
            }
        }

        private void SwitchForNewSword(Sword oldSword, Sword newSword)
        {
            SwitchTo(newSword);
            RemoveComponent(oldSword);
        }

        public void SwitchSword()
        {
            SwitchSword(_components[PrimarySword], _components[SecoundarySword]);
        }

        private void SwitchSword(Sword oldSword, Sword newSword)
        {
            SwitchOut(oldSword);
            SwitchTo(newSword);            
        }

        private void SwitchTo(Sword sword)
        {
            _components[PrimarySword] = sword;
            ActivateSword(sword);
        }

        private void SwitchOut(Sword sword)
        {
            _components[SecoundarySword] = sword;
            DeactivateSword(sword);
        }

        private void ActivateSword(Sword sword)
        {
            sword.enabled = true;
        }

        private void DeactivateSword(Sword sword)
        {
            sword.enabled = false;
        }
    }
}
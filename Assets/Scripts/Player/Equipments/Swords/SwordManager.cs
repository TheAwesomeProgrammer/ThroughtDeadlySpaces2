using System;
using System.Collections;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordManager : ComponentManager<Sword>
    {
        private const int NumberOfSlots = 2;
        private const int PrimarySwordIndex = 0;
        private const int SecoundarySwordIndex = 1;

        private SwordAttack _swordAttack;
        private UiSwordSwitching _uiSwordSwitching;

        protected override void Start()
        {
            base.Start();
            _uiSwordSwitching = Camera.main.GetComponentInChildren<UiSwordSwitching>();
            Sword sword = AddNewComponent<DefaultSword>();
            sword.Load(1);
            sword = AddNewComponent<DefaultSword>();
            sword.Load(2);
        }

        public override Sword AddExistingComponent(Sword component)
        {
            return AddNewSword(component);
        }

        public void GetPrimarySwordWhenLoaded(Action<Sword> result)
        {
            StartCoroutine(GetSwordWhenLoaded(result, PrimarySwordIndex));
        }

        private IEnumerator GetSwordWhenLoaded(Action<Sword> result, int index)
        {
            bool isEquipmentNull = true;
            Sword sword = null;

            while (isEquipmentNull)
            {
                sword = Get(index);
                if (sword != null)
                {
                    isEquipmentNull = false;
                }
                yield return null;
            }

            result.InvokeIfNotNull(sword);
        }

        public Sword GetPrimarySword()
        {
            return Get(PrimarySwordIndex);
        }

        public Sword Get(int index)
        {
            if (_components.Count > index)
            {
                return _components[index];
            }
            return null;
        }

        private Sword AddNewSword(Sword newSword)
        {
            Switch.Do(_components.Count,
                Switch.Case(new object[] {0, 1}, () => AddSword(newSword)),
                Switch.Case(NumberOfSlots, () => SwitchForNewSword(_components[PrimarySwordIndex], newSword)));

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
            _uiSwordSwitching.Switch();
            SwitchSword(_components[PrimarySwordIndex], _components[SecoundarySwordIndex]);
        }

        private void SwitchSword(Sword oldSword, Sword newSword){

	        oldSword.ChangeEquipment(newSword);
	        SwitchOut(oldSword);
            SwitchTo(newSword);            
        }

        private void SwitchTo(Sword sword)
        {
            _components[PrimarySwordIndex] = sword;
            ActivateSword(sword);
        }

        private void SwitchOut(Sword sword)
        {
            _components[SecoundarySwordIndex] = sword;
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
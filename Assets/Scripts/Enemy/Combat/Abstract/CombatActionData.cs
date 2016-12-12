using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    [Serializable]
    public class CombatActionData
    {
        public List<string> CombatActions;
        public float Time;
        public int Index;

        private List<Type> _combatActions;
        private CombatAction _combatAction;
        private GameObject _combatActionGameObject;

        public void Init(GameObject combatActionGameObject)
        {
            _combatActionGameObject = combatActionGameObject;
            Type combatActionType = _combatActions[Index];
            Component combatActionComponent = _combatActionGameObject.AddComponent(combatActionType);
            _combatAction = combatActionComponent as CombatAction;
        }

        public void SetCombatActions()
        {
            CombatActions = FindCombatActions();
        }

        private List<string> FindCombatActions()
        {
            List<string> combatActions = new List<string>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(CombatAction)))
                {
                    _combatActions.Add(type);
                    combatActions.Add(type.Name);
                }
            }

            return combatActions;
        }
    }
}
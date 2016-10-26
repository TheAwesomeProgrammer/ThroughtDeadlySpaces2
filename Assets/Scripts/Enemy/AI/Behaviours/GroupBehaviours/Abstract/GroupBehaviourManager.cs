using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Enemy.AI.Behaviours.Factories.Abstract;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI
{
    public class GroupBehaviourManager : MonoBehaviour
    {
        private List<GroupBehaviour> _groupBehaviours;

        private Group _group;

        private void Awake()
        {
            _group = GetComponentInParent<Group>();
            _groupBehaviours = new List<GroupBehaviour>();
        }

        public void Add(GroupBehaviour groupBehaviour)
        {
            _groupBehaviours.Add(groupBehaviour);
        }

        public void Remove(GroupBehaviour groupBehaviour)
        {
            _groupBehaviours.Add(groupBehaviour);
        }

        public State GetState(StateType stateType)
        {
            GroupBehaviour groupBehaviour = _groupBehaviours.Find(item => item.GroupSize.IsFlagSet(GetGroupSize()) && item.StateType == stateType);
            NullAsserter.Assert(groupBehaviour, "Group behaviour", "State type is "+stateType);
            return groupBehaviour.GetState();
        }

        private GroupSize GetGroupSize()
        {
            if (_group == null)
            {
                return GroupSize.Individual;
            }
            return _group.Size;
        }
    }
}
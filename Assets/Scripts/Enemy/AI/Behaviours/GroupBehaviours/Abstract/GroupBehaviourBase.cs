using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy.AI.Behaviours.Factories.Abstract;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Behaviours.GroupBehaviours.Abstract
{
    public abstract class GroupBehaviourBase : MonoBehaviour, GroupBehaviour
    {
        public abstract GroupSize GroupSize { get;  }
        public abstract StateType StateType { get; }
        
        protected List<BehavoiourStateData> _states;

        protected GroupBehaviourManager _groupBehaviourManager;
        private BehaviourStates _behaviourStates;

        protected virtual void Start()
        {
            _behaviourStates = GetComponent<BehaviourStates>();
            _states = _behaviourStates.States;
            _groupBehaviourManager = GetComponentInParent<GroupBehaviourManager>();
            _groupBehaviourManager.Add(this);
        }

        public abstract State GetState();

    }
}
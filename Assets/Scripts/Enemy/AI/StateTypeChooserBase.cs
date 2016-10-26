using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI
{
    public abstract class StateTypeChooserBase : MonoBehaviour, StateTypeChooser
    {
        public abstract StateType GetStateType();
    }
}
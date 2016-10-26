using System.Collections.Generic;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy.AI.Behaviours.Factories.Abstract
{
    public interface GroupBehaviour
    {
        GroupSize GroupSize { get; }
        StateType StateType { get; }

        State GetState();
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public interface ScriptGenerateable
    {
        List<T> Generate<T>(int generateNumber) where T : MonoBehaviour;
    }
}
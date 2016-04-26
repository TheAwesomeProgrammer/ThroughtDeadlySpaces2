using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public interface ScriptSpawnable
    {
        MonoBehaviour Spawn(MonoBehaviour script);
        List<MonoBehaviour> Spawn(List<MonoBehaviour> scripts);
        List<MonoBehaviour> Spawn(MonoBehaviour script, int numberToSpawn);
    }
}
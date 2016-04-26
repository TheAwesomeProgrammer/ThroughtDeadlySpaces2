using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public abstract class ScriptSpawner : MonoBehaviour, ScriptSpawnable
    {
        public virtual MonoBehaviour Spawn(MonoBehaviour script)
        {
            MonoBehaviour spawnedScript = Instantiate(script);
            return spawnedScript;
        }

        public List<MonoBehaviour> Spawn(List<MonoBehaviour> scripts)
        {
            List<MonoBehaviour> spawnedScripts = new List<MonoBehaviour>();

            foreach (var script in scripts)
            {
                spawnedScripts.Add(Spawn(script));
            }

            return spawnedScripts;
        }

        public List<MonoBehaviour> Spawn(MonoBehaviour script, int numberToSpawn)
        {
            List<MonoBehaviour> spawnedScripts = new List<MonoBehaviour>();

            for (int i = 0; i < numberToSpawn; i++)
            {
                spawnedScripts.Add(Spawn(script));
            }

            return spawnedScripts;
        }
    }
}
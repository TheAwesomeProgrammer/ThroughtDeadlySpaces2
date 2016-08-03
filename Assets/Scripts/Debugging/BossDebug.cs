using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Debugging
{
    public class BossDebug : MonoBehaviour
    {
        public BossType BossToSpawn;
        public Transform PlayerSpawn;
        public Transform BossSpawn;
        public bool Debug = true;

        private BossGenerator _bossGenerator;

        public void Start()
        {
            if (Debug)
            {
                _bossGenerator = GetComponent<BossGenerator>();
                _bossGenerator.GetBoss(BossSpawnType.Specific, (int)BossToSpawn).Spawn(BossSpawn.position);
                GameObject.FindGameObjectWithTag(Tag.Player).transform.position = PlayerSpawn.position;
            }
        }
    }
}
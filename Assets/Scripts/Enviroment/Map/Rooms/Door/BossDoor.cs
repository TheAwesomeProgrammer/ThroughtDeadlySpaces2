using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BossDoor : Door
    {
        private BossRoom _parentRoom;

        protected override void Start()
        {
            base.Start();
            _parentRoom = GetComponentInParent<BossRoom>();
        }

        void Update()
        {
            ShouldUnlock();
        }

        void ShouldUnlock()
        {
            if (!_parentRoom.IsBossAlive)
            {
                UnLock();
            }
        }
    }
}
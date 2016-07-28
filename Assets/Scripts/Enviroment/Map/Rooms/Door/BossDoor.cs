using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Rooms
{
    public class BossDoor : Door
    {
        private BossRoom _bossRoom;

        protected override void Start()
        {
            base.Start();
            _bossRoom = GetComponentInParent<BossRoom>();
        }

        void Update()
        {
            ShouldUnlock();
        }

        void ShouldUnlock()
        {
            if (!_bossRoom.IsBossAlive)
            {
                UnLock();
                _bossRoom.OnMoveToNextRoom();
            }
        }
    }
}
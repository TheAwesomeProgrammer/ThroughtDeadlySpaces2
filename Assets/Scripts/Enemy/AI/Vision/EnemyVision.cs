using System;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Vision;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyVision : MonoBehaviour
    {
        public Transform RightEye;
        public Transform LeftEye;
        public VisionConfig VisionConfig;

        private VisionChecker _visionChecker;
        private Transform _player;

        private void Start()
        {
            _visionChecker = new VisionChecker();
            _player = GameObject.FindGameObjectWithTag(Tag.PlayerCollision).transform;
        }

        public bool CanSeePlayer()
        {
            if (CanSee(RightEye, _player, VisionConfig) || CanSee(LeftEye, _player, VisionConfig)) 
            {
                return true;
            }
            return false;
        }

        private bool CanSee(Transform from, Transform to, VisionConfig visionConfig)
        {
            return _visionChecker.CanSee(from.position, to.position, visionConfig);
        }
    }
}
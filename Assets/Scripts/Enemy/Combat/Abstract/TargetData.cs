using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    [Serializable]
    public class TargetData
    {
        public TargetType TargetType;
        public Transform TargetTransform;
        public Vector3 TargetPosition;
        public string TargetTag;

        private List<Vector3> _positions;

        public Vector3 GetTargetPosition()
        {
            _positions = new List<Vector3>();

            _positions.Add(Null.OnNot(TargetTransform, () => TargetTransform.position));
            _positions.Add(Null.OnNot(GetTargetPositionBy(TargetTag), () => GetTargetPositionBy(TargetTag).transform.position));
            _positions.Add(TargetPosition);

            return _positions.Find(item => item != Vector3.zero);
        }

        private GameObject GetTargetPositionBy(string tag)
        {
            return GameObject.FindGameObjectWithTag(TargetTag);
        }
    }
}
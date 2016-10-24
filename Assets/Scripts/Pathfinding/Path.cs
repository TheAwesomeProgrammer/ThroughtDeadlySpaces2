using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    public class Path
    {
        private IEnumerable<Vector3> _points; 

        public Path(IEnumerable<Vector3> points)
        {
            _points = points;
        }
    }
}
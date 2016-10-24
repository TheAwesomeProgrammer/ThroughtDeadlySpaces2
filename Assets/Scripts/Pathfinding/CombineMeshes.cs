using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    public class CombineMeshes : MonoBehaviour
    {
        public List<GameObject> GameObjectsMeshesToCombine;

        private Mesh _combinedMesh;

        private void Start()
        {
            _combinedMesh = Combine(GameObjectsMeshesToCombine.Select(item => item.GetComponentInChildren<MeshFilter>()).ToList());
            _combinedMesh.name = "CombinedMesh";
           
            var graph = AstarPath.active.astarData.navmesh;
            graph.sourceMesh = _combinedMesh;
            AstarPath.active.Scan();

            //GetComponentInChildren<MeshFilter>().mesh = _combinedMesh;
        }

        private Mesh Combine(List<MeshFilter> meshFilters)
        {
            Mesh combinedMesh = new Mesh();
            CombineInstance[] combine = new CombineInstance[meshFilters.Count];
            int i = 0;
            while (i < meshFilters.Count)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                i++;
            }

            combinedMesh.CombineMeshes(combine);
            return combinedMesh;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class BridgeManager : MonoBehaviour
    {
        private BridgeBlock[] _bridgeBlocks;

        public void Start()
        {
            _bridgeBlocks = GetComponentsInChildren<BridgeBlock>();
        }

        public void ActivateBridge()
        {
            foreach (var bridgeBlock in _bridgeBlocks)
            {
                bridgeBlock.Activate();
            }
        }

        public void DeactivateBridge()
        {
            foreach (var bridgeBlock in _bridgeBlocks)
            {
                bridgeBlock.Deactivate();
            }
        }
    }
}
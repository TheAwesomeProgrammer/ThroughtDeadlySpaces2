using System;
using System.Collections.Generic;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI
{
    [Serializable]
    public class UiCombination
    {
        public List<SwitchType> ImmovableSwitchTypes;

        public bool IsImmovable(int id1, int id2)
        {
            return Exist(id1) && Exist(id2) && id1 != id2;
        }

        private bool Exist(int id)
        {
            return ImmovableSwitchTypes != null && ImmovableSwitchTypes.Exists(item => (int)item == id);
        }
    }

    public class UiMoveManager : MonoBehaviour
    {
        public List<UiCombination> ImmovableCombinations;
        public bool CanAlwaysMove;
        public bool ShouldQueue;

        private List<SwitchInfo> _runningSwitches;
        private Queue<Switchable> _queueToBeRun;

        public void Start()
        {
            _queueToBeRun = new Queue<Switchable>();
            _runningSwitches = new List<SwitchInfo>();
        }

        public void MoveIfSwitchNotExist(UiMoveSwitching uiMoveSwitching, Action onCompleteSwitch = null)
        {
            MoveIfSwitchNotExist((int)uiMoveSwitching.SwitchType, uiMoveSwitching, onCompleteSwitch);
        }

        public void MoveIfSwitchNotExist(int id, Switchable switchable, Action onCompleteSwitch = null)
        {
            if (!_runningSwitches.Exists(item => item.Id == id))
            {
                Move(id, switchable, onCompleteSwitch);
            }
        }

        public void Move(UiMoveSwitching uiMoveSwitching, Action onCompleteSwitch = null)
        {
            Move((int)uiMoveSwitching.SwitchType, uiMoveSwitching, onCompleteSwitch);
        }

        public void Move(int id, Switchable switchable, Action onCompleteSwitch = null)
        {
            if (ExistImmovableCombination(id) && !CanAlwaysMove)
            {
                OnImmovableCombination(switchable);
            }
            else
            {
                _runningSwitches.Add(new SwitchInfo(id, switchable, onCompleteSwitch));
                switchable.Switch(SwitchingDone);
            }
        }

        private void SwitchingDone(int id)
        {
            SwitchInfo switchInfo = _runningSwitches.Find(item => item.Id == id);
            
            if (switchInfo != null)
            {
                switchInfo.Callback();
            }

            _runningSwitches.Remove(item => item.Id == id);
        }

        private void OnImmovableCombination(Switchable switchable)
        {
            if (ShouldQueue)
            {
                _queueToBeRun.Enqueue(switchable);
            }
        }

        private bool ExistImmovableCombination(int id)
        {
            foreach (var runningSwitch in _runningSwitches)
            {
                if (ExistImmovableCombination(runningSwitch.Id, id))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExistImmovableCombination(int id1, int id2)
        {
            foreach (var immovableCombination in ImmovableCombinations)
            {
                if (immovableCombination.IsImmovable(id1, id2))
                {
                    return true;
                }
            }

            return false;
        }
      
    }
}
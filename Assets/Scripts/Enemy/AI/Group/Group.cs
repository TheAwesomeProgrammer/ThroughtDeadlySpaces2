using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI
{
    public class GroupEventArgs : EventArgs
    {
        public GroupData NewGroupData;
        public GroupData OldGroupData;

        public GroupEventArgs(GroupData newGroupData, GroupData oldGroupData)
        {
            NewGroupData = newGroupData;
            OldGroupData = oldGroupData;
        }
    }

    public class Group : MonoBehaviour
    {
        public GroupSize Size
        {
            get { return FindGroupData().GroupSize; }
        }

        public event EventHandler<GroupEventArgs> GroupSizeChanged; 
        public List<GroupData> GroupDatas;

        private GroupData _currentGroupData;
        private GroupData _lastGroupData;

        private void Start()
        {
            GroupDatas.Sort((a, b) => a.GroupMinSize.CompareTo(b.GroupMinSize));
        }

        private void Update()
        {
            _currentGroupData = FindGroupData();
            CheckForGroupSizeChange();
            _lastGroupData = _currentGroupData;
            Debug.Log("Current group size " + _currentGroupData.GroupSize + Environment.NewLine + 
                "Count of enemies : "+ EnemiesCount());
        }

        private void CheckForGroupSizeChange()
        {
            if (_currentGroupData != _lastGroupData && GroupSizeChanged != null)
            {
                GroupSizeChanged.Invoke(this, new GroupEventArgs(_currentGroupData, _lastGroupData));
            }
        }

        private GroupData FindGroupData()
        {
            GroupData foundGroupData = null;
            int enemiesCount = EnemiesCount();

            for (int i = 0; i < GroupDatas.Count; i++)
            {
                GroupData currentGroupData = GroupDatas[i];
                GroupData nextGroupData = GroupDatas.Next(i);

                if (nextGroupData == null)
                {
                    foundGroupData = currentGroupData;
                    break;
                }

                if (enemiesCount >= currentGroupData.GroupMinSize && enemiesCount < nextGroupData.GroupMinSize)
                {
                    foundGroupData = currentGroupData;
                    break;
                }
            }

            return foundGroupData;
        }

        private int EnemiesCount()
        {
            return GetComponentsInChildren<EnemyMind>().Length;
        }
    }
}
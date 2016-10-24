using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI
{
    public class TestGroup : MonoBehaviour
    {
        private Group _group;

        private void Start()
        {
            _group = GetComponent<Group>();
            _group.GroupSizeChanged += OnGroupSizeChanged;
        }

        private void OnGroupSizeChanged(object sender, GroupEventArgs e)
        {
            Debug.Log("Sender "+ sender + Environment.NewLine + 
                "Old group data" + e.OldGroupData + Environment.NewLine + 
                "new group data "+ e.NewGroupData);
        }
    }
}
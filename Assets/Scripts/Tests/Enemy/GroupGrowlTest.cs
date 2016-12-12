using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.AI;
using Assets.Scripts.Enemy.AI.Abstact;
using Assets.Scripts.Event;
using Assets.Scripts.Tests.Helper;
using UnityEngine;

namespace Assets.Scripts.Tests.Enemy
{
    public class GroupGrowlTest : MonoBehaviour
    {
        private EventManager _groupEventManager;
        private Group _group;
        private EnemyMind _growlingMind;

        private void Start()
        {
            _groupEventManager = GetComponentInChildren<EventManager>();
            _groupEventManager.Subscribe<EventArgs>(AiEvent.JustSeenPlayer, OnJustSeenPlayer);
            _group = GetComponentInChildren<Group>();
        }

        private void OnJustSeenPlayer(object sender, EventArgs e)
        {
            _growlingMind = (sender as MonoBehaviour).GetComponentInParent<EnemyMind>();
            Timer.Start(gameObject, 1, Check);
        }

        private void Check()
        {
            IntegrationAssert.Equals(_growlingMind.CurrentStateData.State.GetType(), typeof(GrowlState), "Growling mind is not growling");

            List<EnemyMind> notGrowlingMinds =
                _group.Enemies.FindAll(item => item.CurrentStateData.State.GetType() != typeof (GrowlState));

            IntegrationAssert.Equals(notGrowlingMinds.Count, _group.EnemiesCount() - 1);
        }
    }
}
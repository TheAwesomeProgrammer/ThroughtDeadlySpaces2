using Assets.Scripts.Combat.Defense.Boss;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class WeaknessProperty : PropertyStat
    {
        protected override void SetType()
        {
            _typeToLoad = typeof(Weakness);
        }

        protected override void LoadPropertyObject()
        {
            GameObject enemyCollision = GameObject.FindGameObjectWithTag(Tag.EnemyCollision);
            Null.OnNot(enemyCollision, () => _propertyObject = enemyCollision.GetComponentInChildren<Weakness>());
        }
    }
}
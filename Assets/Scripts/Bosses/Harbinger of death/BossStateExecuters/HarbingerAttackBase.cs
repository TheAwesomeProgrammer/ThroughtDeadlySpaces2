using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class HarbingerAttackBase : MonoBehaviour, BossStateExecuter, XmlLoadable
    {
        protected const int BossId = 1;
        

        protected AnimatorTrigger _animatorTrigger;
        protected HarbingerOfDeath _harbingerOfDeath;
        protected BossSwordAttack _bossSwordAttack;
        protected HarbingerOfDeathState[] _possiblePauseStates;
        protected int _baseDamage;
        protected int _baseDamageXmlId = 1;
        protected int _attackDelay;
        protected XmlSearcher _xmlSearcher;
        private AnimationEventListener _animationEventListener;

        protected virtual void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _bossSwordAttack = transform.root.FindComponentInChildWithName<BossSwordAttack>("Sword");
            _animationEventListener = GetComponent<AnimationEventListener>();
            _animationEventListener.SetupAnimatorTriggerEnd(OnAnimationEnded);
            LoadXml();
        }

        public void LoadXml()
        {
            _xmlSearcher = new XmlSearcher(Location.Boss);
            _baseDamage = _xmlSearcher.GetSpecsInChildrenWithId(BossId, "Bosses", "Damage")[_baseDamageXmlId];
        }

        protected void OnAnimationEnded()
        {
            SwitchState();
        }

        public virtual void SwitchState()
        {
            _harbingerOfDeath.ChangeState(GetRandomPauseState());
            _bossSwordAttack.EndAttack();
        }

        protected virtual HarbingerOfDeathState GetRandomPauseState()
        {
            return _possiblePauseStates[Random.Range(0, _possiblePauseStates.Length)];
        }

        public virtual void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _bossSwordAttack.SetExtraBaseDamage(_baseDamage);
            _harbingerOfDeath = harbingerOfDeath;

            if (_attackDelay <= 0)
            {
                Attack();
            }
            else if (_attackDelay > 0)
            {
                Timer.Start(_attackDelay, DelayedAttack);
            }
        }

        protected virtual void Attack()
        {
            _animatorTrigger.StartAnimation();
        }

        protected virtual void DelayedAttack()
        {
            _animatorTrigger.StartAnimation();
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {

        }
    }
}
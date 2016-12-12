namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class GroupMovementStateChanger : StateChangerBase
    {
        private EnemyClosest _enemyClosest;
        private Group _group;

        protected override void Start()
        {
            base.Start();
            _enemyClosest = GetComponentInParent<EnemyClosest>();
            _group = GetComponentInParent<Group>();
        }

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            newState = null;
            return false;
        }
    }
}
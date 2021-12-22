namespace EnemyStateMachineScripts
{
    public abstract class EnemyBaseState
    {
        protected EnemyBaseState _superSet;
        protected EnemyBaseState _subSet;
        protected EnemyStateMachine _enemyStateMachine;
        protected EnemyStateFactory _factory;

        protected bool isRoot = false;

        protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
            _factory = new EnemyStateFactory(_enemyStateMachine);
        }

        public abstract void StartState();
        public abstract void UpdateState();
        public abstract void EndState();
        public abstract void InitSubSet();
        public abstract void CheckSwitchState();


        public void StartStates()
        {
            StartState();
            if (_subSet != null)
            {
                _subSet.StartStates();
            }
        }

        public void UpdateStates()
        {
            UpdateState();
            if (_subSet != null)
            {
                _subSet.UpdateStates();
            }
        }

        public void EndStates()
        {
            EndState();
            if (_subSet != null)
            {
                _subSet.EndStates();
            }
        }

        protected void SwitchState(EnemyBaseState state)
        {
            EndStates();
            state.StartStates();
            if (isRoot)
            {
                _enemyStateMachine.CurrentState = state;
            }
            else if (_superSet != null)
            {
                _superSet.SetSupState(state);
            }
        }


        protected void SetSuperState(EnemyBaseState state)
        {
            _superSet = state;
        }

        protected void SetSupState(EnemyBaseState state)
        {
            _subSet = state;
            _subSet.SetSuperState(this);
        }
    }
}
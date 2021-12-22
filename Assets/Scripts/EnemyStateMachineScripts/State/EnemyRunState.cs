using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyRunState : EnemyBaseState
    {
        private PlayerStateMachine _PlayerStateMachine;
        
        public EnemyRunState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            isRoot = true;
        }

        public override void StartState()
        {
            _enemyStateMachine.Animator.SetBool(_enemyStateMachine.IsRunHash,true);
            _PlayerStateMachine = GameObject.FindObjectOfType<PlayerStateMachine>();
        }

        public override void UpdateState()
        {
            CheckSwitchState();
            _enemyStateMachine.transform.LookAt(_PlayerStateMachine.transform.position);
            _enemyStateMachine.CurrentMovementVector = _enemyStateMachine.transform.forward * 15;

            if (_PlayerStateMachine.transform.position.y < -5)
            {
                GameObject.FindObjectOfType<GameSceneController>().OnDie();
                GameObject.Destroy(_enemyStateMachine.gameObject);
            }
        }

        public override void EndState()
        {
            _enemyStateMachine.Animator.SetBool(_enemyStateMachine.IsRunHash,false);
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (_enemyStateMachine.IsTouch)
            {
                SwitchState(_factory.Kill());
            }else if (_enemyStateMachine.IsRotating)
            {
                SwitchState(_factory.Rotate());
            }
        }
    }
}
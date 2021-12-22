using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyKillState : EnemyBaseState
    {
        private float counter = 0.0f;
        public EnemyKillState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            isRoot = true;
        }

        public override void StartState()
        {
            Debug.Log("Kill");
            _enemyStateMachine.Animator.SetBool(_enemyStateMachine.IsKillHash,true);
        }

        public override void UpdateState()
        {
            _enemyStateMachine.CurrentMovementVector = Vector3.zero;
            counter += Time.deltaTime;
            CheckSwitchState();
        }

        public override void EndState()
        {
            
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (counter >= 2)
            {
                _enemyStateMachine.Animator.SetBool(_enemyStateMachine.IsKillHash,false);
                GameObject.FindObjectOfType<GameSceneController>().OnDie();
            }
        }
    }
}
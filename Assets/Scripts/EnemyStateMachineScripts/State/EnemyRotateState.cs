using UnityEngine;

namespace EnemyStateMachineScripts.State
{
    public class EnemyRotateState : EnemyBaseState
    {
        public EnemyRotateState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            isRoot = true;
        }

        public override void StartState()
        {
            Debug.Log("ERotate");
            _enemyStateMachine.CurrentMovementVector = _enemyStateMachine.transform.forward * 10;
        }

        public override void UpdateState()
        {
            if (_enemyStateMachine.CanRotate)
            {
                _enemyStateMachine.transform.LookAt(GameObject.FindObjectOfType<PlayerStateMachine>().transform.position);
                _enemyStateMachine.IsRotating = false;
                _enemyStateMachine.CanRotate = false;
                SwitchState(_factory.Run());
            }
        }

        public override void EndState()
        {
            
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            
        }
    }
}
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace PlayerStateMachineScripts.States
{
    public class PlayerDieState : PlayerBaseState
    {
        public PlayerDieState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            isRoot = true;
        }

        public override void StartState()
        {
            Debug.Log("Die");
            _playerStateMachine.Animator.SetBool(_playerStateMachine.IsDieHash,true);
            
        }

        public override void UpdateState()
        {
            _playerStateMachine.CurrentMovementVector = Vector3.zero;
            _playerStateMachine.VericalDeceleration = 0;
            _playerStateMachine.VericalVelocity = 0;
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
           
        }
    }
}
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void StartState()
        {
            Debug.Log("Jump");
            _playerStateMachine.VericalVelocity = 20.0f;
            _playerStateMachine.Animator.SetTrigger(_playerStateMachine.IsJumpHash);
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.Animator.ResetTrigger(_playerStateMachine.IsJumpHash);
        }

        public override void InitSubSet()
        {
        
        }

        public override void CheckSwitchState()
        {
            if (_playerStateMachine.VericalVelocity <= 1.0f && _playerStateMachine.CharacterController.isGrounded)
            {
                SwitchState(_factory.Run());
            }
        }
    }
}
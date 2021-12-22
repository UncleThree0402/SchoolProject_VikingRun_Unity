using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void StartState()
        {
            _playerStateMachine.Animator.SetBool(_playerStateMachine.IsRunHash, true);
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.Animator.SetBool(_playerStateMachine.IsRunHash, false);
        }

        public override void InitSubSet()
        {
            
        }

        public override void CheckSwitchState()
        {
            if (!_playerStateMachine.IsRotating && _playerStateMachine.IsJumpPress)
            {
                SwitchState(_factory.Jump());
            }else if (_playerStateMachine.IsRotating && !_playerStateMachine.IsJumpPress && _playerStateMachine.AbleToRotate)
            {
                SwitchState(_factory.Rotate());
            }else if (!_playerStateMachine.IsWalkPressing)
            {
                SwitchState(_factory.Idle());
            }
        }
    }
}
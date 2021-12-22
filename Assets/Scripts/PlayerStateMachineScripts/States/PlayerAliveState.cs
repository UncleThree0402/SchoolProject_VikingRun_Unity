using UnityEngine;

namespace PlayerStateMachineScripts.States
{
    public class PlayerAliveState : PlayerBaseState
    {
        
        public PlayerAliveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            isRoot = true;
            InitSubSet();
        }

        public override void StartState()
        {
            Debug.Log("Alive");
        }

        public override void UpdateState()
        {
            _playerStateMachine.Psvm.AddTimeFloat(Time.deltaTime);
            Vector3 applyVector;
            if (_playerStateMachine.CurrentMovementInput.y != 0)
            {
                applyVector = _playerStateMachine.transform.forward;
            }
            else
            {
                applyVector = Vector3.zero;
            }

            if (_playerStateMachine.IsWalkPressing)
            {
                if (_playerStateMachine.CurrentMovementInput.x > 0)
                {
                    applyVector += _playerStateMachine.transform.right;
                }
                else if(_playerStateMachine.CurrentMovementInput.x < 0)
                {
                    applyVector -= _playerStateMachine.transform.right;
                }
            }

            applyVector *= 15;
            
            _playerStateMachine.CurrentMovementVector = applyVector;
            CheckSwitchState();
        }

        public override void EndState()
        {
            _playerStateMachine.CurrentMovementVector = Vector3.zero;
        }

        public override void InitSubSet()
        {
            if (!_playerStateMachine.IsRotating && _playerStateMachine.IsJumpPress)
            {
                SetSupState(_factory.Jump());
            }else if (_playerStateMachine.IsRotating && !_playerStateMachine.IsJumpPress && _playerStateMachine.AbleToRotate)
            {
                SetSupState(_factory.Rotate());
            }else
            {
                SetSupState(_factory.Run());
            }
        }

        public override void CheckSwitchState()
        {
            if (!_playerStateMachine.IsAlive || _playerStateMachine.transform.localPosition.y < -10)
            {
                SwitchState(_factory.Die());
            }
        }
    }
}
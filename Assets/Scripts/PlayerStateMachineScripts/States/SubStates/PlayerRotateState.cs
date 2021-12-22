using System;
using EnemyStateMachineScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRotateState : PlayerBaseState
    {
        private float targetAngle;
        private float enterAngle;
        public PlayerRotateState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void StartState()
        {
            Debug.Log("Rotate");
            enterAngle = (float)Math.Round(_playerStateMachine.transform.eulerAngles.y);
            if (_playerStateMachine.CurrentRotateInput.x < 0)
            {
                targetAngle = _playerStateMachine.transform.eulerAngles.y - 90;
            }
            else
            {
                targetAngle = _playerStateMachine.transform.eulerAngles.y + 90;
            }
            _playerStateMachine.AbleToRotate = false;

            GameObject.FindObjectOfType<EnemyStateMachine>().IsRotating = true;
        }

        public override void UpdateState()
        {
            _playerStateMachine.transform.rotation = Quaternion.Slerp(_playerStateMachine.transform.rotation,
                Quaternion.Euler(0, targetAngle, 0), 15f * Time.deltaTime);
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
            if ( checkRotate())
            {
                SwitchState(_factory.Run());
            }
        }

        private bool checkRotate()
        {
            if ( Math.Ceiling(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Ceiling(Math.Round(targetAngle < 0 ? 360 + targetAngle : targetAngle))
                || Math.Ceiling(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Floor(Math.Round(targetAngle < 0 ? 360 + targetAngle : targetAngle))
                || Math.Floor(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Ceiling(Math.Round(targetAngle < 0 ? 360 + targetAngle : targetAngle))
                || Math.Floor(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Floor(Math.Round(targetAngle < 0 ? 360 + targetAngle : targetAngle)))
            {
                return true;
            }
            else if(Math.Ceiling(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Ceiling(Math.Round(targetAngle >= 360 ? targetAngle - 360 : targetAngle))
                    || Math.Ceiling(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Floor(Math.Round(targetAngle >= 360 ? targetAngle - 360 : targetAngle))
                    || Math.Floor(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Ceiling(Math.Round(targetAngle >= 360 ? targetAngle - 360 : targetAngle))
                    || Math.Floor(Math.Round(_playerStateMachine.transform.eulerAngles.y)) == Math.Floor(Math.Round(targetAngle >= 360 ? targetAngle - 360 : targetAngle)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
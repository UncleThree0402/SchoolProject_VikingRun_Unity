using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerBaseState _superSet;
    protected PlayerBaseState _subSet;
    protected PlayerStateMachine _playerStateMachine;
    protected PlayerStateFactory _factory;

    protected bool isRoot = false;

    protected PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
        _factory = new PlayerStateFactory(_playerStateMachine);
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

    protected void SwitchState(PlayerBaseState state)
    {
        Debug.Log("Switch");
        EndStates();
        state.StartStates();
        if (isRoot)
        {
            _playerStateMachine.CurrentState = state;
        }else if (_superSet != null)
        {
            _superSet.SetSupState(state);
        }
    }
    
    
    protected void SetSuperState(PlayerBaseState state)
    {
        _superSet = state;
    }

    protected void SetSupState(PlayerBaseState state)
    {
        _subSet = state;
        _subSet.SetSuperState(this);
    }

}
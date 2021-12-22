using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using PlayerStateMachineScripts.States;
using UnityEngine;

public class PlayerStateFactory
{
    private PlayerStateMachine _psm;

    public PlayerStateFactory(PlayerStateMachine psm)
    {
        _psm = psm;
    }

    public PlayerBaseState Alive()
    {
        return new PlayerAliveState(_psm);
    }
    
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_psm);
    }

    public PlayerBaseState Run()
    {
        return new PlayerRunState(_psm);
    }

    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_psm);
    }
    
    public PlayerBaseState Rotate()
    {
        return new PlayerRotateState(_psm);
    }

    public PlayerBaseState Die()
    {
        return new PlayerDieState(_psm);
    }
    
}

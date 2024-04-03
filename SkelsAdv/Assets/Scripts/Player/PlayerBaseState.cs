using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _playerStateFactory;

    public PlayerBaseState (PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
    {
        _ctx = currentContext;
        _playerStateFactory = playerStateFactory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchState();

    public abstract void InitializeSubState();

    void UpdateStates() {}

    protected void SwitchState(PlayerBaseState newState)
    {
        //Current state exits
        ExitState();
    
        //Then enters new state
    
        newState.EnterState();
        _ctx.currentState = newState;
    }
    
    protected void SetSuperState() {}
    
    protected void SetSubState() {}
}


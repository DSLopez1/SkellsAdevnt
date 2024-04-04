using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected bool _isRootState = false;
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _playerStateFactory;
    protected PlayerBaseState _superState;
    protected PlayerBaseState _subState;

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

    public void UpdateStates()
    {
        UpdateState();
        if (_subState != null)
        {
            _subState.UpdateStates();
        }
    }

    protected void SwitchState(PlayerBaseState newState)
    {
        //Current state exits
        ExitState();
    
        //Then enters new state
    
        newState.EnterState();

        if (_isRootState)
        {
            _ctx.currentState = newState;
        }
        else if (_superState != null)
        {
            _superState.SetSubState(newState);
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        _superState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState)
    {
        _subState = newSubState;
        newSubState.SetSuperState(this);
    }
}


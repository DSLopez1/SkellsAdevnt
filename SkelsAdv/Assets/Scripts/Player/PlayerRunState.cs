using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
        : base(playerStateMachine, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Hello from run state");
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _ctx._velocity.x = _ctx._inputx * _ctx._movementSpeed;
        _ctx._velocity.z = _ctx._inputz * _ctx._movementSpeed;
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
        if (!_ctx._ismoving)
        {
            SwitchState(_playerStateFactory.Idle());
        }
    }

    public override void InitializeSubState()
    {
    }
}

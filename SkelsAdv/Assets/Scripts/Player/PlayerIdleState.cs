using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
        : base(playerStateMachine, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Idle");
        _ctx._velocity = Vector3.zero;
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
        //if movement is detected switch to move state
        if (_ctx._ismoving)
        {
            SwitchState(_playerStateFactory.Run());
        }
        //if jump is pressed switch to jump state
        if (_ctx._isJumping)
        {
            SwitchState(_playerStateFactory.Jump());
        }
    }

    public override void InitializeSubState()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
    :base (playerStateMachine, playerStateFactory)
    {
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
    }

    public override void InitializeSubState()
    {
    }

    void HandleJump()
    {
        if (_ctx._isJumping)
        {
            _ctx._velocity.y = _ctx._jumpForce;
            _ctx._isJumping = false;
        }
    }
}

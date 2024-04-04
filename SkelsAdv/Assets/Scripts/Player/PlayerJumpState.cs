using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
    :base (playerStateMachine, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState()
    {
        Debug.Log("Jump");
        HandleJump();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _ctx._velocity.y += _ctx._gravity * Time.deltaTime;

        _ctx._velocity.x = _ctx._inputx * _ctx._movementSpeed;
        _ctx._velocity.z = _ctx._inputz * _ctx._movementSpeed;
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
        if (_ctx._controller.isGrounded)
        {
            SwitchState(_playerStateFactory.Grounded());
        }
    }

    public override void InitializeSubState()
    {
    }

    void HandleJump()
    {
        _ctx._velocity.y = _ctx._jumpForce;
        _ctx._gravity = _ctx._jumpGravity;
    }
}

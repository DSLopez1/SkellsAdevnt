using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{ 
    public PlayerGroundState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
    :base (playerStateMachine, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState()
    {
        Debug.Log("Grounded");
        _ctx._gravity = -1;
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        _ctx._velocity.y = _ctx._gravity;
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
        //if jump is pressed switch to jump state
        if (_ctx._isJumping)
        {
            SwitchState(_playerStateFactory.Jump());
        }
    }

    public override void InitializeSubState()
    {
        if (!_ctx._ismoving)
        {
            SetSubState(_playerStateFactory.Idle());
        }

        else if (_ctx._ismoving)
        {
            SetSubState(_playerStateFactory.Run());
        }
    }
}

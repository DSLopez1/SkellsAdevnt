using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{ public PlayerGroundState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory)
    :base (playerStateMachine, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Grounded");
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
        if (_ctx._inputVector != Vector2.zero)
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

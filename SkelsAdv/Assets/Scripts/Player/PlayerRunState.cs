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
    }

    public override void ExitState()
    {
    }

    public override void CheckSwitchState()
    {
        if (!_ctx._ismoving)
        {
            SwitchState(_playerStateFactory.Grounded());
        }
    }

    public override void InitializeSubState()
    {
    }
}

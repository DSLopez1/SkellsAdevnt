using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Grounded()
    {
        return new PlayerGroundState(_context, this);
    }

    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(_context, this);
    }

    public PlayerBaseState Run()
    {
        return new PlayerRunState(_context, this);
    }

    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }
}

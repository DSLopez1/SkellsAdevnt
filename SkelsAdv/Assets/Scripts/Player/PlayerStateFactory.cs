using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    PlayerStateMachine _context;

    PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBaseState Grounded()
    {
        return new PlayerGroundState();
    }

    public PlayerBaseState Jump()
    {
        return new PlayerJumpState();
    }
}

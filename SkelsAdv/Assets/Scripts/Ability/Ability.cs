using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public float activeTime;
    public float castTime;
    public float cooldownTime;

    protected GameObject _player;

    public virtual void Activate()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Casting()
    {}

    public virtual void PostCast()
    {}
}

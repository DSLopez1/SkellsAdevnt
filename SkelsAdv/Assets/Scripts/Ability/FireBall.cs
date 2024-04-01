using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability
{
    public int damage;
    public GameObject fireBallPrefab;

    public override void Activate()
    {
        base.Activate();
        GameObject fireBall = Instantiate(fireBallPrefab, _player.transform.position, Quaternion.identity);
    }

}

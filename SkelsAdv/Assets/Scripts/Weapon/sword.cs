using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class sword : MonoBehaviour
{
    private  int damage = 10;
    private float multiplier = .5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        IDamage dmg = other.GetComponent<IDamage>();

        if (dmg != null)
        {
            //dmg.TakeDamage(calculateDamage());
        }
    }

    //private int calculateDamage()
    //{
    //    int multi = (int)((float)GameManager.Instance.playerAttackScript.physPower * multiplier);

    //    return damage + multi;
    //}
}

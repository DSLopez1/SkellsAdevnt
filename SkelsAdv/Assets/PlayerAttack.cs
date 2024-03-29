using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour, IDamage
{
    [Header("Health Settings")]
    public int HP;

    [Header("Components")] 
    public GameObject sword;
    private Collider _swordCollider;

    [Header("Attack Settings")]
    public float attackSpeed = 1f;
    public float physPower = 10f;
    public float magicPower = 10f;

    private Animator _anim;

    private bool _isAttacking = false;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _swordCollider = sword.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isAttacking)
        {
            StartCoroutine(attack());
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    IEnumerator attack()
    {
        _isAttacking = true;
        GameManager.instance.playerMovementScript.canRotate = false;
        _anim.SetTrigger("attack");
        yield return new WaitForSeconds(attackSpeed);
        GameManager.instance.playerMovementScript.canRotate = true;
        _isAttacking = false;
    }

    private void TurnOnSwordCollider()
    {
        _swordCollider.enabled = true;
    }

    private void TurnOffSwordCollider()
    {
        _swordCollider.enabled = false;
    }

    private void RotateSword()
    {
        sword.transform.Rotate(-270, 0, 0);
    }

    private void reverseRotation()
    {
        sword.transform.Rotate(270, 0, 0);
    }

}

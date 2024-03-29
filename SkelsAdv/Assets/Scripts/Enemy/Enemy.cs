using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    [Header("Components")]
    [SerializeField] private Animator _anim;

    [Header("Enemy Stats")]

    [SerializeField] private float _health = 100f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _damage = 10f;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _anim.SetTrigger("takeDamage");
        if (_health <= 0)
        {
            _anim.SetTrigger("die");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

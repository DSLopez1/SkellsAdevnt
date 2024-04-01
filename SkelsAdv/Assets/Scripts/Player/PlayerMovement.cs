using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPhysics
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float gravity = 9.81f;
    public bool isGrounded;

    private CharacterController _controller;
    private Animator _anim;
    private Vector3 _velocity;
    private Vector3 _pushBack;

    [Header("Dash stats")]
    public float dashForce = 10f;
    public float dashCooldown = 2f;
    public float physicsResolve = 0.1f;

    private bool _isDashing;

    public bool canRotate;

    private void Start()
    {
        canRotate = true;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movePlayer();
    }


    //Moves the player
    private void movePlayer()
    {
        _pushBack = Vector3.Lerp(_pushBack, Vector3.zero, physicsResolve * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _anim.SetFloat("speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;

        if (_controller.isGrounded)
        {
            isGrounded = true;
            _anim.SetBool("jumping", false);
            _velocity.y = -3;
            if (Input.GetButtonDown("Jump"))
            {
                _velocity.y = jumpForce;
                _anim.SetBool("jumping", true);
            }
        }
        else
        {
            isGrounded = false;

            if (Input.GetButtonDown("Jump") && !_isDashing)
            {
                StartCoroutine(Dash());
            }

        }

        _velocity.y -= gravity * Time.deltaTime;
        velocity.y = _velocity.y;

        _controller.Move((velocity + _pushBack) * Time.deltaTime);

        if ((horizontal != 0 || vertical != 0) && canRotate)
        {
            rotatePlayer();
        }  
    }

    IEnumerator Dash()
    {
        _isDashing = true;
        _anim.SetTrigger("dash");
        AddForce(gameObject.transform.forward * dashForce);
        yield return new WaitForSeconds(dashCooldown);
        _isDashing = false;
    }

    private void rotatePlayer()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetRotation, 10 * Time.deltaTime);
    }

    public void AddForce(Vector3 force)
    {
        _pushBack += force;
    }
}

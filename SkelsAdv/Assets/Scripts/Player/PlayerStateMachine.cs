using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Player Components")]
    CharacterController _controller;
    Animator _anim;

    [Header("PlayerStats")]
    [SerializeField] float _playerHealth = 100;
    [SerializeField] private float _movementSpeed = 10;

    [Header("JumpStats")]
    [SerializeField] float _jumpForce = 5;
    [SerializeField] int _maxJumps = 2;
    public bool _isJumping = false;

    [Header("DashStats")]
    [SerializeField] float _dashForce = 10;
    [SerializeField] float _dashCooldown = 2;
    [SerializeField] float _dashDuration = 0.5f;
    [SerializeField] private float _dashResolve = 0.1f;
    bool _isDashing = false;

    [Header("Rotation")]
    [SerializeField] float _rotationSpeed = 10;
    bool _canRotate = true;

    [Header("Physics")]
    [SerializeField] float _gravity = 9.81f;
    [SerializeField] float _physicsResolve = 0.1f;

    //Movement vectors
    Vector3 _velocity;
    Vector3 _pushBack;

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }

    void Start()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        _pushBack = Vector3.Lerp(_pushBack, Vector3.zero, _physicsResolve * Time.deltaTime);

        HandleRotation();
        _controller.Move((_velocity + _pushBack) * Time.deltaTime);
    }

    void HandleRotation()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.magnitude >= 0.1f && _canRotate)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}

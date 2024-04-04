using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Player Components")]
    public CharacterController _controller;
    public Animator _anim;
    public PlayerControl _input;

    public float _playerHealth = 100;

    [Header("PlayerMoveStats")]
    public float _movementSpeed = 10;
    public float _inputx;
    public float _inputz;
    public bool _ismoving = false;

    [Header("JumpStats")]
    public float _jumpForce = 5;
    public int _maxJumps = 2;
    public float _jumpGravity = -9.81f;
    public bool _isJumping = false;

    [Header("DashStats")]
    public float _dashForce = 10;
    public float _dashCooldown = 2;
    public  float _dashDuration = 0.5f;
    public  float _dashResolve = 0.1f;
    public bool _isDashing = false;

    [Header("Rotation")]
    public float _rotationSpeed = 1;
    public bool _canRotate = true;

    [Header("Physics")]
    public float _gravity = -9.81f;
    public float _physicsResolve = 0.1f;

    //Movement vectors
    public Vector2 _inputVector;
    public Vector3 _velocity;
    public Vector3 _pushBack;

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }

    void Awake()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _input = new PlayerControl();

        _input.BaseGrounded.Move.started += OnMovementInput;
        _input.BaseGrounded.Move.performed += OnMovementInput;
        _input.BaseGrounded.Move.canceled += OnMovementInput;
        _input.BaseGrounded.Jump.started += OnJump;
        _input.BaseGrounded.Jump.canceled += OnJump;
    }


    void Update()
    {
        _pushBack = Vector3.Lerp(_pushBack, Vector3.zero, _physicsResolve * Time.deltaTime);

        HandleRotation();
        _currentState.UpdateStates();
        _controller.Move((_velocity + _pushBack) * Time.deltaTime);
    }

    void HandleRotation()
    {
        Vector3 direction = new Vector3(_inputVector.x, 0, _inputVector.y);

        if (direction.magnitude >= 0.1f && _canRotate)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        _input.Enable();
    }

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
        _inputx = _inputVector.x;
        _inputz = _inputVector.y;
        _ismoving = _inputVector.x != 0 || _inputVector.y != 0;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _isJumping = context.ReadValueAsButton();
    }
}

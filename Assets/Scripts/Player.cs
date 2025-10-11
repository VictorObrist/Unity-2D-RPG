using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Header("Movement details")] 
    public float moveSpeed;
    public float jumpForce = 5;
    [Range(0f, 1f)]
    public float inAirMovementMultiplier = .7f; // should be from 0 to 1
    [Space]
    public float dashDuration = .25f;

    public float dashSpeed = 20;
    
   
    
    [Header("Collision detection")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [Range(0f, 1f)]
    public float wallSlideSlowMultiplier = .3f;
    [SerializeField] private LayerMask whatIsGround;
    
    
    #region PUBLIC VARIABLES
    public bool GroundDetected {get; private set;} 
    public bool WallDetected {get; private set;}
    public int FacingDirection { get; private set; } = 1;
    public Vector2 WallJumpForce;
    
    #region PLAYER STATES
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }
    public PlayerJumpState PlayerJumpState { get; private set; }
    public PlayerFallState PlayerFallState { get; private set; }
    public PlayerWallSlideState PlayerWallSlideState { get; private set; }
    public PlayerWallJumpState PlayerWallJumpState { get; private set; }
    public PlayerDashState PlayerDashState { get; private set; }
    #endregion
    public Vector2 MoveInput { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public PlayerInputSet PlayerInput {get; private set;}
    #endregion
    
    #region PRIVATE VARIABLES
    private StateMachine _stateMachine;
    private bool _isFacingRight = true;
    
    #endregion
    
    #region UNITY METHODS
    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
        _stateMachine = new StateMachine();
        PlayerInput = new PlayerInputSet();
        
        PlayerIdleState = new PlayerIdleState(this, _stateMachine, "idle");
        PlayerMoveState = new PlayerMoveState(this, _stateMachine, "move");
        PlayerJumpState = new PlayerJumpState(this, _stateMachine, "jumpFall");
        PlayerFallState = new PlayerFallState(this, _stateMachine, "jumpFall");
        PlayerWallSlideState = new PlayerWallSlideState(this, _stateMachine, "wallSlide");
        PlayerWallJumpState = new PlayerWallJumpState(this, _stateMachine, "jumpFall");
        PlayerDashState = new PlayerDashState(this, _stateMachine, "dash");
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
        
        PlayerInput.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        PlayerInput.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;
    }

    private void Start()
    {
        _stateMachine.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        HandleCollisionDetection();
        _stateMachine.UpdateActiveState();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance, 0));
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(wallCheckDistance * FacingDirection, 0, 0));
    }

    #endregion
    
    #region PUBLIC METHODS
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rigidbody2D.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }
    
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        _isFacingRight = !_isFacingRight;
        FacingDirection = FacingDirection * -1;
    }
    #endregion
   
    #region PRIVATE METHODS
    private void HandleFlip(float xVelocity)
    {
        if (xVelocity > 0 && !_isFacingRight)
            Flip();
        else if (xVelocity < 0 && _isFacingRight)
            Flip();
    }
    
    

    private void HandleCollisionDetection()
    {
        GroundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        WallDetected = Physics2D.Raycast(transform.position, Vector2.right * FacingDirection, wallCheckDistance, whatIsGround);
    }
    #endregion
} 

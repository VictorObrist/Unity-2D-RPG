using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }
    public Vector2 MoveInput { get; private set; }

    #endregion
    
    #region PRIVATE VARIABLES
    private StateMachine _stateMachine;
    private PlayerInputSet _playerInput;
    
    #endregion
    
    private void Awake()
    {
        _stateMachine = new StateMachine();
        _playerInput = new PlayerInputSet();
        
        PlayerIdleState = new PlayerIdleState(this, _stateMachine, "IdleState");
        PlayerMoveState = new PlayerMoveState(this, _stateMachine, "MoveState");
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        
        _playerInput.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        _playerInput.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;
        
        
    }

    private void Start()
    {
        _stateMachine.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        _stateMachine.UpdateActiveState();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
} 

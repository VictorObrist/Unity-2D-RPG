using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public StateMachine StateMachine { get; private set; }
    #endregion
    
    #region PRIVATE VARIABLES
    private EntityState idleState;
        
    #endregion
    private void Awake()
    {
        StateMachine = new StateMachine();
        idleState = new EntityState(StateMachine, "Idle State");
    }

    private void Start()
    {
        StateMachine.Initialize(idleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }
} 

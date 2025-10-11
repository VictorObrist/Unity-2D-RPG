using UnityEngine;

public abstract class EntityState
{
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");
    protected Player player;
    protected StateMachine StateMachine;
    protected string StateName;
    protected Animator Animator;
    protected Rigidbody2D Rigidbody2D;
    protected PlayerInputSet PlayerInput;
    protected float stateTimer;
    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.StateMachine = stateMachine;
        this.StateName = stateName;

        Animator = player.Animator;
        Rigidbody2D = player.Rigidbody2D;
        PlayerInput = player.PlayerInput;
    }

    public virtual void EnterState()
    {
        Animator.SetBool(StateName, true);
    }

    public virtual void UpdateState()
    {
        stateTimer -= Time.deltaTime;
        
        Animator.SetFloat(YVelocity, Rigidbody2D.linearVelocity.y);
        
        if (PlayerInput.Player.Dash.WasPressedThisFrame() && CanDash())
        {
            StateMachine.ChangeState(player.PlayerDashState);
        }
    }
    
    public virtual void ExitState()
    {
        Animator.SetBool(StateName, false);
    }

    private bool CanDash()
    {
        if (player.WallDetected)
            return false;

        if (StateMachine.CurrentState == player.PlayerDashState)
            return false;
        
        return true;
    }
}

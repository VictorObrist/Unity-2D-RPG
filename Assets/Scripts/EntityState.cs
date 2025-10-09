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
        Animator.SetFloat(YVelocity, Rigidbody2D.linearVelocity.y);
    }
    
    public virtual void ExitState()
    {
        Animator.SetBool(StateName, false);
    }
}

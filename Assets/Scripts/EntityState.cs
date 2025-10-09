using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine StateMachine;
    protected string StateName;
    
    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.StateMachine = stateMachine;
        this.StateName = stateName;
    }

    public virtual void EnterState()
    {
        Debug.Log($"Enter {StateName}");    
    }

    public virtual void UpdateState()
    {
        Debug.Log($"Update {StateName}");    
    }
    
    public virtual void ExitState()
    {
        Debug.Log($"Exit {StateName}");   
    }
}

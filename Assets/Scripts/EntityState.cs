using UnityEngine;

public class EntityState 
{
    protected StateMachine stateMachine;
    protected string stateName;
    
    public EntityState(StateMachine stateMachine, string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void EnterState()
    {
        Debug.Log($"Enter {stateName}");    
    }

    public virtual void UpdateState()
    {
        Debug.Log($"Update {stateName}");    
    }
    
    public virtual void ExitState()
    {
        Debug.Log($"Exit {stateName}");   
    }
}

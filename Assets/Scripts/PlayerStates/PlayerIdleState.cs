using UnityEngine;

public class PlayerIdleState : EntityState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, string stateName) 
        : base(player, stateMachine, stateName)
    {
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if (player.MoveInput.x != 0)
        {
            StateMachine.ChangeState(player.PlayerMoveState);
        }
    }
}

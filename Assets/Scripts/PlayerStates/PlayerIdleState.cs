using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, string stateName) 
        : base(player, stateMachine, stateName)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(0, Rigidbody2D.linearVelocity.y);
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

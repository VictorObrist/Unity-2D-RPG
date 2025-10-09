using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, StateMachine stateMachine, string stateName) 
        : base(player, stateMachine, stateName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (player.MoveInput == Vector2.zero)
        {
            StateMachine.ChangeState(player.PlayerIdleState);
        }
        
        player.SetVelocity(player.MoveInput.x * player.moveSpeed, Rigidbody2D.linearVelocity.y);
    }

}

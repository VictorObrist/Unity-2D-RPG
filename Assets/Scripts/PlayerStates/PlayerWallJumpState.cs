using UnityEngine;

public class PlayerWallJumpState : EntityState
{
    public PlayerWallJumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        
        player.SetVelocity(player.WallJumpForce.x * -player.FacingDirection, player.WallJumpForce.y);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (Rigidbody2D.linearVelocity.y < 0f)
        {
            StateMachine.ChangeState(player.PlayerFallState);
        }
        
        if (player.WallDetected)
        {
            StateMachine.ChangeState(player.PlayerWallSlideState);
        }
    }
}

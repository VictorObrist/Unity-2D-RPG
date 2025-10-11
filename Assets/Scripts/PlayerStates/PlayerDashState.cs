using UnityEngine;

public class PlayerDashState : EntityState
{
    private float originalGravityScale; 
    private int dashDirection;
    public PlayerDashState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        dashDirection = player.FacingDirection;
        stateTimer = player.dashDuration;
        originalGravityScale = Rigidbody2D.gravityScale;
        Rigidbody2D.gravityScale = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CancelDashIfNeeded();
        player.SetVelocity(player.dashSpeed * dashDirection,0);
        
        if (stateTimer < 0)
        {
            if(player.GroundDetected)
            {
                StateMachine.ChangeState(player.PlayerIdleState);
            }
            else
            {
                StateMachine.ChangeState(player.PlayerFallState);                
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        player.SetVelocity(0,0);
        Rigidbody2D.gravityScale = originalGravityScale;
    }
    
    private void CancelDashIfNeeded()
    {
        if (player.WallDetected)
        {
            if (player.GroundDetected)
            {
                StateMachine.ChangeState(player.PlayerIdleState);
            }
            else
            {
                StateMachine.ChangeState(player.PlayerWallSlideState);
            }
        }
    }
}

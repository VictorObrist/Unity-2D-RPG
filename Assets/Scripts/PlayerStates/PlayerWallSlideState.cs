using UnityEngine;

public class PlayerWallSlideState : EntityState
{
    public PlayerWallSlideState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        HandleWallSlide();

        if (!player.WallDetected)
        {
            StateMachine.ChangeState(player.PlayerFallState);    
        }
        
        if (player.GroundDetected)
        {
            StateMachine.ChangeState(player.PlayerIdleState);
            player.Flip();
        }
    }

    private void HandleWallSlide()
    {
        if (player.MoveInput.y < 0)
        {
            player.SetVelocity(player.MoveInput.x, Rigidbody2D.linearVelocity.y);
        }
        else
        {
            player.SetVelocity(player.MoveInput.x, Rigidbody2D.linearVelocity.y * player.wallSlideSlowMultiplier);
        }
    }
    
}

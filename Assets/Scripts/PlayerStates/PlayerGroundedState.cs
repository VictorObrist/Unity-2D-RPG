using UnityEngine;

//SuperState, share between idle, movement
public class PlayerGroundedState : EntityState
{
    public PlayerGroundedState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(Rigidbody2D.linearVelocity.y < 0 && player.GroundDetected == false)
            StateMachine.ChangeState(player.PlayerFallState);
        
        if (PlayerInput.Player.Jump.WasPerformedThisFrame())
        {
            StateMachine.ChangeState(player.PlayerJumpState);
        }
    }
}

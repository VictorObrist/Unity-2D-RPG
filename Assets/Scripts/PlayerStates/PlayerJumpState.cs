using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        
        player.SetVelocity(Rigidbody2D.linearVelocity.x, player.jumpForce);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (Rigidbody2D.linearVelocity.y < 0f)
        {
            StateMachine.ChangeState(player.PlayerFallState);
        }
    }
}

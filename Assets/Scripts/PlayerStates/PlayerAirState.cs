using UnityEngine;

public class PlayerAirState : EntityState
{
    public PlayerAirState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (player.MoveInput.x != 0)
        {
            player.SetVelocity(player.MoveInput.x * (player.moveSpeed * player.inAirMovementMultiplier), Rigidbody2D.linearVelocity.y);
        }
    }
}

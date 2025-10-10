using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (player.GroundDetected)
        {
            StateMachine.ChangeState(player.PlayerIdleState);
        }

        if (player.WallDetected)
        {
            StateMachine.ChangeState(player.PlayerWallSlideState);
        }
    }
}

using UnityEngine;

public class PlayerMoveState : EntityState
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
    }

}

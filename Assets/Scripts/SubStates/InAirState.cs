using UnityEngine;

namespace SubStates
{
    public class InAirState : PlayerState

    {
        public InAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            player.Rb.AddForce(new Vector2(player.InputHandler.NormInputX * playerData.WalkSpeed,0) * Time.deltaTime);

            if (Physics2D.OverlapCircle(player.GroundPoint.transform.position, 0.1f, player.groundLayer))
            {
                stateMachine.SwitchState(player.GroundState);
            }
        }
    }
}
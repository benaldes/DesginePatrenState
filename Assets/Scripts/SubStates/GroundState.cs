using UnityEngine;

namespace SubStates
{
    public class GroundState : PlayerState
    {
        public GroundState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            player.Rb.AddForce(new Vector2(player.InputHandler.NormInputX * playerData.WalkSpeed,0) * Time.deltaTime);

            if (player.InputHandler.JumpInput)
            {
                player.InputHandler.UseJumpInput();
                player.Rb.AddForce(new Vector2(0,playerData.JumpVelocity));
            }

            if (!Physics2D.OverlapCircle(player.GroundPoint.transform.position, 0.1f,player.groundLayer));
            {
                stateMachine.SwitchState(player.InAirState);
            }

            if (player.InputHandler.InteractInput)
            {
                player.InputHandler.InteractInput = false;
                player.Rb.AddForce(new Vector2(playerData.DashSpeed * player.InputHandler.NormInputX,0));
                
            }
        }
    }
}
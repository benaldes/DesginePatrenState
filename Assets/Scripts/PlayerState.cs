
    using UnityEngine;

    public abstract class PlayerState
    {
        #region Variables
        
        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        
        protected bool isExitingState;

        protected float startTime;
        
        protected int xInput;
        protected int yInput;
        protected bool SprintInput;
        protected bool jumpInput;
        protected bool jumpInputStop;
        
        #endregion

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
        }

        public virtual void Enter()
        {
            PhysicsUpdate();
            startTime = Time.time;
            isExitingState = false;
        }

        public virtual void Exit()
        {
            isExitingState = true;
        }

        public virtual void LogicUpdate()
        {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            SprintInput = player.InputHandler.SprintInput;
            jumpInputStop = player.InputHandler.JumpInputStop;
            
        }

        public virtual void PhysicsUpdate() { }
        
    }

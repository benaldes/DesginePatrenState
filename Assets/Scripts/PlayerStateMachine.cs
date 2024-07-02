using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    
    private Player Player;

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void SwitchState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        Debug.Log(CurrentState);
        CurrentState.Enter();
    }
}

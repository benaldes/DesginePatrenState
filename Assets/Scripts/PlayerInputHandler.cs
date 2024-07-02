using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler: MonoBehaviour
{
    public event Action OnInteract;
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool SprintInput { get; private set; }
    public bool InteractInput;
    
    [SerializeField] private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private float sprintInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInputStartTime = Time.time;
            JumpInput = true;
            JumpInputStop = false;
        }
        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnSprintInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SprintInput = true;
            sprintInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            SprintInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        
        
        if (context.started)
        {
            OnInteract?.Invoke();
            InteractInput = true;
        }
        if (context.canceled)
        {
            InteractInput = false;
        }
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time > jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    
}

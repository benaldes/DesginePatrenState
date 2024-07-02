using SubStates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    public Rigidbody2D Rb;
    public PlayerInputHandler InputHandler;
    public PlayerStateMachine StateMachine;
    public GroundState GroundState;
    public InAirState InAirState;
    public LayerMask groundLayer;
    public GameObject GroundPoint;
    public bool IsGrounded;
    private void OnValidate()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        GroundState = new GroundState(this, StateMachine, PlayerData);
        InAirState = new InAirState(this, StateMachine, PlayerData);



    }

    private void Start()
    {
        StateMachine.Initialize(GroundState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
    
  

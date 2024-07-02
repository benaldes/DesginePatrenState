using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")] 
    public float WalkSpeed = 10f;
    public float DashSpeed = 15;

    [Header("Jump State")] 
    public float JumpVelocity = 15f;
    

    
}
using UnityEngine;

public class PlayerOnAirState : PlayerBaseState
{
     public CharacterController controller;
    public float jumpHeight = 10 ;
    public float gravity = -9.8f * 3;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 
    public Transform groundCheck;
    UnityEngine.Vector3 velocity;
    bool isGrounded;
    public override void UpdateState(PlayerStateManager player){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);

        if (isGrounded){
            player.SwitchState(player.MovingState);
        } else{
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity*Time.deltaTime);
        }
        
        
    }
    public override void EnterState(PlayerStateManager player){
        controller = player.GetComponent<CharacterController>();
        groundMask = player.groundMask;
        groundCheck = player.groundCheck;
    }
}
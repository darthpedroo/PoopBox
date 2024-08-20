using UnityEngine;

public class PlayerOnAirState : PlayerBaseState
{
     public CharacterController controller;
    public float jumpHeight = 10 ;
    public float gravity = -9.8f * 3;
    public float groundDistance = 0.4f;
    public LayerMask groundMask; 
    public Transform groundCheck;
    private bool hasDoubleJumped;
    
    public override void UpdateState(PlayerStateManager player){
        
        player.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transforms gets the direction the player is moving so it moves locally and not globally
        Vector3 move = player.transform.right * x + player.transform.forward *z;

        controller.Move(move * player.speed * Time.deltaTime);

        if (player.isGrounded){
            player.SwitchState(player.MovingState);
        }

        player.velocity.y += gravity * Time.deltaTime;
        controller.Move(player.velocity*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !hasDoubleJumped){
            player.velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity);
            hasDoubleJumped = true;
            
        }
        
        
    }
    public override void EnterState(PlayerStateManager player){
        controller = player.GetComponent<CharacterController>();
        groundMask = player.groundMask;
        groundCheck = player.groundCheck;
        hasDoubleJumped = false;
    }
}
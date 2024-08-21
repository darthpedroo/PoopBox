using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    
    public CharacterController controller;
 

    
    public float gravity = -9.8f * 3;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 10 ;
    [SerializeField]
    public LayerMask groundMask; 
    private int ungroundedFrameCounter = 0; // Counter for frames not grounded
    private const int ungroundedFrameThreshold = 40; // Threshold for switching to OnAirState
    public override void UpdateState(PlayerStateManager player){

        player.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        
        if (!player.isGrounded){
            ungroundedFrameCounter++;
        } else {
            ungroundedFrameCounter = 0;
        }

        if (ungroundedFrameCounter > ungroundedFrameThreshold)
        {
            player.SwitchState(player.OnAirState);
            
        }

        // el siguiente codigo requiere que estes en el piso para ejecutarse
        if(player.velocity.y <0){
            player.velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transforms gets the direction the player is moving so it moves locally and not globally
        UnityEngine.Vector3 move = player.transform.right * x + player.transform.forward *z;

        controller.Move(move * player.speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space)){
            player.velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity);
        }

        player.velocity.y += gravity * Time.deltaTime;
        controller.Move(player.velocity*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && (x != 0 || z != 0)) {
            player.SwitchState(player.DashState);
        }
    }

    public override void EnterState(PlayerStateManager player){
        controller = player.GetComponent<CharacterController>();
        groundMask = player.groundMask;
        groundCheck = player.groundCheck;
        ungroundedFrameCounter = 0;
    }

    
}

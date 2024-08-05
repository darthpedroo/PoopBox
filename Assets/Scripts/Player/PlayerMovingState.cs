using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    
    public CharacterController controller;
    public float speed = 12f;

    UnityEngine.Vector3 velocity;
    public float gravity = -9.8f * 3;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumpHeight = 30 ;
    [SerializeField]
    public LayerMask groundMask; 
    bool isGrounded; 

    public override void UpdateState(PlayerStateManager player){

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);

        if(isGrounded && velocity.y <0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transforms gets the direction the player is moving so it moves locally and not globally
        UnityEngine.Vector3 move = player.transform.right * x + player.transform.forward *z;

        controller.Move(move *speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity);
        }
        


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && (x != 0 || z != 0)) {
            player.SwitchState(player.DashState);
        }
    }

    public override void EnterState(PlayerStateManager player){
        Debug.Log("Hello from Moving State");
        controller = player.GetComponent<CharacterController>();
        groundMask = player.groundMask;
        groundCheck = player.groundCheck;
    }

    
}

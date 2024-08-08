using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float maxDashTime = 0.1f; // segundos
    private float dashTime = 0;

    public Vector3 direction;
    public CharacterController controller;
    public float speed = 50f;
    public override void  UpdateState(PlayerStateManager player)
    {
        controller.Move(direction * speed * Time.deltaTime);
        dashTime += Time.deltaTime;
        
        
        if (maxDashTime <= dashTime){
            player.SwitchState(player.MovingState);
            
        }

    }

   
    public override void EnterState(PlayerStateManager player)
    {
        controller = player.GetComponent<CharacterController>();
        dashTime = 0;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = player.transform.right * x + player.transform.forward *z;
    }
}

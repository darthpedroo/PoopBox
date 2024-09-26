using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour, IEater
{

    public PlayerBaseState currentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerDashState DashState = new PlayerDashState();
    public PlayerOnAirState OnAirState = new PlayerOnAirState();
    public LayerMask groundMask; //Esto es medio troll , ver si no se puede hace run setter desde PlayerMoving
    public Transform groundCheck;
    public Vector3 velocity;
    public float speed = 20f;
    public bool isGrounded;
    
    
    void Start()
    {
        currentState = MovingState;
        currentState.EnterState(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    
    void OnValidate(){
        currentState = MovingState;
        currentState.EnterState(this);
    }
    public void SwitchState(PlayerBaseState state){
        currentState = state;
        state.EnterState(this);

    }

    public void Eat(float hunger, float health)
    {
        Debug.Log("Me he heleado");
    }
}

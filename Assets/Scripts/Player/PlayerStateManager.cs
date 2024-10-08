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
    public bool isGrounded;

    // CARACTERISTICAS COMO TAL:
    public float speed = 20f;
    public float resistencia = 0;
    public int Health = 1000;
    public float Hunger = 10;

    public int Carisma = 5;

    public int BenchPress = 225;

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

    void OnValidate() {
        currentState = MovingState;
        currentState.EnterState(this);
    }
    public void SwitchState(PlayerBaseState state) {
        currentState = state;
        state.EnterState(this);

    }

    public void Eat(float hunger, float health)
    {
        //Debug.Log("Me he heleado");
    }

    public void Attack(){

    }

    
}

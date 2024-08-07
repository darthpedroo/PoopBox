using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    public PlayerBaseState currentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerDashState DashState = new PlayerDashState();
    public LayerMask groundMask; //Esto es medio troll , ver si no se puede hace run setter desde PlayerMoving
    public Transform groundCheck;

    
    void Start()
    {
        currentState = MovingState;
        Debug.Log("ENTERING");
        currentState.EnterState(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state){
        currentState = state;
        state.EnterState(this);

    }
}

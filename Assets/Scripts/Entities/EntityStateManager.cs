using System.Collections;
using System.Collections.Generic;

using Codice.Client.BaseCommands.BranchExplorer;

using UnityEngine;

public class EntityStateManager : MonoBehaviour
{

    public Rigidbody entityRigidbody; 
    public float speed =10f;
    public EntityBaseState currentState;
    public EntityIdleState idleState = new EntityIdleState();
    public EntityWanderingState wanderingState = new EntityWanderingState();

    public EntityTestState testState = new EntityTestState();


    // Start is called before the first frame update
    void Start()
    {
        entityRigidbody = GetComponent<Rigidbody>();
        currentState = testState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}

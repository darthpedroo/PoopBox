using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

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
        gameObject.AddComponent<ChopChop>();
        HealthObserver observer = gameObject.AddComponent<HealthObserver>();
        observer.SetUp(300,Death,"ChanchoPuto",3,new Vector3(0,1,0));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void Death(){
        Debug.Log("murio el chancho puto");
    }
}

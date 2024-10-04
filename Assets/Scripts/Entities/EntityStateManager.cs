using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

using Codice.Client.BaseCommands.BranchExplorer;

using UnityEngine;

public class EntityStateManager : MonoBehaviour
{

    public Rigidbody entityRigidbody; 
    public float speed = 1f;
    public EntityBaseState currentState;
    public EntityIdleState idleState = new EntityIdleState();
    public EntityWanderingState wanderingState = new EntityWanderingState();
    public EntityTestState testState = new EntityTestState();
    public List<Drop> drops;
    // Start is called before the first frame update
    void Start() {
        entityRigidbody = GetComponent<Rigidbody>();
        currentState = testState;
        currentState.EnterState(this);
        gameObject.AddComponent<ChopChop>();
        HealthObserver observer = gameObject.AddComponent<HealthObserver>();
        // Cuando se implemente deathState cambiar testState por el estado de muerte
        observer.SetUp(300, Die, "Chancho", 3, new Vector3(0,1,0));
    }

    void Die() {
        new DropTableBuilder().Add(drops).GetDropTable().SpawnDropsAt(transform.position);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

}

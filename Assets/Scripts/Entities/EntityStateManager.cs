using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateManager : MonoBehaviour
{

    private Rigidbody _entityRigidbody; 
    public float Speed;
    private EntityBaseState _currentState;
    private EntityIdleState _idleState = new EntityIdleState();
    private EntityWanderingState _wanderingState = new EntityWanderingState();
    private EntityTestState _testState = new EntityTestState();
    private EntityDeathState _entityDeathState = new EntityDeathState();
    public DropTable drops;
    // Start is called before the first frame update
    void Start() {
        _entityRigidbody = GetComponent<Rigidbody>();
        _currentState = _testState;
        _currentState.EnterState(this);
    }

    public void SetDropTable(DropTable dropTable){
        drops = dropTable;
    }

    public void Die() {
        _currentState = _entityDeathState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

}

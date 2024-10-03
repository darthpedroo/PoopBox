using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIdleState : EntityBaseState
{
    Vector3 CurrentEntityPosition;
    
    public override void UpdateState(EntityStateManager entity)
    {
        Debug.Log("mi estilo es ridiculo");
    }

    public override void EnterState(EntityStateManager entity)
    {
        // Store the X and Z positions when entering the Idle state
        CurrentEntityPosition = new Vector3(entity.transform.position.x, 0, entity.transform.position.z);
        Debug.Log("Entering Idle State");
    }
}

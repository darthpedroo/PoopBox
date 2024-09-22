using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWanderingState : EntityBaseState
{

    private float timeBetweenMove; 
    private Vector3 MoveRandomDirection()
    {
        float dir = Random.Range(1,2);
        float x = 0f;
        float z = 0f;

        if (dir == 1){
            x = Random.Range(0, 0.1f);
        }
        else {
            z = Random.Range(0, 0.1f);
        }
        Vector3 newMovementVector = new Vector3(x, 0, z);
        return newMovementVector;
    }

    private void SetDefaultRotation(EntityStateManager entity){
        entity.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public override void UpdateState(EntityStateManager entity)
    {
        timeBetweenMove = 0.0f;
        while (timeBetweenMove < 5.0f)
            {
            timeBetweenMove+= Time.deltaTime;
            Vector3 movement_vector = MoveRandomDirection();
            SetDefaultRotation(entity);
            entity.GetComponent<Rigidbody>().MovePosition(entity.transform.position + movement_vector*Time.deltaTime * entity.speed);
            }
    }

    public override void EnterState(EntityStateManager entity)
    {
        Debug.Log("Entering Wandering State");
    }


}

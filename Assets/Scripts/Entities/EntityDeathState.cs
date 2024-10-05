using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeathState : EntityBaseState
{
    public override void EnterState(EntityStateManager entity)
    {
        Vector3 newPosition = entity.transform.position;
        newPosition.y += 1f;
        entity.drops.SpawnDropsAt(newPosition);
        GameObject.Destroy(entity.gameObject);
    }

    public override void UpdateState(EntityStateManager entity){}
}

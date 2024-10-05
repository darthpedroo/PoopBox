using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuilderComponent : MonoBehaviour
{
    public EntityData EntityData;
    public Vector3 SpawnPosition;

    public void SpawnEntity()
    {
        EntityData.SpawnEntity(SpawnPosition);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private readonly List<Action<GameObject>> _modifications;
    private readonly List<GameObject> _entityPrefab;

    public Entity(List<Action<GameObject>> modifications, List<GameObject> prefab)
    {
        _entityPrefab = prefab;
        _modifications = modifications;
    }

    public void SpawnEntity(Vector3 position, Quaternion rotation, Vector3 scale, Vector3 billboardPos, int health, string displayName)
    {
        GameObject randomEntity = _entityPrefab[UnityEngine.Random.Range(0,_entityPrefab.Count)];
        GameObject entityObject = GameObject.Instantiate(randomEntity, position, rotation);
        ApplyModifications(entityObject);
        entityObject.transform.localScale = scale;
        SetUpHealthObserver(entityObject, health, displayName, billboardPos);
    }

    public void SpawnEntity(Vector3 position, Quaternion rotation, Vector3 scale, Vector3 billboardPos, int health, string displayName, Transform parent)
    {
        GameObject randomEntity = _entityPrefab[UnityEngine.Random.Range(0,_entityPrefab.Count)];
        GameObject entityObject = GameObject.Instantiate(randomEntity, position, rotation, parent);
        ApplyModifications(entityObject);
        entityObject.transform.localScale = scale;
        SetUpHealthObserver(entityObject, health, displayName, billboardPos);
    }

    private void ApplyModifications(GameObject entityObject)
    {
        foreach (var mod in _modifications)
        {
            mod.Invoke(entityObject);
        }
    }

    private void SetUpHealthObserver(GameObject entityObject, int health, string displayName, Vector3 billboardPos)
    {
        HealthObserver observer = entityObject.AddComponent<HealthObserver>();
        Action onDeath = entityObject.GetComponent<EntityStateManager>().Die;
        observer.SetUp(health, onDeath, displayName, 1, billboardPos);
    }
}

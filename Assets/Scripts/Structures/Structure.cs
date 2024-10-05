using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Structure
{
    private readonly List<System.Action<GameObject>> _modifications;
    private readonly List<GameObject> _structurePrefab;
    public Structure(List<System.Action<GameObject>> modification, List<GameObject> prefab){
        _structurePrefab = prefab;
        _modifications = modification;
    }

    public void PlaceStructure(Vector3 position, Quaternion rotation, Vector3 scale,Vector3 bilboardPos, int health, string displayName){
        GameObject randomPrefab = _structurePrefab[Random.Range(0,_structurePrefab.Count)];
        GameObject structureObject = GameObject.Instantiate(randomPrefab, position, rotation);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        structureObject.transform.localScale = scale;
        HealthObserver observer = structureObject.AddComponent<HealthObserver>();
        System.Action action = structureObject.GetComponent<StructureManager>().DestroySelf;
        observer.SetUp(health,action,displayName,1, bilboardPos);
    }
    public void PlaceStructure(Vector3 position, Quaternion rotation, Vector3 scale,Vector3 bilboardPos, int health, string displayName, Transform parent){
        GameObject randomPrefab = _structurePrefab[Random.Range(0,_structurePrefab.Count)];
        GameObject structureObject = GameObject.Instantiate(randomPrefab, position, rotation, parent);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        structureObject.transform.localScale = scale;
        HealthObserver observer = structureObject.AddComponent<HealthObserver>();
        System.Action action = structureObject.GetComponent<StructureManager>().DestroySelf;
        observer.SetUp(health,action,displayName,1, bilboardPos);
    }

}

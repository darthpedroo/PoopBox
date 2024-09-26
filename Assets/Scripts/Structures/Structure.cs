using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Structure2
{
    private readonly List<System.Action<GameObject>> _modifications;
    private readonly GameObject _structurePrefab;
    public Structure2(List<System.Action<GameObject>> modification, GameObject prefab){
        _structurePrefab = prefab;
        _modifications = modification;
    }

    public void PlaceStructure(Vector3 position, Quaternion rotation, Vector3 scale,Vector3 bilboardPos, int health, string displayName){
        GameObject structureObject = GameObject.Instantiate(_structurePrefab, position, rotation);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        structureObject.transform.localScale = scale;
        HealthObserver observer = structureObject.AddComponent<HealthObserver>();
        System.Action action = structureObject.GetComponent<StructureManager>().DestroySelf;
        observer.SetUp(health,action,displayName,1, bilboardPos);
    }
    public void PlaceStructure(Vector3 position, Quaternion rotation, Vector3 scale,Vector3 bilboardPos, int health, string displayName, Transform parent){
        GameObject structureObject = GameObject.Instantiate(_structurePrefab, position, rotation, parent);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        structureObject.transform.localScale = scale;
        HealthObserver observer = structureObject.AddComponent<HealthObserver>();
        System.Action action = structureObject.GetComponent<StructureManager>().DestroySelf;
        observer.SetUp(health,action,displayName,1, bilboardPos);
    }

}

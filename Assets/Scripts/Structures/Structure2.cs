using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure2
{
    private readonly List<System.Action<GameObject>> _modifications;
    private readonly GameObject _structurePrefab;
    public Structure2(List<System.Action<GameObject>> modification, GameObject prefab){
        _structurePrefab = prefab;
        _modifications = modification;
    }
    public void PlaceStructure(Vector3 position, Quaternion rotation, Vector3 scale, int health, string displayName){
        GameObject structureObject = GameObject.Instantiate(_structurePrefab, position, rotation);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        structureObject.GetComponent<StructureManager>().SetHealth(health);
        structureObject.transform.localScale = scale;
        GameObject healthBarPrefab = Resources.Load<GameObject>("Prefabs/HealthBar");
        GameObject healthBar = GameObject.Instantiate(healthBarPrefab, structureObject.transform);
        healthBar.GetComponentInChildren<Billboard>().SetDisplayName(displayName);
    }
}

using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

public class StructureBuilder 
{
    private readonly List<System.Action<GameObject>> _modifications;
    private readonly GameObject _structurePrefab;
    public StructureBuilder SetChopable(){
        _modifications.Add((structure) => structure.AddComponent<ChopChop>());
        return this;
    }
    public StructureBuilder SetSwordable(){
       // _modifications.Add((structure) => structure.AddComponent<Swordable>());
        return this;
    }
    public StructureBuilder SetShovable(){
        // _modifications.Add((structure) => structure.AddComponent<Shovable>());
        return this;
    }

    public StructureBuilder SetHealth(int health){
        _modifications.Add((structure) => structure.GetComponent<IHealth>().Health = health);
        return this;
    }

    public StructureBuilder (GameObject prefab){
        _structurePrefab = prefab;
        _modifications = new()
        {
            (structure) => structure.AddComponent<StructureInstance>()
        };
    }

    public GameObject PlaceStructure(Vector3 position, Quaternion rotation){
        GameObject structureObject = GameObject.Instantiate(_structurePrefab, position, rotation);
        foreach (var mod in _modifications){
            mod.Invoke(structureObject);
        }
        return structureObject;
    }
}

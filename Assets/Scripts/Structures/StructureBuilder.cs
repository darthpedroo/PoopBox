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

    public StructureBuilder SetDropTable(DropTable dropTable){
        _modifications.Add((structure) => structure.GetComponent<StructureManager>().SetDropTable(dropTable));
        return this;
    }
    public StructureBuilder (GameObject prefab){
        _structurePrefab = prefab;
        _modifications = new()
        {
            (structure) => structure.AddComponent<StructureManager>()
        };
    }

    public Structure2 GetStructure(){
        return new Structure2(_modifications, _structurePrefab);
    }
}

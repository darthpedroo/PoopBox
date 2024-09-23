using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tree
{
    private static readonly GameObject[] TreePrefab = Resources.LoadAll<GameObject>("Trees/Prefabs");
    private static StructureBuilder s_structureBuilder;
    private static readonly DropTable DropTable = new DropTableBuilder().Add(Resources.Load<ItemData>("Item/Materials/Wood"),3,3,100).GetDropTable();
    public static void SpawnStructure(Vector3 position,Vector3 scale){
        int random = Random.Range(0,TreePrefab.Length);
        GameObject prefab = TreePrefab[random];
        s_structureBuilder = new StructureBuilder(prefab).SetChopable();
        s_structureBuilder.SetDropTable(DropTable);
        s_structureBuilder.GetStructure().PlaceStructure(position, Quaternion.identity, scale, new Vector3(0,1,0),500, "Arbol");
    }
}

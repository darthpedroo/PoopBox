using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItemConstructor
{
    // Start is called before the first frame update
    //private CapsuleCollider collider;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    public GameObject objectReference;

    public FloorItemConstructor(Vector3 origin) {
        ConstructItemPrefab(origin);
        Axe DroppedItem = new Axe();

        PickableItem pickableItem = objectReference.GetComponent<PickableItem>();
        pickableItem.BaseItem = DroppedItem;
    }

    void ConstructItemPrefab(Vector3 origin) {
        GameObject FloorItemGameObject = ObjectInstantiator.InstantiatePrefab("Prefabs/FloorItemModel", origin, Quaternion.identity);
        objectReference = FloorItemGameObject;
    }
}

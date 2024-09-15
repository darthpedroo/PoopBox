using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItemConstructor
{
    // Start is called before the first frame update
    //private CapsuleCollider collider;
    //private MeshFilter meshFilter;
    //private MeshRenderer meshRenderer;

    private GameObject _objectReference;

    public FloorItemConstructor(Vector3 origin, ItemData item) {
        ConstructItemPrefab(origin);
        PickableItem pickableItem = _objectReference.GetComponentInChildren<PickableItem>();
        pickableItem.BaseItem = GameObject.Instantiate(item);
        pickableItem.BaseItem.Count = item.Count;
        pickableItem.ParentObject = _objectReference;
    }

    void ConstructItemPrefab(Vector3 origin) {
        GameObject FloorItemGameObject = ObjectInstantiator.InstantiatePrefab("Prefabs/FloorItemModel", origin, Quaternion.identity);
        _objectReference = FloorItemGameObject;
    }
}

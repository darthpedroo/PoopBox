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

    public FloorItemConstructor(Vector3 origin, ItemInstance item) {
        ConstructItemPrefab(origin);
        item.EquipItem(_objectReference);
        item.AddItemGUI(_objectReference.transform);
        PickableItem pickableItem = _objectReference.GetComponentInChildren<PickableItem>();
        pickableItem.BaseItem = item;
        pickableItem.ParentObject = _objectReference;
    }

    public FloorItemConstructor(Vector3 origin, ItemInstance item, Vector3 startVelocity){
        ConstructItemPrefab(origin);
        item.EquipItem(_objectReference);
        item.AddItemGUI(_objectReference.transform);
        if (_objectReference.TryGetComponent<Rigidbody>(out Rigidbody rb)){
            rb.velocity = startVelocity;
        }
        PickableItem pickableItem = _objectReference.GetComponentInChildren<PickableItem>();
        pickableItem.BaseItem = item;
        pickableItem.ParentObject = _objectReference;
    }

    void ConstructItemPrefab(Vector3 origin) {
        GameObject FloorItemGameObject = ObjectInstantiator.InstantiatePrefab("Prefabs/FloorItemModel", origin, Quaternion.identity);
        _objectReference = FloorItemGameObject;
    }
}

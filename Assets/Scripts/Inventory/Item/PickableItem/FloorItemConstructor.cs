using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItemConstructor
{
    private GameObject _objectReference;

    public FloorItemConstructor(Vector3 origin, ItemInstance item) {
        ConstructItemPrefab(origin);
        item.EquipItem(_objectReference);
        AddItemGUI(item,_objectReference.transform);
        PickableItem pickableItem = _objectReference.GetComponentInChildren<PickableItem>();
        pickableItem.BaseItem = item;
        pickableItem.ParentObject = _objectReference;
    }

    public FloorItemConstructor(Vector3 origin, ItemInstance item, Vector3 startVelocity){
        ConstructItemPrefab(origin);
        item.EquipItem(_objectReference);
        AddItemGUI(item,_objectReference.transform);
        if (_objectReference.TryGetComponent<Rigidbody>(out Rigidbody rb)){
            rb.velocity = startVelocity;
        }
        PickableItem pickableItem = _objectReference.GetComponentInChildren<PickableItem>();
        pickableItem.BaseItem = item;
        pickableItem.ParentObject = _objectReference;
    }

    void AddItemGUI(ItemInstance item, Transform parent){
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ItemInfoGUI");
        GameObject itemInfoGui = UnityEngine.Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f),parent);
        itemInfoGui.transform.position = parent.transform.position;
        itemInfoGui.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemInfoGui.layer = LayerMask.NameToLayer("holdLayer");
        itemInfoGui.GetComponentInChildren<TMPro.TMP_Text>().text = item.ItemName + " X" + item.Quantity;
    }

    void ConstructItemPrefab(Vector3 origin) {
        GameObject FloorItemGameObject = ObjectInstantiator.InstantiatePrefab("Prefabs/FloorItemModel", origin, Quaternion.identity);
        _objectReference = FloorItemGameObject;
    }
}

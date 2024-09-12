using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [SerializeField]
    protected Texture _itemSlotTexture;
    public GameObject ItemModel;
    public string Name;
    public int StackSize { get; set; }
    public int Count { get; set; }
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    public virtual void UseItem(Transform user){
        Debug.Log("Use item not implemented by " + Name);
    }

    public virtual void EquipItem(GameObject parentObject){
        GameObject itemObject = ObjectInstantiator.InstantiatePrefab("Prefabs/Axe", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        itemObject.transform.parent = parentObject.transform;
        itemObject.transform.position = parentObject.transform.position;
        itemObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemObject.layer = LayerMask.NameToLayer("holdLayer");
        _meshFilter = itemObject.GetComponent<MeshFilter>();
        _meshRenderer = itemObject.GetComponent<MeshRenderer>();
    }
}

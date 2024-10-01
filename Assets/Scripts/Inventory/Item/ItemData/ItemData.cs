using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "ScriptableObjects/Item", order = 3)]
public class ItemData : ScriptableObject, UItemData
{
    [SerializeField]
    protected Texture _itemSlotTexture;
    public GameObject ItemModel;
    [SerializeField]
    private string _name; 
    public string Name { get => _name; set => _name = value; } 

    [SerializeField]
    private int _stackSize; 
    public int StackSize { get => _stackSize; set => _stackSize = value; }
    public Vector3 ModelScale;

    public virtual void UseItem(Transform user){
        Debug.Log("Use item not implemented by " + Name);
        //throw new ItemBreakException();
    }

    public void RecursiveSetLayer(Transform obj, int newLayer) {
        obj.gameObject.layer = newLayer;
        Debug.Log(obj);

        foreach(Transform child in obj) {
            RecursiveSetLayer(child, newLayer);
        }
    }

    public virtual void EquipItem(GameObject parentObject){
        GameObject itemObject = Instantiate(ItemModel);
        itemObject.transform.localScale = ModelScale;
        itemObject.transform.parent = parentObject.transform;
        itemObject.transform.position = parentObject.transform.position;
        itemObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        RecursiveSetLayer(itemObject.transform, LayerMask.NameToLayer("holdLayer"));
    }
    public Texture GetItemTexture(){
        return _itemSlotTexture;
    }

    public virtual UItemData Construct(){
        return this;
    }

    public virtual void OnValidate(){
        if (StackSize < 1){
            StackSize = 1;
        }
        if (ModelScale.x < 1){
            ModelScale.x = 1;
        }
        if (ModelScale.y < 1){
            ModelScale.y = 1;
        }
        if (ModelScale.z < 1){
            ModelScale.z = 1;
        }
    }
}

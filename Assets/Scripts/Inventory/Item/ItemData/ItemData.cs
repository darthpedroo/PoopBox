using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "ScriptableObjects/Item", order = 3)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    protected Texture _itemSlotTexture;
    public GameObject ItemModel;
    public string Name;
    public int StackSize;
    public virtual void UseItem(Transform user){
        Debug.Log("Use item not implemented by " + Name);
    }

    public virtual void EquipItem(GameObject parentObject){
        GameObject itemObject = Instantiate(ItemModel);
        itemObject.transform.parent = parentObject.transform;
        itemObject.transform.position = parentObject.transform.position;
        itemObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemObject.layer = LayerMask.NameToLayer("holdLayer");  
    }
    public Texture GetItemTexture(){
        return _itemSlotTexture;
    }
}

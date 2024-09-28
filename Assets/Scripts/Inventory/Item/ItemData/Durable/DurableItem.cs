using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurableItem : UItemData
{

    private ItemData _item;
    private int _maxDurability;
    public DurableItem(ItemData item, int MaxDurability ,int CurrentDurability , int DurabilityOnUse ){
        _item = item;
    }
    public void UseItem(Transform user){
        _item.UseItem(user);
    }
    public void EquipItem(GameObject parentObject){
        _item.EquipItem(parentObject);
    }
    public Texture GetItemTexture(){
        return _item.GetItemTexture();
    }
    public string Name{get {return _item.Name;}}
    public int StackSize{get {return _item.StackSize;}}
    public UItemData Construct(){
        return this;
    }
}

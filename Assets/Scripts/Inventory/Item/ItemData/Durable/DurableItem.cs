using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurableItem : UItemData
{

    private ItemData _item;
    private readonly int _maxDurability;
    private readonly int _durabilityOnUse;
    private int _currentDurability;
    public int CurrentDurability {get; set;}
    public DurableItem(ItemData item, int maxDurability , int durabilityOnUse ){
        _item = item;
        _maxDurability = maxDurability;
        _durabilityOnUse = durabilityOnUse;
        _currentDurability = _maxDurability;
    }
    public void UseItem(Transform user){
        _item.UseItem(user);
        _currentDurability -= _durabilityOnUse;
        if (_currentDurability < 0){
            Debug.Log("Break");
        }
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
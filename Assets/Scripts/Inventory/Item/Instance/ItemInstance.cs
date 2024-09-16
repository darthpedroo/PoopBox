using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    private readonly ItemData _itemData;
    private int _quantity;

    public ItemInstance(ItemData item,int quantity){
        _quantity = quantity;
        _itemData = item;
    }

    public Texture GetItemTexture(){
        return _itemData.GetItemTexture();
    }

    public void EquipItem(GameObject currentItemGameObject) {
        _itemData.EquipItem(currentItemGameObject);
        if (ItemName == "Wood"){
            Debug.Log("Madera x"+ _quantity);
        }
    }
    public bool Stack(ItemInstance item){
        if (item.ItemName == ItemName){ // si son el mismo item, stackear
            if (item._quantity + _quantity <= _itemData.StackSize){
                _quantity += item._quantity;
                return true;
            } else {
                int remainingItemsToStack = item.StackSize - item._quantity;
                item._quantity = item.StackSize;
                item._quantity -= remainingItemsToStack;
            }
        } 
        return false;
    }

    public void UseItem(Transform user){
        _itemData.UseItem(user);
    }
    public string ItemName{
        get {return _itemData.name;}
    }
    public int StackSize{
        get {return _itemData.StackSize;}
    }
    public int Count{
        get {return _quantity;}
        set {
            _quantity = value == 0 ? throw new Exception(ItemName + " quantity cannot be zero") : value;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using UnityEngine;

public class ItemInstance
{
    protected readonly UItemData _itemData;
    protected int _quantity;
    public delegate void QuantityChanged();
    public event QuantityChanged OnQuantityChanged;
    public int Quantity { get { return _quantity; } protected set{_quantity = value; OnQuantityChanged?.Invoke();}}
    public string ItemName{get { return _itemData.Name; }}
    public ItemInstance(UItemData item, int quantity)
    {
        _quantity = quantity;
        _itemData = item;
    }
    public Texture GetItemTexture() {return _itemData.GetItemTexture();}

    public virtual void EquipItem(GameObject currentItemGameObject)
    {
        _itemData.EquipItem(currentItemGameObject);
    }
    public bool Stack(ItemInstance item)
    {
        int stackSize = _itemData.StackSize;
        if (item == this) // si son el mismo item, stackear
        {
            if (item._quantity + _quantity <= stackSize)
            {
                Quantity += item._quantity;
                return true;
            }
            else
            {
                int remainingItemsToStack = item._quantity + _quantity - stackSize;
                Quantity = stackSize;
                item._quantity = remainingItemsToStack;
            }
        }
        return false;
    }
    public virtual void UseItem(Transform user)
    {
        try{
            _itemData.UseItem(user);
        }  
        catch (ItemBreakException){
            Quantity -= 1;
            throw new ItemBreakException();
        }
    }
    public override bool Equals(object obj) {return obj is ItemInstance otraclase ? ItemName == otraclase.ItemName : false;}
    public override int GetHashCode() {return ItemName.GetHashCode();}
    // atencion el siguiente codigo ha sido escrito por TITO CALDERON
    public static bool operator ==(ItemInstance left, ItemInstance right)
    {
        // If both are null, return true
        if (left is null && right is null) return true;

        // If one is null, but not both, return false
        if (left is null || right is null) return false;

        // Return true if the fields match
        return left.ItemName == right.ItemName;
    }

    // Overload the != operator
    public static bool operator !=(ItemInstance left, ItemInstance right)
    {
        return !(left == right);
    }

}
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    private readonly UItemData _itemData;
    private int _quantity;
    public delegate void QuantityChanged();
    public event QuantityChanged OnQuantityChanged;
    public int Quantity { get { return _quantity; }}
    public string ItemName{get { return _itemData.Name; }}
    public ItemInstance(UItemData item, int quantity)
    {
        _quantity = quantity;
        _itemData = item.Construct();
    }
    public Texture GetItemTexture() {return _itemData.GetItemTexture();}

    public void EquipItem(GameObject currentItemGameObject)
    {
        _itemData.EquipItem(currentItemGameObject);

    }

    public bool Stack(ItemInstance item)
    {
        int stackSize = _itemData.StackSize;
        //Debug.Log(item == this);
        if (item == this) // si son el mismo item, stackear
        {
            if (item._quantity + _quantity <= stackSize)
            {
                _quantity += item._quantity;
                OnQuantityChanged?.Invoke();
                return true;
            }
            else
            {
                int remainingItemsToStack = item._quantity + _quantity - stackSize;
                _quantity = stackSize;
                OnQuantityChanged?.Invoke();
                item._quantity = remainingItemsToStack;
            }
        }
        return false;
    }


    public ItemInstance[] DivideIntoStacks()
    {
        List<ItemInstance> itemsDividedIntoStacks = new();
        int stackSize = _itemData.StackSize;
        int fullStacks = Mathf.FloorToInt((float)_quantity / stackSize);
        int excesStack = _quantity - (fullStacks * stackSize);

        for (int i = 0; i < fullStacks; i++)
        {
            ItemInstance newItem = new(_itemData, stackSize);
            itemsDividedIntoStacks.Add(newItem);
        }

        if (excesStack != 0)
        {
            _quantity = excesStack;
            itemsDividedIntoStacks.Add(this);
        }

        return itemsDividedIntoStacks.ToArray();
    }

    public void UseItem(Transform user)
    {
        _itemData.UseItem(user);
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

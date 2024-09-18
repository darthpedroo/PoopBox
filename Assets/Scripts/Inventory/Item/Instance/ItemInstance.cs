using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an instance of an item in the game, including its data and quantity.
/// </summary>
public class ItemInstance
{
    private readonly ItemData _itemData;
    private int _quantity;

    public ItemInstance(ItemData item, int quantity)
    {
        _quantity = quantity;
        _itemData = item;
    }


    public Texture GetItemTexture()
    {
        return _itemData.GetItemTexture();
    }

    public void EquipItem(GameObject currentItemGameObject)
    {
        _itemData.EquipItem(currentItemGameObject);
        if (ItemName == "Wood")
        {
            Debug.Log("Madera x" + _quantity);
        }
    }

    public bool Stack(ItemInstance item)
    {
        int StackSize = _itemData.StackSize;
        //Debug.Log(item == this);
        if (item == this) // si son el mismo item, stackear
        {
            if (item._quantity + _quantity <= StackSize)
            {
                _quantity += item._quantity;
                return true;
            }
            else
            {
                int remainingItemsToStack = item._quantity + _quantity - StackSize;
                _quantity = StackSize;
                item._quantity = remainingItemsToStack;
            }
        }
        return false;
    }


    public ItemInstance[] DivideIntoStacks()
    {
        List<ItemInstance> itemsDividedIntoStacks = new();
        int StackSize = _itemData.StackSize;
        int FullStacks = Mathf.FloorToInt((float)_quantity / StackSize);
        int ExcesStack = _quantity - (FullStacks * StackSize);

        for (int i = 0; i < FullStacks; i++)
        {
            ItemInstance newItem = new ItemInstance(_itemData, StackSize);
            itemsDividedIntoStacks.Add(newItem);
        }

        if (ExcesStack != 0)
        {
            _quantity = ExcesStack;
            itemsDividedIntoStacks.Add(this);
        }

        return itemsDividedIntoStacks.ToArray();
    }

    public void UseItem(Transform user)
    {
        _itemData.UseItem(user);
    }

    public string ItemName
    {
        get { return _itemData.name; }
    }

    public override bool Equals(object obj)
    {
        if (obj is ItemInstance otraclase)
        {
            
            return ItemName == otraclase.ItemName;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ItemName.GetHashCode();
    }
    // atencion el siguiente codigo ha sido escrito por TITO CALDERON
    public static bool operator ==(ItemInstance left, ItemInstance right)
    {
        // If both are null, return true
        if (ReferenceEquals(left, right)) return true;

        // If one is null, but not both, return false
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

        // Return true if the fields match
        return left.ItemName == right.ItemName;
    }

    // Overload the != operator
    public static bool operator !=(ItemInstance left, ItemInstance right)
    {
        return !(left == right);
    }

}

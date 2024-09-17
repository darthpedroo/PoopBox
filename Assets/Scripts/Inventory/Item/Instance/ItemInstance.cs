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

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemInstance"/> class with specified item data and quantity.
    /// </summary>
    /// <param name="item">The data associated with the item.</param>
    /// <param name="quantity">The quantity of the item.</param>
    public ItemInstance(ItemData item, int quantity)
    {
        _quantity = quantity;
        _itemData = item;
    }

    /// <summary>
    /// Gets the texture associated with the item.
    /// </summary>
    /// <returns>The texture of the item.</returns>
    public Texture GetItemTexture()
    {
        return _itemData.GetItemTexture();
    }

    /// <summary>
    /// Equips the item to the specified game object.
    /// </summary>
    /// <param name="currentItemGameObject">The game object to equip the item to.</param>
    public void EquipItem(GameObject currentItemGameObject)
    {
        _itemData.EquipItem(currentItemGameObject);
        if (ItemName == "Wood")
        {
            Debug.Log("Madera x" + _quantity);
        }
    }

    /// <summary>
    /// Stacks this item instance with another item instance if they are the same type and the stack size allows.
    /// </summary>
    /// <param name="item">The item instance to stack with this instance.</param>
    /// <returns><c>true</c> if the items were successfully stacked; otherwise, <c>false</c>.</returns>
    public bool Stack(ItemInstance item)
    {
        int StackSize = _itemData.StackSize;
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

    /// <summary>
    /// Divides the current item instance into multiple stacks based on the maximum stack size.
    /// </summary>
    /// <returns>An array of <see cref="ItemInstance"/> representing the divided stacks.</returns>
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

    /// <summary>
    /// Uses the item with the specified user.
    /// </summary>
    /// <param name="user">The user who is using the item.</param>
    public void UseItem(Transform user)
    {
        _itemData.UseItem(user);
    }

    /// <summary>
    /// Gets the name of the item.
    /// </summary>
    /// <value>The name of the item.</value>
    public string ItemName
    {
        get { return _itemData.name; }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current item instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><c>true</c> if the specified object is equal to the current item instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object obj)
    {
        if (obj is ItemInstance otraclase)
        {
            return (ItemName == otraclase.ItemName);
        }
        return false;
    }

    /// <summary>
    /// Serves as a hash function for the item instance.
    /// </summary>
    /// <returns>A hash code for the current item instance.</returns>
    public override int GetHashCode()
    {
        return ItemName.GetHashCode();
    }
}

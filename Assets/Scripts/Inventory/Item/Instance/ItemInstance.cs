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
        int stackSize = _itemData.StackSize;
        //Debug.Log(item == this);
        if (item == this) // si son el mismo item, stackear
        {
            if (item._quantity + _quantity <= stackSize)
            {
                _quantity += item._quantity;
                return true;
            }
            else
            {
                int remainingItemsToStack = item._quantity + _quantity - stackSize;
                _quantity = stackSize;
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
            ItemInstance newItem = new ItemInstance(_itemData, stackSize);
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

    public void AddItemGUI(Transform user){
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ItemInfoGUI");
        GameObject itemInfoGui = UnityEngine.Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f),user);
        itemInfoGui.transform.position = user.transform.position;
        itemInfoGui.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemInfoGui.layer = LayerMask.NameToLayer("holdLayer");
        itemInfoGui.GetComponentInChildren<TMPro.TMP_Text>().text = ItemName + " X" + _quantity;
    }


    private string ItemName
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

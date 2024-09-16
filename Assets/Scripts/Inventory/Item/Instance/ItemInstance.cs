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
        set {_quantity = value;}
    }
}


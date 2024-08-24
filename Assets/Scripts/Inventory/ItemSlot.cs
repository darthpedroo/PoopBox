using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public ItemManager itemManagerSlot;
    //public ItemManager.ItemType currentItemType; 
    public Item itemClass;

    public void UpdateImage(){
        RawImage slotimage = GetComponent<RawImage>();
        if (slotimage != null) {
            slotimage.texture = itemClass.GetItemTexture;
        }
    }

    public void Switch(Item newItem) {
        itemClass = newItem;
        UpdateImage();
    }

    public void Equip(GameObject CurrentItemGameObject) {
        itemClass.equipItem(CurrentItemGameObject);
    }

    public void Use() {
        itemClass.useItem();
    }

}

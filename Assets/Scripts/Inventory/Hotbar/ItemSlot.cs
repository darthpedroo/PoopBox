using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public ItemManager itemManagerSlot;
    //public ItemManager.ItemType currentItemType; 
    public Item ItemClass;

    public void UpdateImage(){
        RawImage slotimage = GetComponent<RawImage>();
        if (slotimage != null) {
            slotimage.texture = ItemClass.GetItemTexture;
        }
    }

    public void Switch(Item newItem) {
        ItemClass = newItem;
        UpdateImage();
    }

    public void Equip(GameObject CurrentItemGameObject) {
        ItemClass.EquipItem(CurrentItemGameObject);
    }

    public void Use() {
        ItemClass.UseItem();
    }

}

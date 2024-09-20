using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public ItemManager itemManagerSlot;
    //public ItemManager.ItemType currentItemType; 
    public ItemInstance SlotItem;

    public void UpdateImage(){
        if (TryGetComponent<RawImage>(out var slotimage)) {
            Texture slotTexture = SlotItem.GetItemTexture();
            if (slotTexture != null){
                slotimage.texture = slotTexture;
            } 
            

        }
    }

    public void Switch(ItemInstance newItem) {
        SlotItem = newItem;
        UpdateImage();
    }

    public void Equip(GameObject currentItemGameObject) {
        SlotItem.EquipItem(currentItemGameObject);
    }

    public void Use(Transform user) {
        SlotItem.UseItem(user);
    }

}

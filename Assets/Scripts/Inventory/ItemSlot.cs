using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemManager itemManagerSlot;
    public ItemManager.ItemType currentItemType; 

    void Start()
    {
        itemManagerSlot.currentType = currentItemType;
        RawImage slotimage = GetComponent<RawImage>();
        if (slotimage){
            slotimage.texture = itemManagerSlot.currentItem.GetitemTexture;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

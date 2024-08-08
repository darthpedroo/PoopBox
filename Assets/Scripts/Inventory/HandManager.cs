using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public Canvas hotbar;
    private ItemSlot[] slots;
    void Start()
    {   
        slots = hotbar.GetComponentsInChildren<ItemSlot>();
        Debug.Log("Gyat");
        Debug.Log(slots[0].itemManagerSlot.currentItem);
        Debug.Log(slots[1].itemManagerSlot.currentItem);
        Debug.Log(slots[2].itemManagerSlot.currentItem);

        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for numeric key inputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem(0); // Equip item in slot 0
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipItem(1); // Equip item in slot 1
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipItem(2); // Equip item in slot 2
        }
    }

    void EquipItem(int slotIndex)
    {
        // Ensure the slot index is within range
        if (slotIndex >= 0 && slotIndex < slots.Length)
        {
            var itemSlot = slots[slotIndex];
            if (itemSlot.itemManagerSlot != null && itemSlot.itemManagerSlot.currentItem != null)
            {
                itemSlot.itemManagerSlot.currentItem.equipItem(gameObject);
                Debug.Log($"Equipped item from slot {slotIndex}");
            }
            else
            {
                Debug.LogWarning($"Item or ItemManagerSlot in slot {slotIndex} is null.");
            }
        }
        else
        {
            Debug.LogWarning($"Slot index {slotIndex} is out of range.");
        }
    }
}

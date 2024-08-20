using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public Canvas hotbar;
    private ItemSlot[] slots;
    public Transform cameraman;

    void Start()
    {   
        slots = hotbar.GetComponentsInChildren<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cameraman.rotation;
        // Check for numeric key inputs
        for (int i = 1; i < 9; i++) {
            string keyString = "Alpha" + i;
            if (Enum.TryParse<KeyCode>(keyString, out KeyCode key)) {
                if (Input.GetKeyDown(key)) {
                    EquipItem(i - 1);
                }
            }
        }
    }

    void EquipItem(int slotIndex)
    {
        // Try to find and destroy the first child object
        try
        {
            var childObject = transform.GetChild(0).gameObject;
            if (childObject)
            {
                Debug.Log("SEEK AND DESTROY");
                Destroy(childObject); // Destroy the child object
            }
        }
        catch
        {
            Debug.Log("OBJECT NOT FOUND");
        }

        // Equip the item from the selected slot
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

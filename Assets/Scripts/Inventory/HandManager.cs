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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipItem(2); // Equip item in slot 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EquipItem(2); // Equip item in slot 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            EquipItem(2); // Equip item in slot 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            EquipItem(2); // Equip item in slot 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            EquipItem(2); // Equip item in slot 2
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
                Destroy(childObject); // Destroy the child object
                Debug.Log("ITEM DESTROYED");
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

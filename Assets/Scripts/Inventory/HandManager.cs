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
    private int currentItemSlot; 
    public Transform cameraman;

    void Start()
    {   
        slots = hotbar.GetComponentsInChildren<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var itemSlot = slots[currentItemSlot];
            if (itemSlot.itemClass != null) {
                itemSlot.Use();
            }
            else
            {
                Debug.LogWarning($"Item or ItemManagerSlot in slot {currentItemSlot} is null.");
            }
        }

        transform.rotation = cameraman.rotation;
        // Check for numeric key inputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipItem(1); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipItem(3); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EquipItem(4); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            EquipItem(5); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            EquipItem(6); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            EquipItem(7); 
        }
    }

    void EquipItem(int newSlotIndex)
    {
        // Try to find and destroy the first child object
        if (currentItemSlot == newSlotIndex){
            return;
        }
        try
        {
            var childObject = transform.GetChild(0).gameObject;
            if (childObject)
            {
                Destroy(childObject); // Destroy the child object
            }
        }
        catch
        {
            Debug.Log("OBJECT NOT FOUND");
        }

        // Equip the item from the selected slot
        if (newSlotIndex >= 0 && newSlotIndex < slots.Length)
        {
            var itemSlot = slots[newSlotIndex];
            if (itemSlot.itemClass != null)
            {
                //Debug.Log(gameObject);
                itemSlot.Equip(gameObject);
            }
            else
            {
                Debug.LogWarning($"Item or ItemManagerSlot in slot {newSlotIndex} is null.");
            }
        }
        else
        {
            Debug.LogWarning($"Slot index {newSlotIndex} is out of range.");
        }
        currentItemSlot = newSlotIndex;
    }

    public bool ReceiveItem(Item item) {
        Debug.Log("gyatler");
        for (int i = 0; i < slots.Length; i++){
            if (slots[i].itemClass == null) {
                slots[i].Switch(item);
                return true;
            }
        }
        return false;
    }
}

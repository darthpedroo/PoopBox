using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public Canvas Hotbar;
    private ItemSlot[] _slots;
    private int _currentItemSlot; 
    public Transform Cameraman;
    private Hand _emptyHand;

    public RaycastHit hit;

    void Start()
    {   
        _emptyHand = new Hand();
        _slots = Hotbar.GetComponentsInChildren<ItemSlot>();
        _currentItemSlot = -1;
        EquipItem(0);

        ReceiveItem(new Axe());
    }

    // Update is called once per frame
    void Update()
    {
        showHitInfo();
        if (Input.GetMouseButtonDown(0))
        {
            var itemSlot = _slots[_currentItemSlot];
            if (itemSlot.ItemClass != null) {
                itemSlot.Use();
            }
            else
            {
                Debug.LogWarning($"Item or ItemManagerSlot in slot {_currentItemSlot} is null.");
            }
        }

        transform.rotation = Cameraman.rotation;
        


        // Check for numeric key inputs
        for (int i = 0; i < 8; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    EquipItem(i);
                    break; 
                }
            }

    }

    public void showHitInfo()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7.5f,LayerMask.GetMask("FloorItem"))){     
            Debug.Log("ITEM SUELO"); 
            Debug.Log(hit.collider);
        }
    }

    void EquipItem(int newSlotIndex)
    {
        // Try to find and destroy the first child object
        if (_currentItemSlot == newSlotIndex){
            return;
        }
        
        if (transform.childCount > 0){
            var childObject = transform.GetChild(0).gameObject;
            Destroy(childObject); 
        }

        var itemSlot = _slots[newSlotIndex];
        if (itemSlot.ItemClass == null) {
            itemSlot.Switch(_emptyHand);
        }

        itemSlot.Equip(gameObject);
        
        _currentItemSlot = newSlotIndex;
    }

    public bool ReceiveItem(Item item) {
        Debug.Log("Picked up item");
        for (int i = 0; i < _slots.Length; i++){
            if (_slots[i].ItemClass == null || _slots[i].ItemClass == _emptyHand) {
                _slots[i].Switch(item);

                if (i == _currentItemSlot) {
                    _slots[i].Equip(gameObject);
                }
                
                return true;
            }
        }
        return false;
    }
}

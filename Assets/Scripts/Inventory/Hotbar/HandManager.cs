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

    private ItemInstance _emptyHand;
    public RaycastHit Hit;

    void Start()
    {   
        _slots = Hotbar.GetComponentsInChildren<ItemSlot>();
        _currentItemSlot = -1;
        _emptyHand = new ItemInstance(Resources.Load<AxeData>("Item/Hand/Hand"),1);
        EquipItem(0);

    }

    // Update is called once per frame
    void Update()
    {
        showHitInfo();
        if (Input.GetMouseButtonDown(0))
        {
            var itemSlot = _slots[_currentItemSlot];
            itemSlot.Use(Cameraman);
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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 7.5f,LayerMask.GetMask("FloorItem"))){     
            Debug.Log("ITEM SUELO"); 
            Debug.Log(Hit.collider);
        }
    }

    void EquipItem(int newSlotIndex)
    {
        
        if (transform.childCount > 0){
            var childObject = transform.GetChild(0).gameObject;
            Destroy(childObject); 
        }

        var itemSlot = _slots[newSlotIndex];
        if (itemSlot.SlotItem == null) {
            itemSlot.Switch(_emptyHand);

        }
        itemSlot.Equip(gameObject);
        
        _currentItemSlot = newSlotIndex;
    }

    public bool ReceiveItem(ItemInstance item) {
        Debug.Log("Picked up item");
        bool isReceived = false; // 
        for (int i = 0; i < _slots.Length && !isReceived; i++){

            ItemInstance otherItem = _slots[i].SlotItem;
            if (otherItem == null || otherItem == _emptyHand) {
                _slots[i].Switch(item);
                if (i == _currentItemSlot) {
                    EquipItem(i);
                }
                isReceived = true;
                break;
            }
            else {
                isReceived = otherItem.Stack(item);
                if (isReceived){
                    break;
                }
            }
        }
        return isReceived;
    }
}

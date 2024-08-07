using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ItemManager : MonoBehaviour
{

    public enum ItemType{
        SWORD,
        AXE,
    }
    
    public Item currentItem;
    public ItemType currentType;
    
    void Start()
    {
        
        Debug.Log("CURRENT TYPE: ");
        Debug.Log(currentType);
        switch(currentType){
            case ItemType.SWORD:        
                currentItem = new Sword();
                currentItem.createObject(this.gameObject);
                Debug.Log("THE SPADE IS DONE");
                break;
            case ItemType.AXE:
                currentItem = new Axe();
                currentItem.createObject(this.gameObject);
                Debug.Log("THE AXE IS DONE");
                break;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentItem.useItem();
        }
    }
}

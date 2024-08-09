using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ItemManager : MonoBehaviour
{

    public enum ItemType{
        SWORD,
        AXE,
        EMPTY,
    }
    
    public Item currentItem;
    public ItemType currentType;
    
    void Start()
    {
        switch(currentType){
            case ItemType.SWORD:        
                currentItem = new Sword();
                currentItem.createObject(this.gameObject);
                break;
            case ItemType.AXE:
                currentItem = new Axe();
                currentItem.createObject(this.gameObject);
                break;
            case ItemType.EMPTY:
                currentItem = new Empty();
                //currentItem.createObject(gameObject);
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

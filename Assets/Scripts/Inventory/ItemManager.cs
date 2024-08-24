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
        CHEST,
    }
    
    public Item currentItem;
    private ItemType currentType;
    
    public ItemType CurrentType(){
        
        return currentType;

    }

    void Start()
    {
        currentType = gameObject.GetComponent<ItemSlot>().currentItemType;
        Debug.Log("Current Dop: ");
        Debug.Log(currentType);

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
                currentItem.createObject(gameObject);
                break;
            case ItemType.CHEST:
                currentItem = new Chest();
                currentItem.createObject(gameObject);
                break;

        }
    }

}

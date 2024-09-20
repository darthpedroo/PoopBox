using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public HandManager HandManager;
    private void OnTriggerEnter(Collider pickedUpItem) {
        IPickable floorItem = pickedUpItem.GetComponentInParent<IPickable>();
        ItemInstance item = floorItem.PickUp();
        bool isReceived = HandManager.ReceiveItem(item);
        //Debug.Log(isReceived);
        if (isReceived) 
        {Destroy(floorItem.ParentObject); } else
        {
            item.UpdateItemGUI(pickedUpItem.transform.parent);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public HandManager HandManager;
    private void OnTriggerEnter(Collider pickedUpItem) {
        IPickable floorItem = pickedUpItem.GetComponentInParent<IPickable>();
        if (floorItem != null) {
            ItemInstance item = floorItem.PickUp();
            bool isReceived = HandManager.ReceiveItem(item);
            if (isReceived)  {Destroy(floorItem.ParentObject); }  else { item.UpdateItemGUI(pickedUpItem.transform.parent);}
        }
    }
}

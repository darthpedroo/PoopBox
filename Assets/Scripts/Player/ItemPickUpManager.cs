using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public HandManager HandManager;
    private void OnTriggerEnter(Collider pickedUpItem) {
        IPickable floorItem = pickedUpItem.GetComponentInParent<IPickable>();
        bool isReceived = HandManager.ReceiveItem(floorItem.PickUp());
        //Debug.Log(isReceived);
        if (isReceived) {Destroy(floorItem.ParentObject);}
    }
}

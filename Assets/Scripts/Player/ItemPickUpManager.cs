using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public HandManager HandManager;
    private void OnTriggerEnter(Collider PickedUpItem) {
        IPickable floorItem = PickedUpItem.GetComponent<IPickable>();
        bool isReceived = HandManager.ReceiveItem(floorItem.PickUp());
        //if (isReceived) {Destroy(floorItem.objectReference);}
    }
}

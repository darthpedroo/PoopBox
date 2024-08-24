using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public HandManager HandManager;
    private void OnTriggerEnter(Collider PickedUpItem) {
        FloorItem floorItem = PickedUpItem.GetComponent<FloorItem>();
        bool isReceived = HandManager.ReceiveItem(floorItem.BaseItem);
        if (isReceived) {Destroy(floorItem.gameObject);}

    }
}

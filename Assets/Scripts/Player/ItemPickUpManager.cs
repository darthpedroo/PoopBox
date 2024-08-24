using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider PickedUpItem) {
        FloorItem item = PickedUpItem.GetComponent<FloorItem>();
        Debug.Log(item);
    }
}

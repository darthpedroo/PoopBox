using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IPickable
{
    public Item BaseItem;
    public Item PickUp() {
        return BaseItem;
    }
}

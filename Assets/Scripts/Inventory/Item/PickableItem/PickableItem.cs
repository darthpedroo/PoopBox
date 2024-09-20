using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IPickable
{
    public ItemInstance BaseItem;
    public ItemInstance PickUp() {
        return BaseItem;
    }
    public GameObject ParentObject{get;set;}
}

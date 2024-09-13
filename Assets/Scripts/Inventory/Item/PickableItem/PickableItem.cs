using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IPickable
{
    public ItemData BaseItem;
    public ItemData PickUp() {
        return BaseItem;
    }
    public GameObject ParentObject{get;set;}
}

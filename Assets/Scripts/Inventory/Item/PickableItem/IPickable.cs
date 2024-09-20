using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    ItemInstance PickUp();
    GameObject ParentObject {get;}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    ItemData PickUp();
    GameObject ParentObject {get;}

}

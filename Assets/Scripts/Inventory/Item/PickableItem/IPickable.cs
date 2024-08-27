using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    Item PickUp();
    GameObject ParentObject {get;}

}

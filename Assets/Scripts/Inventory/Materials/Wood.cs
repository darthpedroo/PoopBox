using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource
{
    public Wood(int startAmount) {
        itemCount = startAmount;
    }

    public override void equipItem(GameObject parentObject) {
        Debug.Log("Currently equipped: [Wood x" + Count + "]");
    }
}

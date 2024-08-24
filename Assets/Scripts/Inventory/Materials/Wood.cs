using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource
{
    public Wood(int startAmount) {
        itemCount = startAmount;
        StackSize = 64;
        createObject();
    }
    public override void equipItem(GameObject parentObject) {
        Debug.Log("Currently equipped: [Wood x" + Count + "]");
    }
    public override void createObject()
    {
        itemTexture = Resources.Load<Texture>("wood");
    }
}

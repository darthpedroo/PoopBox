using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : Item
{
    protected int itemCount;
    public int Count {
        get {return itemCount;}
    }

    public override void createObject() {}
    public override void useItem() {}
    public override void equipItem(GameObject parentObject) {}
}

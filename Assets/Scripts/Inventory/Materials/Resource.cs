using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : Item
{
    public override void CreateObject() {}
    public override void UseItem() {}
    public override void EquipItem(GameObject parentObject) {}
}

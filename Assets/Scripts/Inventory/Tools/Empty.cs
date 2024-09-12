using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : Item
{

    public Empty() {
        CreateObject();
    }

    public override void CreateObject()
    {
        _itemTexture = Resources.Load<Texture>("None");
    }

    public override void EquipItem(GameObject parentObject)
    {
        
    }

    public override void UseItem()
    {

    }

}

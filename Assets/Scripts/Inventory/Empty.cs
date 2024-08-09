using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : Item
{
    public override void createObject(GameObject parentObject)
    {
        itemTexture = Resources.Load<Texture>("None");
    }

    public override void equipItem(GameObject parentObject)
    {
        
    }

    public override void useItem()
    {

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sword : Tool
{
    

    public override void createObject(GameObject parentObject){
        Damage = 100;
        itemTexture = Resources.Load<Texture>("sword");
    }
        


    public override void useItem()
    {
        Debug.Log(itemTexture);
        Debug.Log(Damage);

    }


}

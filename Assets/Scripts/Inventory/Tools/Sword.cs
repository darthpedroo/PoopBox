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
        ToolDamage = 100;
        itemTexture = Resources.Load<Texture>("sword");
    }
        


    public override void useItem()
    {
        
    }

    public override void equipItem(GameObject parentObject)
    {
        GameObject swordObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        swordObject.transform.parent = parentObject.transform;
        swordObject.transform.position = parentObject.transform.position;
        swordObject.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
        swordObject.layer = LayerMask.NameToLayer("holdLayer");
        meshFilter = swordObject.GetComponent<MeshFilter>();
        meshRenderer = swordObject.GetComponent<MeshRenderer>();
    }

}

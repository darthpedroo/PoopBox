using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{
    
    public override void createObject(GameObject parentObject){

        Damage = 10;
        itemTexture = Resources.Load<Texture>("axe");
       
        
       
       // Canvas canvas = parentObject.GetComponentInChildren<Canvas>();
       // UnityEngine.UI.RawImage image = canvas.GetComponentInChildren<UnityEngine.UI.RawImage>();
       // Texture rawdog =  Resources.Load<Texture>("axe");
       // image.texture = rawdog;
    }

    public override void useItem()
    {


    }

    public override void equipItem(GameObject parentObject)
    {
        GameObject swordObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        swordObject.transform.parent = parentObject.transform;
        swordObject.transform.position = parentObject.transform.position;
        swordObject.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
        swordObject.layer = LayerMask.NameToLayer("holdLayer");
        meshFilter = swordObject.GetComponent<MeshFilter>();
        meshRenderer = swordObject.GetComponent<MeshRenderer>();
    }

}

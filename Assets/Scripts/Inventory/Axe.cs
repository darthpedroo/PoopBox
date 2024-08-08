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
        swordObject.transform.position = new Vector3(2.95f,4.91f,3.13f); //ES UNA POSICION ARBITRARIA PAAA QUE SE VA A LA DERECHA EL ITEM QUE TENES EN LA MANO :v
        meshFilter = swordObject.GetComponent<MeshFilter>();
        meshRenderer = swordObject.GetComponent<MeshRenderer>();
    }

}

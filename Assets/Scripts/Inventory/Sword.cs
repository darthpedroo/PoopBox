using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    
    public override void createObject(GameObject parentObject){
        Debug.Log("Creating a Sword");
        GameObject swordObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        swordObject.transform.parent = parentObject.transform;
        swordObject.transform.position = new Vector3(2.95f,4.91f,3.13f); //ES UNA POSICION ARBITRARIA PAAA QUE SE VA A LA DERECHA EL ITEM QUE TENES EN LA MANO :v
        meshFilter = swordObject.GetComponent<MeshFilter>();
        meshRenderer = swordObject.GetComponent<MeshRenderer>();

    }


    public override void useItem()
    {
        Debug.Log("Using the sword");

    }


}
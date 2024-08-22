using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class Tool : Item
{

    protected int _Damage;
    protected RaycastHit hit;
        
    public override void createObject(GameObject parentObject){
        
        //GameObject swordObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //swordObject.transform.parent = parentObject.transform;
        //swordObject.transform.position = new Vector3(2.95f,4.91f,3.13f); //ES UNA POSICION ARBITRARIA PAAA QUE SE VA A LA DERECHA EL ITEM QUE TENES EN LA MANO :v
        //meshFilter = swordObject.GetComponent<MeshFilter>();
        //meshRenderer = swordObject.GetComponent<MeshRenderer>();
      //  Canvas canvas = parentObject.GetComponentInChildren<Canvas>();
       // RawImage image = canvas.GetComponentInChildren<RawImage>();
    //    Texture rawdog =  Resources.Load<Texture>("sword");
    //  image.texture = rawdog;
    }
    
    public int Damage {
        get {return _Damage;}
    }


    public override void useItem()
    {

    }


}

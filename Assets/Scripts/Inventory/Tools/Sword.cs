using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sword : Tool
{
    
    public Sword() {
        CreateObject();
    }

    public override void CreateObject(){
        ToolDamage = 100;
        _itemTexture = Resources.Load<Texture>("sword");
    }
        


    public override void UseItem()
    {
        
    }

    public override void EquipItem(GameObject parentObject)
    {
        GameObject swordObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        swordObject.transform.parent = parentObject.transform;
        swordObject.transform.position = parentObject.transform.position;
        swordObject.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
        swordObject.layer = LayerMask.NameToLayer("holdLayer");
        MeshFilter = swordObject.GetComponent<MeshFilter>();
        MeshRenderer = swordObject.GetComponent<MeshRenderer>();
    }

}

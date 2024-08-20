using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{
    public override void createObject(GameObject parentObject)
    {
        Damage = 10;
        itemTexture = Resources.Load<Texture>("axe");
    }

    public override void useItem()
    {
        Debug.Log("o forchinaichi la lppapai");
    }

    public override void equipItem(GameObject parentObject)
    {
        // Use the static method from ObjectInstantiator to instantiate the axe
        GameObject axeObject = ObjectInstantiator.InstantiatePrefab("Prefabs/Axe", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        axeObject.transform.parent = parentObject.transform;
        axeObject.transform.position = parentObject.transform.position;
        axeObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        axeObject.layer = LayerMask.NameToLayer("holdLayer");

        meshFilter = axeObject.GetComponent<MeshFilter>();
        meshRenderer = axeObject.GetComponent<MeshRenderer>();
    }
}

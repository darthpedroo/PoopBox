using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Item
{
    public override void createObject(GameObject parentObject)
    {
        itemTexture = Resources.Load<Texture>("chest");
    }

    public override void useItem()
    {
    }

    public override void equipItem(GameObject parentObject) {
        GameObject axeObject = ObjectInstantiator.InstantiatePrefab("Prefabs/CHEST_CLOSED", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        axeObject.transform.parent = parentObject.transform;
        axeObject.transform.position = parentObject.transform.position;
        axeObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        axeObject.layer = LayerMask.NameToLayer("holdLayer");

        meshFilter = axeObject.GetComponent<MeshFilter>();
        meshRenderer = axeObject.GetComponent<MeshRenderer>();
    }
}

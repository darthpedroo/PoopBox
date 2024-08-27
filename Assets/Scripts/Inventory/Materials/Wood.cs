using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource
{
    public Wood(int startAmount) {
        
        name = "Wood";
        itemCount = startAmount;
        StackSize = 64;
        createObject();
    }
    public override void equipItem(GameObject parentObject) {
        Debug.Log("Currently equipped: [Wood x" + Count + "]");
        GameObject axeObject = ObjectInstantiator.InstantiatePrefab("Prefabs/Wood", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        axeObject.transform.parent = parentObject.transform;
        axeObject.transform.position = parentObject.transform.position;
        axeObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        axeObject.layer = LayerMask.NameToLayer("holdLayer");
        meshFilter = axeObject.GetComponent<MeshFilter>();
        meshRenderer = axeObject.GetComponent<MeshRenderer>();
        
    }
    public override void createObject()
    {
        itemTexture = Resources.Load<Texture>("wood");
        
    }
}

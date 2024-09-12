using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource, IStackable
{   
    
 
    public Wood(int startAmount) {
        
        Name = "Wood";
        Count = startAmount;
        StackSize = 64;
        CreateObject();
    }
    public override void EquipItem(GameObject parentObject) {
        Debug.Log("Currently equipped: [Wood x" + Count + "]");
        GameObject axeObject = ObjectInstantiator.InstantiatePrefab("Prefabs/Wood", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        axeObject.transform.parent = parentObject.transform;
        axeObject.transform.position = parentObject.transform.position;
        axeObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        axeObject.layer = LayerMask.NameToLayer("holdLayer");
        MeshFilter = axeObject.GetComponent<MeshFilter>();
        MeshRenderer = axeObject.GetComponent<MeshRenderer>();
        
    }
    public override void CreateObject()
    {
        _itemTexture = Resources.Load<Texture>("wood");
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Axe : Tool 
{
    readonly Transform transform = UnityEngine.Object.FindObjectOfType<Camera>().transform;
    

    
    public override void createObject(GameObject parentObject)
    {
        _Damage = 50;
        itemTexture = Resources.Load<Texture>("axe");

    }

    public override void useItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, LayerMask.GetMask("Interactable"))){      
            if (hit.collider.transform.parent.gameObject.GetComponent<Structure>().Health - Damage >= 0){
                hit.collider.transform.parent.gameObject.GetComponent<Structure>().TakeDamage(this, hit);
            } 
        }
        
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

    void Update(){
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*1000 , Color.red);
        Debug.Log("NOt a mono");
    }
}

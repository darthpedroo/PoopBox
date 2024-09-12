using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Tool
{
    readonly Transform transform = UnityEngine.Object.FindObjectOfType<Camera>().transform;
    
    public Hand() {
        CreateObject();
    }

    public override void CreateObject() {
        ToolDamage = 20;
    }

    public override void UseItem() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7.5f, LayerMask.GetMask("Interactable"))){      
            hit.collider.transform.gameObject.GetComponentInParent<IChopable>().TakeAxeDamage(ToolDamage, hit);
        }
    }

    public override void EquipItem(GameObject parentObject) {
        Debug.Log("Current active: Da HAND !!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

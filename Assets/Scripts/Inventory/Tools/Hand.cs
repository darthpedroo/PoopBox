using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Tool
{
    readonly Transform transform = UnityEngine.Object.FindObjectOfType<Camera>().transform;
    
    public Hand() {
        createObject();
    }

    public override void createObject() {
        ToolDamage = 10;
    }

    public override void useItem() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7.5f, LayerMask.GetMask("Interactable"))){      
            hit.collider.transform.parent.gameObject.GetComponent<IChopable>().TakeAxeDamage(this, hit);
        }
    }

    public override void equipItem(GameObject parentObject) {
        Debug.Log("Current active: Da HAND !!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

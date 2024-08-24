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

    public override void equipItem(GameObject parentObject) {

    }

    public override void useItem() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

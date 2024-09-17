using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolData : ItemData
{
    public int ToolDamage;
    
    public override void OnValidate(){
        if (ToolDamage < 0) {
            ToolDamage = 0;
        }
        if (StackSize < 1){
            StackSize = 1;
        }
    }
}

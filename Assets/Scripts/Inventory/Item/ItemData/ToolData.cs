using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolData : DurableItemData
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

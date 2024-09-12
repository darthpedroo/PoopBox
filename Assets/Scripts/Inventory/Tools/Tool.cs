using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class Tool : Item
{

    protected int ToolDamage;
    protected RaycastHit hit;
    public int Damage {
        get {return ToolDamage;}
    }
        
    public override void CreateObject() {}
    
    
    public override void UseItem(){}
}

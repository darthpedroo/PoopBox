using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDurable 
{
    public int MaxDurability {get; set;}
    public int CurrentDurability {get; set;}
    public int DurabilityOnUse {get; set;}
}

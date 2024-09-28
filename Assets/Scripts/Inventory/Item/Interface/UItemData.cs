using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UItemData 
{
    public abstract void UseItem(Transform user);
    public abstract void EquipItem(GameObject parentObject);
    public Texture GetItemTexture();
    public string Name{get;}
    public int StackSize{get;}
    public UItemData Construct();
}

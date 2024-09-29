using UnityEngine;

public interface IDurable 
{
    public int MaxDurability {get;}
    public int DurabilityOnUse {get;}
    public void EquipItemDurable(GameObject parent,int currentDurability);
}

using UnityEngine;

public class DurableItemData : ItemData 
{   
    public int DurabilityOnUse;
    public int MaxDurability;
    public virtual void EquipItemDurable(GameObject parent,int currentDurability){
        EquipItem(parent);
    }
    public override ItemInstance GetInstance(int quantity){
        return new DurableItemInstance(this,quantity);
    }
}

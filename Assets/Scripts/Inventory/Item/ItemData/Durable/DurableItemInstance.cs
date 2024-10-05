using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurableItemInstance : ItemInstance
{
    private readonly int _maxDurability;
    private readonly DurableItemData _durableItemData;
    private readonly int _durabilityOnUse;
    private int _currentDurability;
    public int CurrentDurability {get {return _currentDurability;} private set{_currentDurability = value; OnDurabilityChanged?.Invoke();}}
    public int MaxDurability {get {return _maxDurability;}}
    public delegate void DurabilityChanged();
    public event DurabilityChanged OnDurabilityChanged;
    public DurableItemInstance(DurableItemData item, int quantity)
        : base(item, quantity) 
    {
        _durableItemData = item;
        _maxDurability = _durableItemData.MaxDurability;
        _durabilityOnUse = _durableItemData.DurabilityOnUse;
        _currentDurability = _maxDurability;
    }
    public override void UseItem(Transform user){
        try{
            _itemData.UseItem(user);
        }
        catch (ItemNotUsedException) {
            return;
        }
        _currentDurability -= _durabilityOnUse;
        OnDurabilityChanged?.Invoke();
        if (_currentDurability < 1){
            Break();
        }
    }
    private void Break(){
        _currentDurability = _maxDurability;
        Quantity -= 1;
        throw new ItemBreakException();
    }

    public override void EquipItem(GameObject parentObject){
        _durableItemData.EquipItemDurable(parentObject, _currentDurability);
    }
}

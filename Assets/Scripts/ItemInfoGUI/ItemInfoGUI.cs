using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoGUI : MonoBehaviour
{
    private ItemInstance _itemInstance;
    public void SetUp(ItemInstance item){
        _itemInstance = item;
        _itemInstance.OnQuantityChanged += UpdateInfoGUI;
        UpdateInfoGUI();
    }
    public void UpdateInfoGUI(){
        GetComponentInChildren<TMP_Text>().text = _itemInstance.ItemName + " X" + _itemInstance.Quantity;
    }
    void OnDestroy(){
        _itemInstance.OnQuantityChanged -= UpdateInfoGUI;
    }
}

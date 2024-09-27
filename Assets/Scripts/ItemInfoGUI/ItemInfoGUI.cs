using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoGUI : MonoBehaviour
{
    private string ItemName;
    private int Quantity;
    public void SetUp(string Name,int Quantity, ){
        ItemName = Name;
        Quantity = Quantity;
    }
    public void UpdateInfoGUI(){
        itemInfoGui.GetComponentInChildren<TMPro.TMP_Text>().text = ItemName + " X" + Quantity;
    }
}

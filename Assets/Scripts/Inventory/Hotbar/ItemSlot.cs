using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEditor.Graphs;

using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //public ItemManager itemManagerSlot;
    //public ItemManager.ItemType currentItemType; 
    public ItemInstance SlotItem;
    private RawImage _image;
    private TMP_Text _text;
    void Start(){
        _image = GetComponent<RawImage>();
        _text = GetComponentInChildren<TMP_Text>();
    }
    private void UpdateImage(){
        Texture slotTexture = SlotItem.GetItemTexture();
        if (slotTexture != null){
            _image.texture = slotTexture;
        } 
    }

    public void UpdateText(){
        string textToDisplay = "";
        if (SlotItem.Quantity != 0){
            textToDisplay = SlotItem.Quantity.ToString();
        }
        _text.text = textToDisplay;
    }
    public void Switch(ItemInstance newItem) {
        SlotItem = newItem;
        UpdateImage();
        UpdateText();
    }

    public void Equip(GameObject currentItemGameObject) {
        SlotItem.EquipItem(currentItemGameObject);
    }

    public void Use(Transform user) {
        SlotItem.UseItem(user);
    }

}

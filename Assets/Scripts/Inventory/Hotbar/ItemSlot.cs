
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemInstance SlotItem;
    private RawImage _image;
    private TMP_Text _text;
    private Slider _slider;
    void Start(){
        _image = GetComponent<RawImage>();
        _text = GetComponentInChildren<TMP_Text>();
        _slider = GetComponentInChildren<Slider>();
        _slider.value = 0;
    }
    private void UpdateImage(){
        if (SlotItem == null){
            _image.texture = null;
        } else {
            Texture slotTexture = SlotItem.GetItemTexture();
            if (slotTexture != null){
                _image.texture = slotTexture;
            } 
        }
    }
    private void OnDestroy()
    {
        if (SlotItem != null)
        {
            SlotItem.OnQuantityChanged -= OnQuantityChanged; 
        }
    }
    private void UpdateText(){
        string textToDisplay = "";
        if (SlotItem != null && SlotItem.Quantity != 0){
            textToDisplay = SlotItem.Quantity.ToString(); 
        }
        
        _text.text = textToDisplay;
    }

    private void UpdateSlider(int currentDurability, int maxDurability){
        Debug.Log("papu");
        _slider.maxValue = maxDurability;
        _slider.value = currentDurability;
    }
   
    private void OnQuantityChanged(){
        if (SlotItem.Quantity == 0){
            Switch(null);
            throw new ItemBreakException();
        } else {
            UpdateText();
        }
        
    }
    public void Switch(ItemInstance newItem) {
        if (SlotItem != null)
        {
            // Unsubscribe from old item
            SlotItem.OnQuantityChanged -= OnQuantityChanged;
        }
        SlotItem = newItem;
        if (SlotItem != null)
        {
            // Subscribe to new item
            SlotItem.OnQuantityChanged += OnQuantityChanged;
        }
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

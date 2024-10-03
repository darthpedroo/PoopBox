
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemInstance SlotItem;
    private RawImage _image;
    private TMP_Text _text;
    private Slider _slider;
    private static Color s_maxDurabilityColor = Color.green;
    private static Color s_halfDurabilitColor = Color.yellow;
    private static Color s_lessThanHalfDurabilityColor = Color.red;
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

    private void UpdateSlider(){
        int sliderValue = 0;
        if (SlotItem != null && SlotItem is DurableItemInstance durableItem){
            _slider.maxValue = durableItem.MaxDurability;
            sliderValue = durableItem.CurrentDurability;
            float durabilityPercentage = (float)durableItem.CurrentDurability / durableItem.MaxDurability;
            if (durabilityPercentage >= 0.5f) {
                _slider.fillRect.GetComponent<RawImage>().color = s_maxDurabilityColor; // Green for more than 50%
            } else if (durabilityPercentage >= 0.25f) {
                _slider.fillRect.GetComponent<RawImage>().color = s_halfDurabilitColor; // Yellow for between 25% and 50%
            } else {
                _slider.fillRect.GetComponent<RawImage>().color = s_lessThanHalfDurabilityColor; // Red for less than 25%
            }
        }
        _slider.value = sliderValue;
    }
   
    private void OnQuantityChanged(){
        if (SlotItem.Quantity == 0){
            Switch(null);
            throw new ItemBreakException();
        } 
        UpdateText();
        UpdateSlider();
    }
    public void Switch(ItemInstance newItem) {
        if (SlotItem != null)
        {
            // Unsubscribe from old item
            SlotItem.OnQuantityChanged -= OnQuantityChanged;
            if (SlotItem is DurableItemInstance durableItem){
                durableItem.OnDurabilityChanged -= UpdateSlider;
            }
        }
        SlotItem = newItem;
        if (SlotItem != null)
        {
            // Subscribe to new item
            SlotItem.OnQuantityChanged += OnQuantityChanged;
            if (SlotItem is DurableItemInstance durableItem){
                durableItem.OnDurabilityChanged += UpdateSlider;
            }
        }
        UpdateImage();
        UpdateText();
        UpdateSlider();
    }
    public void Equip(GameObject currentItemGameObject) {
        SlotItem.EquipItem(currentItemGameObject);
    }

    public void Use(Transform user) {
        SlotItem.UseItem(user);
    }

}

using UnityEngine;

public abstract class Item
{
    

    protected Texture _itemTexture; //This is the texture for the inventory
    public Texture GetItemTexture
    {
        get { return _itemTexture; }
    }

    public string Name;

    public MeshFilter MeshFilter;
    public MeshRenderer MeshRenderer;
    public abstract void CreateObject();

    public abstract void UseItem();

    public abstract void EquipItem(GameObject parentObject);
    public int StackSize { get; set; }
    public int Count { get; set; }

}

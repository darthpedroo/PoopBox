using UnityEngine;

public abstract class Item
{
    

    protected Texture itemTexture; //This is the texture for the inventory
    public Texture GetItemTexture
    {
        get { return itemTexture; }
    }

    public string name;

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public abstract void createObject();

    public abstract void useItem();

    public abstract void equipItem(GameObject parentObject);
    public int StackSize { get; set; }
    public int Count { get; set; }

}

using UnityEngine;

public abstract class Item
{
    

    protected Texture itemTexture; //This is the texture for the inventory
    public Texture GetItemTexture
    {
        get { return itemTexture; }
    }
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public abstract void createObject(GameObject parentObject);

    public abstract void useItem();

    public abstract void equipItem(GameObject parentObject);

}

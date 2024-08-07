using UnityEngine;

public abstract class Item
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public abstract void createObject(GameObject parentObject);

    public abstract void useItem();

}

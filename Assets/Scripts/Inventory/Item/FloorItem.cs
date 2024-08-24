using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : MonoBehaviour
{
    
    private Item baseItem;
    //private CapsuleCollider collider;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    public FloorItem constructor(Vector3 originPos, Item item){
        this.baseItem = item;
        //meshFilter = item.meshFilter;
        //meshRenderer = item.meshRenderer;
        transform.position = originPos;
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Item gyat = new Axe();
        constructor(new Vector3(5, 25, 10), gyat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

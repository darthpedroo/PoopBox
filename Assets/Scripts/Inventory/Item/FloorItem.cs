using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : MonoBehaviour
{
    
    public Item BaseItem;
    //private CapsuleCollider collider;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    void Start()
    {
        Axe gyat = new Axe();
        gyat.createObject(gameObject);
        BaseItem = gyat;
        transform.position = new Vector3(5, 25, 10);
    }
}

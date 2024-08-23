using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : MonoBehaviour
{
    
    private Item baseItem;

    public FloorItem builder(Vector3 originPos, Item item){
        this.baseItem = item;
        
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

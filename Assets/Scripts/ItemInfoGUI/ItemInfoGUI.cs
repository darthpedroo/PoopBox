using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemInfoGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject itemInfoGui = ObjectInstantiator.InstantiatePrefab("Prefabs/ItemInfoGUI", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        Debug.Log("xddd");
        itemInfoGui.transform.parent = gameObject.transform;
        itemInfoGui.transform.position = gameObject.transform.position;
        itemInfoGui.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemInfoGui.layer = LayerMask.NameToLayer("holdLayer");
        
        itemInfoGui.GetComponentInChildren<TMP_Text>().text = gameObject.GetComponentInChildren<IPickable>().PickUp().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

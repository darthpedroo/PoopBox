using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ListOfGameObject;

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(ListOfGameObject[0].GetComponent<ItemSlot>().currentItemType);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food", order = 5)]
public class FoodData : ItemData, IConsumable
{
    public float HungerRestore;
    public float HealthRestore;
    private Consumer _consumer;
    public override void UseItem(Transform user){
        user.GetComponentInParent<IEater>().Eat(HungerRestore,HealthRestore);
        _consumer.UpdateState();
    }
    public override void EquipItem(GameObject parentObject) {
        GameObject itemObject = Instantiate(ItemModel);
        itemObject.transform.localScale = ModelScale;
        itemObject.transform.parent = parentObject.transform;
        itemObject.transform.position = parentObject.transform.position;
        itemObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        itemObject.layer = LayerMask.NameToLayer("holdLayer");
        _consumer = itemObject.GetComponentInChildren<Consumer>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food", order = 5)]
public class FoodData : ItemData
{
    public float HungerRestore;
    public float HealthRestore;
    public override void UseItem(Transform user){
        user.GetComponentInParent<IEater>().Eat(HungerRestore,HealthRestore);
    }
}

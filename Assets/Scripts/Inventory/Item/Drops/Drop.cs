using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;

[System.Serializable]
public class Drop
{   
    [SerializeField] public ItemData Item;
    [SerializeField] public int MinDrop;
    [SerializeField] public int MaxDrop;
    [SerializeField] public float Chance;

    public Drop(ItemData item,int minDrop, int maxDrop, float percentageChance){
        Item = item;
        MinDrop = minDrop;
        MaxDrop = maxDrop;
        Chance = percentageChance;
    }

    public Drop(ItemData item, float percentageChance){
        Item = item;
        Chance = percentageChance;
    }

    public ItemInstance DropLoot(){
        float randomNumber = Random.value * 100;
        //Debug.Log(randomNumber + "  " +_chance);
        if (randomNumber <= Chance){
            int stacksize = Random.Range(MinDrop,MaxDrop);
            if (stacksize > 0){
                return new ItemInstance(Item, stacksize);
            }
        }
        return null;
        
    }
}

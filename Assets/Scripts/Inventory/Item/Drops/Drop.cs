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

    public ItemData DropLoot(){
        float randomNumber = Random.value * 100;
        //Debug.Log(randomNumber + "  " +_chance);
        if (randomNumber <= Chance){
            if (MinDrop != 0 && MaxDrop != 0){
                int stacksize = Random.Range(MinDrop,MaxDrop);
                Item.Count = stacksize;
            }
            return Item;
        } else{
            return null;
        }
        
    }
}

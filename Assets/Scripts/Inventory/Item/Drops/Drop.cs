using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;

public class Drop
{   
    private readonly Item _item;
    private readonly int _minDrop;
    private readonly int _maxDrop;
    private readonly float _chance;
    public Drop(Item item,int minDrop, int maxDrop, float percentageChance){
        _item = item;
        _minDrop = minDrop;
        _maxDrop = maxDrop;
        _chance = percentageChance;
    }

    public Item DropLoot(){
        float randomNumber = Random.value * 100;
        Debug.Log(randomNumber + "  " +_chance);
        if (randomNumber <= _chance){
            //int stacksize = Random.Range(_minDrop,_maxDrop);
            //_item.itemCount = stacksize;
            return _item;
        } else{
            return null;
        }
        
    }
}

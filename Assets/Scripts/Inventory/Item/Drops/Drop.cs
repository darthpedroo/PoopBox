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
        float randomNumber = Random.Range(0,99);
        // int stacksize = Random.Range(_minDrop,_maxDrop)
        return randomNumber <= _chance ? _item : null;
    }
}

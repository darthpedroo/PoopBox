using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public interface IDropStrategy
{
    public abstract ItemInstance[] GetDrops(List<Drop> _drops);
    public abstract void SpawnDrops(Vector3 position, List<Drop> _drops);
}

public class DropStrategyRandom : IDropStrategy
{
    public ItemInstance[] GetDrops(List<Drop> _drops)
    {
        List<ItemInstance> allLoot = new();
        foreach (Drop drop in _drops){
            ItemInstance loot = drop.DropLoot();
            if (loot != null){
                if (loot.Count < loot.StackSize){
                    allLoot.Add(loot);
                } else {
                    int FullStacks = Mathf.FloorToInt((float)loot.Count / loot.StackSize);
                    int ExcesStack = loot.Count-(FullStacks * loot.StackSize);
                    Debug.Log(FullStacks);
                    for (int i = 0; i < FullStacks; i++){
                        ItemInstance newLoot = new ItemInstance(loot.data, loot.StackSize);
                        allLoot.Add(newLoot);
                    }
                    if (ExcesStack != 0){
                        loot.Count = ExcesStack;
                        allLoot.Add(loot);
                    }
                }
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(Vector3 position, List<Drop> _drops)
    {
        foreach (Drop drop in _drops){
            ItemInstance loot = drop.DropLoot();
            if (loot != null){
                if (loot.Count < loot.StackSize){
                    FloorItemConstructor droppedItem = new(position,loot);
                } else {
                    int FullStacks = Mathf.FloorToInt((float)loot.Count / loot.StackSize);
                    int ExcesStack = loot.Count-(FullStacks * loot.StackSize);
                    Debug.Log(FullStacks);
                    for (int i = 0; i < FullStacks; i++){
                        ItemInstance newLoot = new ItemInstance(loot.data, loot.StackSize);
                        FloorItemConstructor droppedItem = new(position,newLoot);
                    }
                    if (ExcesStack != 0){
                        loot.Count = ExcesStack;
                        FloorItemConstructor excessItem = new(position,loot);
                    }
                }
            }
        }
    }

}

public class DropStrategyMutuallyExclusive : IDropStrategy
{
    private readonly float _chance;
    
    public DropStrategyMutuallyExclusive(float chance){
        // chance de que te salga alguno de los items. 
        _chance = chance;
    }
    public ItemInstance[] GetDrops(List<Drop> drops)
    {
        List<ItemInstance> allLoot = new();
        if (Random.value * 100 <= _chance) 
        {
            Drop selectedDrop = SelectOneDrop(drops); 
            ItemInstance loot = selectedDrop?.DropLoot();
            if (loot != null)
            {
                if (loot.Count < loot.StackSize){
                    allLoot.Add(loot);
                } else {
                    int FullStacks = Mathf.FloorToInt((float)loot.Count / loot.StackSize);
                    int ExcesStack = loot.Count-(FullStacks * loot.StackSize);
                    Debug.Log(FullStacks);
                    for (int i = 0; i < FullStacks; i++){
                        ItemInstance newLoot = new ItemInstance(loot.data, loot.StackSize);
                        allLoot.Add(newLoot);
                    }
                    if (ExcesStack != 0){
                        loot.Count = ExcesStack;
                        allLoot.Add(loot);
                    }
                }
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(Vector3 position, List<Drop> drops)
    {
        if (Random.value * 100 <= _chance) 
        {
            Drop selectedDrop = SelectOneDrop(drops); 
            ItemInstance loot = selectedDrop?.DropLoot();
            if (loot != null)
            {
                if (loot.Count < loot.StackSize){
                    FloorItemConstructor droppedItem = new(position,loot);
                } else {
                    int FullStacks = Mathf.FloorToInt((float)loot.Count / loot.StackSize);
                    int ExcesStack = loot.Count-(FullStacks * loot.StackSize);
                    Debug.Log(FullStacks);
                    for (int i = 0; i < FullStacks; i++){
                        ItemInstance newLoot = new ItemInstance(loot.data, loot.StackSize);
                        FloorItemConstructor droppedItem = new(position,newLoot);
                    }
                    if (ExcesStack != 0){
                        loot.Count = ExcesStack;
                        FloorItemConstructor excessItem = new(position,loot);
                    }
                }
            }
        }
    }

    private Drop SelectOneDrop(List<Drop> drops)
    {
        if (drops == null || drops.Count == 0)
            return null;
        int index = Random.Range(0, drops.Count); 
        return drops[index];
    }
}

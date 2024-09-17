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
                allLoot.AddRange(loot.DivideIntoStacks());
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(Vector3 position, List<Drop> _drops)
    {
        foreach (Drop drop in _drops){
            ItemInstance loot = drop.DropLoot();
            if (loot != null){
                foreach (ItemInstance DividedItem in loot.DivideIntoStacks()){
                    FloorItemConstructor droppedItem = new(position,DividedItem);
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
                allLoot.AddRange(loot.DivideIntoStacks());
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
            if (loot != null) {
                foreach (ItemInstance DividedItem in loot.DivideIntoStacks()){
                    FloorItemConstructor droppedItem = new(position,DividedItem);
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

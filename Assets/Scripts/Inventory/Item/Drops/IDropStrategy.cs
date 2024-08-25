using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public interface IDropStrategy
{
    public abstract Item[] GetDrops(List<Drop> _drops);
    public abstract void SpawnDrops(Vector3 position, List<Drop> _drops);
}

public class DropStrategyRandom : IDropStrategy
{
    public Item[] GetDrops(List<Drop> _drops)
    {
        List<Item> allLoot = new();
        foreach (Drop drop in _drops){
            Item loot = drop.DropLoot();
            if (loot != null){
                allLoot.Add(loot);
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(Vector3 position, List<Drop> _drops)
    {
        foreach (Drop drop in _drops){
            Item loot = drop.DropLoot();
            if (loot != null){
                FloorItemConstructor droppedItem = new FloorItemConstructor(position,loot);
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
    public Item[] GetDrops(List<Drop> drops)
    {
        List<Item> allLoot = new();
        if (Random.value * 100 <= _chance) 
        {
            Drop selectedDrop = SelectOneDrop(drops); 
            Item loot = selectedDrop?.DropLoot();
            if (loot != null)
            {
                allLoot.Add(loot);
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(Vector3 position, List<Drop> drops)
    {
        if (Random.value * 100 <= _chance) 
        {
            Drop selectedDrop = SelectOneDrop(drops); 
            Item loot = selectedDrop?.DropLoot();
            if (loot != null)
            {
                FloorItemConstructor droppedItem = new FloorItemConstructor(position, loot);
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

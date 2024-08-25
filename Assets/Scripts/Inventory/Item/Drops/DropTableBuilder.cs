
using System.Collections.Generic;

public class DropTableBuilder
{
    private readonly List<Drop> _drops = new();
    public DropTableBuilder Add(Drop drop){
        _drops.Add(drop);
        return this;
    }
    public DropTableBuilder Add(Item item,int minDrop, int maxDrop, float percentageChance){
        Drop drop = new(item,minDrop,maxDrop,percentageChance);
        _drops.Add(drop);
        return this;
    }

    public Item[] GetDrops(){
        List<Item> allLoot = new();
        foreach (Drop drop in _drops){
            Item loot = drop.DropLoot();
            if (loot != null){
                allLoot.Add(loot);
            }
        }
        return allLoot.ToArray();
    }

    public void SpawnDrops(UnityEngine.Vector3 position){
        List<Item> allLoot = new();
        foreach (Drop drop in _drops){
            Item loot = drop.DropLoot();
            if (loot != null){
                FloorItemConstructor droppedItem = new FloorItemConstructor(position,loot);
            }
        }
    }
}

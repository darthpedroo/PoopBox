
using System.Collections.Generic;

public class DropTableBuilder
{
    private readonly List<Drop> _drops = new();
    private IDropStrategy _dropStrategy;

    public DropTableBuilder(){
        _dropStrategy = new DropStrategyRandom();
    }
    public DropTableBuilder Add(Drop drop){
        _drops.Add(drop);
        return this;
    }
    public DropTableBuilder Add(Item item,int minDrop, int maxDrop, float percentageChance){
        Drop drop = new(item,minDrop,maxDrop,percentageChance);
        _drops.Add(drop);
        return this;
    }

    public DropTableBuilder SetModeMutuallyExclusive(float percentageChance){
        _dropStrategy = new DropStrategyMutuallyExclusive(percentageChance);
        return this;
    }

    public DropTableBuilder SetModeDefault(){
        _dropStrategy = new DropStrategyRandom();
        return this;
    }
    
    public Item[] GetDrops(){
        return _dropStrategy.GetDrops(_drops);
    }

    public void SpawnDrops(UnityEngine.Vector3 position){
        _dropStrategy.SpawnDrops(position,_drops);
    }
}

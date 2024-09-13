
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

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
    public DropTableBuilder Add(ItemData item,int minDrop, int maxDrop, float percentageChance){
        Drop drop = new(item,minDrop,maxDrop,percentageChance);
        _drops.Add(drop);
        return this;
    }
    public DropTableBuilder Add(List<Drop> drops){
        _drops.AddRange(drops);
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
    public DropTable GetDropTable(){
        DropTable dropTable = ScriptableObject.CreateInstance<DropTable>();
        dropTable.Initialize(_drops,_dropStrategy);
        return dropTable;
    }
}

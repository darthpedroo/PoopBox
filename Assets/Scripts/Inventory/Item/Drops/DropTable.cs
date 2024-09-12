using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable
{
    private readonly List<Drop> _drops = new();
    private readonly IDropStrategy _dropStrategy;

    public DropTable(List<Drop> drops, IDropStrategy dropStrategy){
        _drops = drops;
        _dropStrategy = dropStrategy;
    }

    public Item[] GetDrops(){
        return _dropStrategy.GetDrops(_drops);
    }

    public void SpawnDropsAt(Vector3 pos){
        _dropStrategy.SpawnDrops(pos,_drops);
    }
}

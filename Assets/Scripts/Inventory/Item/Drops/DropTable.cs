using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDropTable", menuName = "ScriptableObjects/DropTable", order = 4)]
public class DropTable : ScriptableObject
{
    [SerializeField]
    private List<Drop> _drops = new();
    private IDropStrategy _dropStrategy;


    public void Initialize(List<Drop> drops, IDropStrategy dropStrategy )
    {
        _drops = drops;
        _dropStrategy = dropStrategy;
    }

    public ItemInstance[] GetDrops(){
        return _dropStrategy.GetDrops(_drops);
    }

    public void SpawnDropsAt(Vector3 pos){
        _dropStrategy.SpawnDrops(pos,_drops);
    }
}

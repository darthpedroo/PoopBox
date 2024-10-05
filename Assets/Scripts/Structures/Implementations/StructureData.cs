using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Structure", menuName = "ScriptableObjects/Structure", order = 1)]
public class StructureData : ScriptableObject
{
    public List<GameObject> StructurePrefab;
    [SerializeField] private bool _isChopable;
    [SerializeField] private bool _isSwordable;
    [SerializeField] private bool _isShovable;
    [SerializeField] private int _health = 100;
    [SerializeField] private string _displayName = "Pedro";
    [SerializeField] private Vector3 _billboardRelativePosition ;
    [SerializeField] private List<Drop> _dropTable;
    [SerializeField] private Vector3 _scale;
    private Structure _structure;


    void OnValidate() {
        foreach (Drop drop in _dropTable){
            if (drop.Chance > 100){
                drop.Chance = 100;
            } else if (drop.Chance < 0){
                drop.Chance = 0;
            }
            if (drop.MinDrop < 0){
                drop.MinDrop = 0;
            }
            if (drop.MaxDrop < 0){
                    drop.MaxDrop = 0;
            }
        }
        if (_scale.x < 1){
            _scale.x = 1;
        }
        if (_scale.y < 1){
            _scale.y = 1;
        }
        if (_scale.z < 1){
            _scale.z = 1;
        }
	}
    
    private void ConfigureBuilder()
    {
        StructureBuilder structureBuilder = new(StructurePrefab);
        DropTable dropTable = new DropTableBuilder().Add(_dropTable).GetDropTable();
        structureBuilder.SetDropTable(dropTable);
        if (_isChopable)
        {
            structureBuilder.SetChopable();
        }
        if (_isSwordable)
        {
            structureBuilder.SetSwordable();
        }
        if (_isShovable)
        {
            structureBuilder.SetShovable();
        }
        _structure = structureBuilder.GetStructure();
    }
    public void SpawnStructure(Vector3 position){
        if (_structure == null){
            ConfigureBuilder();
        }
        _structure.PlaceStructure(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName);
    }
    public void SpawnStructure(Vector3 position, Transform parent){
        if (_structure == null){
            ConfigureBuilder();
        }
        _structure.PlaceStructure(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName,parent);
    }
    
}
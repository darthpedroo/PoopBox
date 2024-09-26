using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Structure", order = 1)]
public class StructureCreator : ScriptableObject
{
    public List<GameObject> StructurePrefab;
    [SerializeField] private bool _isChopable;
    [SerializeField] private bool _isSwordable;
    [SerializeField] private bool _isShovable;
    [SerializeField] private int _health = 100;
    [SerializeField] private string _displayName = "Pedro";
    [SerializeField] private Vector3 _billboardRelativePosition ;
    [SerializeField] private List<Drop> _dropTable;
    private StructureBuilder _structureBuilder;
    

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

	}
    private void ConfigureBuilder()
    {
        if (_isChopable)
        {
            _structureBuilder.SetChopable();
        }
        if (_isSwordable)
        {
            _structureBuilder.SetSwordable();
        }
        if (_isShovable)
        {
            _structureBuilder.SetShovable();
        }
    }
    public void SpawnStructure(Vector3 position,Vector3 scale){
        GameObject randomPrefab = StructurePrefab[Random.Range(0,StructurePrefab.Count)];
        _structureBuilder = new StructureBuilder(randomPrefab);
        ConfigureBuilder();
        DropTable dropTable = new DropTableBuilder().Add(_dropTable).GetDropTable();
        _structureBuilder.SetDropTable(dropTable);
        _structureBuilder.GetStructure().PlaceStructure(position, Quaternion.identity, scale,_billboardRelativePosition,_health,_displayName);
    }
    
}
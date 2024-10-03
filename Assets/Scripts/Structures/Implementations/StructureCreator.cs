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
    [SerializeField] private Vector3 _scale;
    private StructureBuilder _structureBuilder;
    private bool _isConfigured = false; 

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
    private void OnEnable() {
        if (!_isConfigured) {
            ConfigureBuilder();
        }
    }
    public void ConfigureBuilder()
    {
        Debug.Log("PAPU");
        _structureBuilder = new(StructurePrefab);
        DropTable dropTable = new DropTableBuilder().Add(_dropTable).GetDropTable();
        _structureBuilder.SetDropTable(dropTable);
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
        _isConfigured = true;
    }
    public void SpawnStructure(Vector3 position){
        _structureBuilder.GetStructure().PlaceStructure(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName);
    }
    public void SpawnStructure(Vector3 position, Transform parent){
        _structureBuilder.GetStructure().PlaceStructure(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName,parent);
    }
    
}
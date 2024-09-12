using UnityEngine;

public class StructureBuilderComponent : MonoBehaviour
{
    public GameObject structurePrefab;
    
    [SerializeField] private bool _isChopable;
    [SerializeField] private bool _isSwordable;
    [SerializeField] private bool _isShovable;
    [SerializeField] private int _health = 100;
    [SerializeField] private string _displayName = "Gyatler";
    [SerializeField] private Vector3 _scale = Vector3.one * 10;
    [SerializeField] private Vector3 _position = Vector3.one * 3;
    private StructureBuilder _structureBuilder;
    private void InitializeBuilder()
    {
        _structureBuilder = new StructureBuilder(structurePrefab);

        DropTable dropTable = new DropTableBuilder().Add(new Wood(2), 1, 3, 100).GetDropTable();
        _structureBuilder.SetDropTable(dropTable);
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
    public void SpawnStructure()
    {
        InitializeBuilder();
        ConfigureBuilder();
        _structureBuilder.GetStructure().PlaceStructure(_position, Quaternion.identity, _scale,_health,_displayName);
    }
}

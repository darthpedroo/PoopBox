using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 6)]
public class EntityData : ScriptableObject
{
    public List<GameObject> EntityPrefab;
    [SerializeField] private int _health = 100;
    [SerializeField] private string _displayName = "Pedro";
    [SerializeField] private Vector3 _billboardRelativePosition;
    [SerializeField] private List<Drop> _dropTable;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _speed;
    private Entity _entity;
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
    private void ConfigureBuilder(){
        EntityBuilder entityBuilder = new(EntityPrefab);
        DropTable dropTable = new DropTableBuilder().Add(_dropTable).GetDropTable();
        entityBuilder.AddDropTable(dropTable);
        entityBuilder.AddChopable();
        entityBuilder.SetSpeed(_speed);
        _entity = entityBuilder.GetEntity();
    }
    public void SpawnEntity (Vector3 position){
        if (_entity == null){
            ConfigureBuilder();
        }
        _entity.SpawnEntity(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName);
    }
    public void SpawnEntity (Vector3 position, Transform parent){
        _entity.SpawnEntity(position, Quaternion.identity, _scale,_billboardRelativePosition,_health,_displayName, parent);
    }
}

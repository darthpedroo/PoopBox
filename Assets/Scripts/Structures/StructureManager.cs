using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour, IHealth
{
    // Start is called before the first frame update
    public int Health {get; set;}
    private DropTable _dropTable;
    private bool _isDestroyed;
    public void TakeDamage(int damage, RaycastHit hit){
        if (_isDestroyed){
            return;
        }
        if (Health - damage <= 0){
            Health = 0;
            _isDestroyed = true;
            DestroySelf(hit);
        } else{
            Health -= damage;
        }
    }
    public void SetHealth(int health){
        Health = health;
    }
    public void SetDropTable(DropTable dropTable) {
        _dropTable = dropTable;
    }
    private void DestroySelf(RaycastHit hit){
        _dropTable.SpawnDropsAt(transform.position);
        Destroy(gameObject, 0.5f);
    }

}

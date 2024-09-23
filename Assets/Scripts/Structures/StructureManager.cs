using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    private DropTable _dropTable;
    public void SetDropTable(DropTable dropTable) {
        _dropTable = dropTable;
    }
    public void DestroySelf(){
        _dropTable.SpawnDropsAt(transform.position);
        Destroy(gameObject, 0.5f);
    }
}

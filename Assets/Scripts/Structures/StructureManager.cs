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
        Vector3 dropPosition = transform.position;
        dropPosition.y += 2;
        _dropTable.SpawnDropsAt(dropPosition);
        Destroy(gameObject);
    }
}

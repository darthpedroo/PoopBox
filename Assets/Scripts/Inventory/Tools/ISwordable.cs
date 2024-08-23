using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwordable
{
    void TakeSwordDamage(Tool tool, RaycastHit hit);
}

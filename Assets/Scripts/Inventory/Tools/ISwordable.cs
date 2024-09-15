using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwordable
{
    void TakeSwordDamage(int damage, RaycastHit hit);
}

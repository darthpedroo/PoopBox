using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickaxable
{
    void TakePickaxeDamage(int damage, RaycastHit hit);
}

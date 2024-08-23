using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickaxable
{
    void TakePickaxeDamage(Tool tool, RaycastHit hit);
}

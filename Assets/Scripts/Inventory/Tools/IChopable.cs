using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChopable 
{
    void TakeAxeDamage(int damage, RaycastHit hit);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChopable 
{
    void TakeAxeDamage(Tool tool, RaycastHit hit);
}

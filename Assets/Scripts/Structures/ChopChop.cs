using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopChop : MonoBehaviour, IChopable
{
    private IHealth _healthComponent;
    public void TakeAxeDamage(Tool tool, RaycastHit hit){
        _healthComponent.TakeDamage(tool.Damage, hit);
    }
    void Start(){
        _healthComponent = GetComponent<IHealth>();
    }
    
}

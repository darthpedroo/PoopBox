using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopChop : MonoBehaviour, IChopable
{
    private IHealth _healthComponent;
    public void TakeAxeDamage(int damage, RaycastHit hit){
        _healthComponent.TakeDamage(damage, hit);
    }
    void Start(){
        _healthComponent = GetComponent<IHealth>();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopChop : MonoBehaviour, IChopable
{
    private bool _isDestroyed;
    private IHealth _healthComponent;

    public void TakeAxeDamage(Tool tool, RaycastHit hit){
        if (_isDestroyed){return;}
        _healthComponent.Health -= tool.Damage;
        if (_healthComponent.Health <= 0) {
            DestroyTree(hit);
        }
    }
    
    public void DestroyTree(RaycastHit hit){
        _isDestroyed = true;
        //Hacer que no se pueda seguir golpeando al arbol porque se puede seguir ejecutando "TakeDamage"
        Destroy(gameObject, 0.5f);

    }

    void Start(){
        _healthComponent = GetComponent<IHealth>();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Structure : MonoBehaviour, IHealth, IChopable
{
    public int Health {get; set;}
    public GameObject HitParticle;
    public GameObject BazingaParticle;
    private DropTable _dropTable;
    private bool _isDestroyed;
    void Start()
    {
        Health = 250;
        //_dropTable = new DropTableBuilder().Add(new Wood(1),33,33,100).GetDropTable();
    }
    public void TakeDamage(int damage, RaycastHit hit){
        Debug.LogWarning("Take Damage Not Implemented");
    }
    public void TakeAxeDamage(int damage, RaycastHit hit){
        if (_isDestroyed){return;}
        HitParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/HitParticle", transform.position, Quaternion.identity); 
        //Hacer esto UN SINGELTON
        HitParticle.transform.parent = transform;
        
        Health -= damage;
        if (Health <= 0) {
            DestroyTree(hit);
        } else{
            HitParticle.transform.position = hit.point;
            HitParticle.GetComponent<ParticleSystem>().Emit(1);
        }
    }
    
    public void DestroyTree(RaycastHit hit){
        BazingaParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/BazingaParticle", hit.point, Quaternion.Euler(0f, 0f, 0f));
        BazingaParticle.transform.parent = transform;
        BazingaParticle.GetComponent<ParticleSystem>().Emit(1);
        //_dropTable.SpawnDropsAt(transform.position);
        _isDestroyed = true;
        //Hacer que no se pueda seguir golpeando al arbol porque se puede seguir ejecutando "TakeDamage"
        Destroy(gameObject, 0.5f);

    }
}

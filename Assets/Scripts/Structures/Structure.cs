using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Structure : MonoBehaviour, IHealth, IChopable
{
    public int Health {get; set;}
    public GameObject HitParticle;
    public GameObject BazingaParticle;
    private Item[] _dropTable;
    private bool _isDestroyed;
    void Start()
    {
        Health = 250;
        _dropTable = new Item[] { new Wood(3) };
    }

    public void TakeAxeDamage(Tool tool, RaycastHit hit){
        if (_isDestroyed){return;}
        HitParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/HitParticle", transform.position, Quaternion.identity); 
        //Hacer esto UN SINGELTON
        HitParticle.transform.parent = transform;
        
        Health -= tool.Damage;
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
        int randomNumber = Random.Range(0, _dropTable.Length);
        FloorItemConstructor droppedItem = new FloorItemConstructor(gameObject.transform.position,_dropTable[randomNumber]);
        _isDestroyed = true;
        //Hacer que no se pueda seguir golpeando al arbol porque se puede seguir ejecutando "TakeDamage"
        Destroy(gameObject, 0.5f);

    }
}

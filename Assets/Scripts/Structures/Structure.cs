using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Structure : MonoBehaviour, IHealth, IChopable
{
    public int Health {get; set;}
    public GameObject HitParticle;
    public GameObject BazingaParticle;
    private bool _isDestroyed;
    void Start()
    {
        Health = 250;
    }

    public void TakeAxeDamage(Tool tool, RaycastHit hit){
        if (_isDestroyed){return;}
        HitParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/HitParticle", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f)); //Hacer esto UN SINGELTON
        HitParticle.transform.parent = transform;
        HitParticle.transform.position = transform.position;
        HitParticle.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        
        Health -= tool.Damage;
        if (Health <= 0) {
            DestroyTree(hit);
        } else{
            HitParticle.transform.position = hit.point;
            HitParticle.GetComponent<ParticleSystem>().Emit(1);
        }
    }
    
    public void DestroyTree(RaycastHit hit){
        BazingaParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/BazingaParticle", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        BazingaParticle.transform.parent = transform;
        BazingaParticle.transform.position = transform.position;
        BazingaParticle.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        BazingaParticle.transform.position = hit.point;
        BazingaParticle.GetComponent<ParticleSystem>().Emit(1);

        _isDestroyed = true;
        //Hacer que no se pueda seguir golpeando al arbol porque se puede seguir ejecutando "TakeDamage"
        Destroy(gameObject, 0.5f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IHealth
{
    public int Health {get; set;}
    public string DisplayName{get; set;}
    public GameObject hitParticle;
    public GameObject bazingaParticle;
    
    void Start()
    {
        Health = 250;
        DisplayName = "Arbol";
    }

    public void TakeDamage(Tool tool, RaycastHit hit){
        hitParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/HitParticle", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f)); //Hacer esto UN SINGELTON
        hitParticle.transform.parent = transform;
        hitParticle.transform.position = transform.position;
        hitParticle.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("Oh oh me estan comiendo");
        Health -= tool.Damage;
        if (Health <= 0) {
            DestroyTree(hit);
        } else{
            hitParticle.transform.position = hit.point;
            hitParticle.GetComponent<ParticleSystem>().Emit(1);
        }
    }
    
    public void DestroyTree(RaycastHit hit){
        bazingaParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/BazingaParticle", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        bazingaParticle.transform.parent = transform;
        bazingaParticle.transform.position = transform.position;
        bazingaParticle.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("Bazingaaa");
        bazingaParticle.transform.position = hit.point;
        bazingaParticle.GetComponent<ParticleSystem>().Emit(1);
        //Hacer que no se pueda seguir golpeando al arbol porque se puede seguir ejecutando "TakeDamage"
        Destroy(gameObject, 0.5f);

    }
}

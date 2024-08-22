using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStructure : MonoBehaviour
{
    public int health;
    public GameObject hitParticle;
    public GameObject bazingaParticle;
    
    void Start()
    {
        health = 250;
        hitParticle = ObjectInstantiator.InstantiatePrefab("Prefabs/HitParticle", new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
        hitParticle.transform.parent = transform;
        hitParticle.transform.position = transform.position;
        hitParticle.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

    }

    public void takeDamage(int Damage, RaycastHit hit){
        Debug.Log("Oh oh me estan comiendo");
        health-=Damage;
        hitParticle.transform.position = hit.point;
        hitParticle.GetComponent<ParticleSystem>().Emit(1);
    }


    void Update()
    {
        
    }
}

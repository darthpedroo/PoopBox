using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    // OBSOLETEEEEEEEE
    // OBSOLETEEEEEEEE// OBSOLETEEEEEEEE// OBSOLETEEEEEEEE// OBSOLETEEEEEEEE// OBSOLETEEEEEEEE
    public Item itemScript;
    public Rigidbody rb;
    public BoxCollider coll;

    public Transform player, gunContainer,fpsCam;

    public float pickUpRange;
    public float dropForwardForce,dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    void Start()
    {
        
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();

        
    }

    private void PickUp(){
        equipped = true;
        slotFull =true;
        rb.isKinematic = true;
        coll.isTrigger = true;
        //itemScript.enabled = true;


    }

    private void Drop(){
        equipped = false;
        slotFull =false;
        rb.isKinematic = false;
        coll.isTrigger = false;

    }
}

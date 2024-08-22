using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    void Start(){
        cam = FindObjectOfType<Camera>().transform;
        Vector3 gyat = transform.parent.parent.position;
        gyat.y += 6f;
        transform.parent.parent.position = gyat;
    }

    void LateUpdate(){
        transform.LookAt(transform.position + cam.forward);
    }
}

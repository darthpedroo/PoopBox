using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    private Canvas healthBarCanvas;
    void Start(){
        cam = FindObjectOfType<Camera>().transform;
        Vector3 gyat = transform.parent.parent.position;
        gyat.y += 6f;
        transform.parent.parent.position = gyat;
        healthBarCanvas = GetComponentInParent<Canvas>();
    }

    void LateUpdate(){
        Vector3 dir = (transform.position - cam.position).normalized;
        float dot = Vector3.Dot(dir, transform.forward);
        transform.LookAt(transform.position + cam.forward);
        healthBarCanvas.enabled = (cam.position - transform.position).magnitude < 30f && dot >= 0.95;
    }
}

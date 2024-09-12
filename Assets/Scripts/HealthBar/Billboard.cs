using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform Cam;
    public string DisplayName;
    private Canvas _healthBarCanvas;
    void Start(){
        Cam = FindObjectOfType<Camera>().transform;
        Vector3 gyat = transform.parent.parent.position;
        gyat.y += 6f;
        transform.parent.parent.position = gyat;
        _healthBarCanvas = GetComponentInParent<Canvas>();
        TMP_Text textDisplay = GetComponentInChildren<TMP_Text>();
        textDisplay.text = DisplayName;
    }

    public void SetDisplayName(string displayName){
        TMP_Text textDisplay = GetComponentInChildren<TMP_Text>();
        textDisplay.text = displayName;
        DisplayName = displayName;
    }

    void LateUpdate(){
        transform.LookAt(transform.position + Cam.forward);
        _healthBarCanvas.enabled = (Cam.position - transform.position).magnitude <= 10f;
    }
}

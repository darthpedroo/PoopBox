using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth;
    public float health;
    private float lerpSpeed = 0.05f;
    public Canvas healthBarCanvas;
    void Start(){
        maxHealth = GetComponentInParent<Structure>().Health;
        health = maxHealth;
        slider.maxValue = maxHealth;
        healthBarCanvas = GetComponentInParent<Canvas>();
    }
    
    void Update(){
        health = GetComponentInParent<Structure>().Health;
        healthBarCanvas.enabled = !(health == maxHealth);
        if (slider.value != health){
            slider.value = Mathf.Lerp(slider.value, health, lerpSpeed);
        }
    }
}

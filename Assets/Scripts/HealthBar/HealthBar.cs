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
    void Start(){
        maxHealth = GetComponentInParent<Structure>().Health;
        health = maxHealth;
        slider.maxValue = maxHealth;
    }
    
    void Update(){
        health = GetComponentInParent<Structure>().Health;
        if (slider.value != health){
            slider.value = Mathf.Lerp(slider.value, health, lerpSpeed);
        }
    }
}

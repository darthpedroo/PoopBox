using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    private float _maxHealth;
    private float _health;
    private readonly float _lerpSpeed = 0.05f;
    void Start(){
        _maxHealth = GetComponentInParent<IHealth>().Health;
        _health = _maxHealth;
        Slider.maxValue = _maxHealth;
    }
    
    void Update(){
        _health = GetComponentInParent<IHealth>().Health;
        if (Slider.value != _health){
            Slider.value = Mathf.Lerp(Slider.value, _health, _lerpSpeed);
        }
    }
}

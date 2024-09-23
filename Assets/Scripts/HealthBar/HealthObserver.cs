using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObserver : MonoBehaviour, IHealth
{
    public int Health {get; set;}
    private System.Action _onDeathCallBack;
    private bool _isDestroyed;
    public void TakeDamage(int damage, RaycastHit hit)
    {
        if (_isDestroyed){
            return;
        }
        if (Health - damage <= 0){
            Health = 0;
            _isDestroyed = true;
            _onDeathCallBack();
        } else{
            Health -= damage;
        }
    }
    public void SetUp(int startingHealth, System.Action callback, string displayName, int scale, Vector3 billboardRelativePosition){
        _onDeathCallBack = callback;
        GameObject healthBarPrefab = Resources.Load<GameObject>("Prefabs/HealthBar");
        GameObject healthBar = GameObject.Instantiate(healthBarPrefab, transform);
        Health = startingHealth;
        Billboard billboard = healthBar.GetComponentInChildren<Billboard>();
        billboard.SetScale(scale);
        billboard.SetDisplayName(displayName);
        billboard.SetRelativePosition(billboardRelativePosition);
    }
}

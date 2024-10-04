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
            DeathParticle(hit);
            StartCoroutine(DelayedDeathCallback());
        } else{
            HitParticle(hit);
            Health -= damage;
        }
    }

    void HitParticle(RaycastHit hit){
        GameObject hitParticle = Instantiate(Resources.Load<GameObject>("Prefabs/HitParticle"), new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f), transform);
        hitParticle.transform.localScale = Vector3.one * 0.15f;
        hitParticle.transform.position = hit.point;
    }
    void DeathParticle(RaycastHit hit){
        GameObject bazingaParticle = Instantiate(Resources.Load<GameObject>("Prefabs/BazingaParticle"), new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f), transform);
        bazingaParticle.transform.localScale = Vector3.one * 0.15f;
        bazingaParticle.transform.position = hit.point;
    }
    private IEnumerator DelayedDeathCallback() {
        yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds
        _onDeathCallBack();
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

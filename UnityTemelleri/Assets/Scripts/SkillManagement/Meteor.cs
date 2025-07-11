using System.Collections;
using System.Collections.Generic;
using Scripts.Enemy;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public PlayerData playerData;
    public float meteorDamage;
    public float fallSpeed = 50f; 
    public GameObject impactEffect;
    public GameObject impactEffectInstance;
    public float meteorFallStartHeight = 30f;
    void Start()
    {
        meteorDamage = playerData.meteorSkillDamage;
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            // Alan içindeki tüm düşmanları bul ve hasar ver
            float radius = gameObject.GetComponent<SphereCollider>().radius;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var hit in hitColliders)
            {
                if (hit.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(meteorDamage);
                    }
                }
            }
            impactEffectInstance = Instantiate(impactEffect, transform.position, Quaternion.identity); // Etki efekti oluştur
            Destroy(gameObject);
            Destroy(impactEffectInstance, 1f);
        }
    }
}

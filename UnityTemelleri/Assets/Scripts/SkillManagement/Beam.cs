using System.Collections;
using System.Collections.Generic;
using Scripts.Enemy;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject beamPrefab;
    public float beamDamage;
    public float beamStartHeight = 10f;
    public float beamFallSpeed = 30f;
    void Start()
    {
        beamDamage = playerData.beamSkillDamage;
        GetComponent<Rigidbody>().velocity = Vector3.down * beamFallSpeed; // Beam'in düşme hızını ayarla
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(beamDamage); // Beam ile çarpan düşmana hasar ver
            Destroy(gameObject); // Beam'i yok et
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Enemy;
namespace Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab; // Mermi prefab
        [SerializeField] private Transform spawnPoint; // Merminin spawn edileceği nokta
        [SerializeField] private float bulletSpeed = 40f; // Merminin hızı
        [SerializeField] private float playerBulletDamage = 50f; // Player mermi hasarı
        public GameObject shootTarget; // Merminin hedefi

        public void Shoot()
        {
            shootTarget = GetComponent<EnemyDetector>().GetClosestEnemy(); // En yakın düşmanı al
            // Eğer en yakın düşman yoksa atış yapma
            if (shootTarget == null)
            {
                return;
            }
            Projectile.Shoot(shootTarget, spawnPoint, bulletPrefab, playerBulletDamage, bulletSpeed); // Player damage ile mermi at
        }
    }
}
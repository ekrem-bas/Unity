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
        [SerializeField] private float playerBulletDamage = 75f; // Player mermi hasarı
        private GameObject shootTarget; // Merminin hedefi
        private float shootTimer = 4f; // Atış zamanlayıcısı
                                       // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Shoot", 0f, shootTimer); // Her 5 saniyede bir Shoot fonksiyonunu çağır
        }

        void Shoot()
        {
            shootTarget = GetComponent<EnemyDetector>().GetClosestEnemy(); // En yakın düşmanı al
            if (shootTarget == null) return; // Eğer en yakın düşman yoksa atış yapma

            Bullet.Shoot(shootTarget, spawnPoint, bulletPrefab, playerBulletDamage, bulletSpeed); // Player damage ile mermi at
        }
    }
}
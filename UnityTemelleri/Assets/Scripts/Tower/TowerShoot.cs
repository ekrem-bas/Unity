using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Enemy;

namespace Scripts.Tower
{
    public class TowerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab; // Mermi prefab
        [SerializeField] private Transform spawnPoint; // Merminin spawn edileceği nokta
        private GameObject shootTarget; // Merminin hedefi
        private float shootTimer = 4f; // Atış zamanlayıcısı
        private float bulletSpeed = 20f; // Merminin hızı
                                         // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Shoot", 0f, shootTimer);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Shoot()
        {
            EnemyDetector detector = GetComponent<EnemyDetector>();
            shootTarget = detector.GetClosestEnemy(); // En yakın düşmanı al

            // Eğer hedef yoksa atış yapma
            if (shootTarget == null)
            {
                return;
            }

            Bullet.Shoot(shootTarget, spawnPoint, bulletPrefab, bulletSpeed); // Mermiyi hedefe doğru at
        }
    }
}
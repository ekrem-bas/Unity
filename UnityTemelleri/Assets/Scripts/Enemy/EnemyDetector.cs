using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private GameObject closestEnemy; // En yakın düşman
        [SerializeField] private GameObject owner;
        public EnemySpawner enemySpawner; // EnemySpawner referansı

        private void Start()
        {
            enemySpawner = FindObjectOfType<EnemySpawner>(); // EnemySpawner'ı bul
        }
        // Update is called once per frame
        void Update()
        {
            closestEnemy = ClosestEnemy(); // En yakın düşmanı bul
                                           // Eğer en yakın düşman varsa ona bak
            if (closestEnemy != null)
            {
                owner.transform.LookAt(closestEnemy.transform); // Oyuncu en yakın düşmana bakar
                float yOffset = 45f;
                owner.transform.Rotate(0, yOffset, 0);
            }
        }

        private GameObject ClosestEnemy()
        {
            // Eğer hiç düşman yoksa null döndür
            if (EnemySpawner.allEnemies.Count == 0)
                return null;

            GameObject closest = EnemySpawner.allEnemies[0];
            float closestDistance = Mathf.Infinity; // En yakın mesafe başlangıçta sonsuz olarak ayarlanır

            foreach (GameObject enemy in EnemySpawner.allEnemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position); // Düşman ile bu nesne arasındaki mesafeyi hesapla
                if (distance < closestDistance) // Eğer bu düşman daha yakınsa
                {
                    closestDistance = distance; // En yakın mesafeyi güncelle
                    closest = enemy; // En yakın düşmanı güncelle
                }
            }
            return closest;
        }

        public GameObject GetClosestEnemy()
        {
            return closestEnemy; // En yakın düşmanı döndür
        }
    }
}

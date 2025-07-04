using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public enum EnemyType
    {
        Swordsman,
        Archer
    }
    public class Enemy : MonoBehaviour
    {
        // Tüm düşmanları tutan static liste
        public EnemyType enemyType; // düşmanın tipi
        public float archerDistance = 10f;
        public static List<GameObject> allEnemies = new List<GameObject>();
        [SerializeField] private GameObject target; // oyuncu
        public NavMeshAgent agent; // NavMeshAgent bileşeni
        float speed = 2f; // düşmanın hareket hızı
        [SerializeField] private Healthbar healthbar; // sağlık çubuğu scripti
        public float maxHealth = 100f; // düşmanın maksimum canı
        public float health = 100f; // düşmanın şu anki canı
        private Animator animator; // düşmanın animasyonlarını kontrol etmek için
        public float attackRange = 2f;

        // coin manager
        private CoinManager coinManager;
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed; // düşmanın hızını ayarla
            healthbar = GetComponentInChildren<Healthbar>(); // sağlık çubuğu scriptini al
            animator = GetComponent<Animator>(); // düşmanın animasyonlarını kontrol etmek için
        }

        // Start is called before the first frame update
        void Start()
        {
            // Bu düşmanı listeye ekle
            allEnemies.Add(gameObject);
            target = GameObject.FindGameObjectWithTag("Player");
            healthbar.UpdateHealthbar(maxHealth, health);
        }

        // Update is called once per frame
        void Update()
        {
            if (enemyType == EnemyType.Swordsman)
            {
                // hedefe olan mesafeyi hesapla
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance <= attackRange) // attack range içinde ise
                {
                    // Saldırı animasyonunu başlat
                    animator.SetBool("isAttacking", true);

                }
                else
                {
                    agent.SetDestination(target.transform.position); // Takip et
                    animator.SetBool("isAttacking", false);          // Saldırı animasyonunu iptal et
                }
            }
            else if (enemyType == EnemyType.Archer)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= archerDistance)
                {
                    // okçu hedefe belirli mesafede dursun
                    agent.SetDestination(transform.position); // dur
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    agent.SetDestination(target.transform.position); // hedefe doğru hareket et
                    animator.SetBool("isWalking", true);
                }
            }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            healthbar.UpdateHealthbar(maxHealth, health); // sağlık çubuğunu güncelle

            if (health <= 0) // Eğer canı sıfır veya altına düşerse
            {
                Destroy(gameObject); // düşmanı yok et

                coinManager = FindObjectOfType<CoinManager>();
                coinManager.coinCount += 50; // 10 coin ekle
            }
        }

        // Nesne yok edilirken çağrılır
        void OnDestroy()
        {
            allEnemies.Remove(gameObject);
        }

        public Transform arrowSpawnPoint;
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;

        public void ShootArrow()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;

            Bullet.Shoot(player, arrowSpawnPoint, bulletPrefab, 25f, bulletSpeed);
        }
    }
}
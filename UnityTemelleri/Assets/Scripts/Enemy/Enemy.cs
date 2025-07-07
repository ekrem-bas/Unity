using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public enum EnemyType
    {
        Swordsman,
        Wizard
    }
    public class Enemy : MonoBehaviour
    {
        // Tüm düşmanları tutan static liste
        public EnemyType enemyType; // düşmanın tipi
        public float wizardDistance = 10f;
        public static List<GameObject> allEnemies = new List<GameObject>();
        [SerializeField] private GameObject target; // oyuncu
        public NavMeshAgent agent; // NavMeshAgent bileşeni
        float speed = 2f; // düşmanın hareket hızı
        [SerializeField] private Healthbar healthbar; // sağlık çubuğu scripti
        public static float maxHealth = 100f; // düşmanın maksimum canı
        public float health = maxHealth; // düşmanın şu anki canı
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
            else if (enemyType == EnemyType.Wizard)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= wizardDistance)
                {
                    // okçu hedefe belirli mesafede dursun
                    agent.SetDestination(transform.position); // dur
                    animator.SetBool("isWalking", false);
                    // agent ile degil lookAt ile hedefe bak
                    agent.updateRotation = false;
                    transform.LookAt(target.transform.position); // hedefe bak
                }
                else
                {
                    agent.SetDestination(target.transform.position); // hedefe doğru hareket et
                    animator.SetBool("isWalking", true);
                    agent.updateRotation = true; // düşman hedefe bakabilsin
                }
            }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            healthbar.UpdateHealthbar(maxHealth, health); // sağlık çubuğunu güncelle

            if (health <= 0) // Eğer canı sıfır veya altına düşerse
            {
                animator.SetTrigger("Death"); // Ölüm animasyonunu başlat
                agent.isStopped = true; // düşmanı durdur
                animator.SetBool("isWalking", false); // yürüyüş animasyonunu durdur
                animator.SetBool("isAttacking", false); // saldırı animasyonunu durdur
                this.healthbar.gameObject.SetActive(false); // sağlık çubuğunu gizle
                allEnemies.Remove(gameObject); // düşmanı listeden kaldır
                coinManager = FindObjectOfType<CoinManager>();
                coinManager.coinCount += 50; // 10 coin ekle
            }
        }

        public void DestroySelf()
        {
            Destroy(gameObject); // düşmanı yok et
        }

        public Transform magicSpanwPoint;
        public GameObject magicPrefab;
        public float magicSpeed = 20f;
        public float magicDamage = 20f;
        public void MagicAttack()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;

            Projectile.Shoot(player, magicSpanwPoint, magicPrefab, magicDamage, magicSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                this.TakeDamage(other.GetComponent<Projectile>().damage); // Mermiden hasar al
                Destroy(other.gameObject); // Mermiyi yok et
            }

            if (other.CompareTag("Magic"))
            {
                Destroy(other.gameObject); // Magic item yok et
            }
        }

        // kılıcın collider'i sadece attack animasyonunda aktif olsun
        public Collider swordCollider;
        // kılıcın hasarı
        public float swordDamage = 10f;
        public void SwordAttackStart()
        {
            swordCollider.enabled = true;
        }

        public void SwordAttackEnd()
        {
            swordCollider.enabled = false;
        }
    }
}